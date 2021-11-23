using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CSharp.DanielArana.Fanalca.Entities;
using CSharp.DanielArana.Fanalca.BL.Interfaces.Security;
using Microsoft.Extensions.Configuration;
using CSharp.DanielArana.Fanalca.Entities.Security;
using System;
using CSharp.DanielArana.Fanalca.Entities.Error;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp.DanielArana.Fanalca.API.Security
{
    [ApiController]
    [Route("api/auth")]
    [Consumes("application/json")]
    public class AuthController : ControllerBase
    {
        private IManagementTokenBL _managementToken { get; }

        private IConfiguration _Configuration { get; }

        private IAPIClaimBL _Claim { get; }

        private IAuthBL _Auth { get; }

        public AuthController(IManagementTokenBL managementToken, IConfiguration configuration, IAPIClaimBL aPIClaim, IAuthBL auth)
        {

            _managementToken = managementToken;
            _Configuration = configuration;
            _Claim = aPIClaim;
            _Auth = auth;

        }

        /// <summary>
        /// Generar Token de acceso 
        /// </summary>
        /// <param name="objLogin">usuario, contraseña</param>        
        [HttpPost("[action]")]
        public async Task<ActionResult<UserInfo>> Login(LoginEntity objLogin)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserInfo userInfo = null;
                    var appSettingSection = _Configuration.GetSection("AppSettings");
                    var appSetting = appSettingSection.Get<AppSettings>();

                    //validad user y contraseña
                    if (objLogin.Username.ToUpper() != "" && objLogin.Password.ToUpper() != "")
                    {

                        userInfo = await _Auth.Authorize(objLogin);


                        userInfo.expiration = DateTime.Now.AddMinutes(appSetting.ExpireTimeSession);
                        userInfo.login = objLogin.Username;
                    }

                    if (userInfo != null)
                    {
                        if (userInfo.estado)
                        {
                            userInfo.token = _managementToken.GenerateToken(userInfo);
                            return Ok(userInfo);
                        }
                        return Unauthorized(new UnauthorizedError("El usuario está deshabilitado"));
                    }

                    return Unauthorized(new UnauthorizedError("Usuario y/o contraseña no válidos"));
                }
                var errors = ModelState.Select(x => new { x.Key, x.Value.Errors }).Where(v => v.Errors.Count > 0).ToList();
                return StatusCode(InternalServerError.StatusCodeModel, new InvalidModelError(errors));
            }
            catch (Exception ex)
            {
                var logUser = _Claim.Login;
                return StatusCode(InternalServerError.StatusCode, new InternalServerError(ex, !string.IsNullOrEmpty(logUser) ? logUser : objLogin.Username));
            }
        }
    }
}
