using CSharp.DanielArana.Fanalca.BL.Interfaces.Security;
using CSharp.DanielArana.Fanalca.Entities.Security;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.DanielArana.Fanalca.API.Data
{
    public class ManagementToken : IManagementTokenBL
    {

        private IConfiguration _Configuration { get; }
        private IWebHostEnvironment _WebHostEnvironment { get; }

        public ManagementToken(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            _Configuration = configuration;
            _WebHostEnvironment = webHostEnvironment;
        }

        public string GenerateToken(UserInfo user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName,user.login),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("login", user.login),
            };

            var token = BuildToken(claims);

            return token;
        }
        public string BuildToken(IEnumerable<Claim> claims)
        {
            var appSettingsSection = _Configuration.GetSection("AppSettings");
            var appSettings = appSettingsSection.Get<AppSettings>();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.SecretLogin));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwt = new JwtSecurityToken(
                  audience: appSettings.Audience,
                  issuer: appSettings.IssuerLogin,
                  claims: claims,
                  expires: DateTime.UtcNow.AddMinutes(appSettings.ExpireTimeSession),
                  signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = GetValidationParameters();
            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if (!(securityToken is JwtSecurityToken jwtSecurityToken) || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("token no válido");

            return principal;
        }

        public TokenValidationParameters GetValidationParameters()
        {
            var appSettingsSection = _Configuration.GetSection("AppSettings");
            var appSettings = appSettingsSection.Get<AppSettings>();

            var ValidateLifetime = true;
            var ValidIssuer = appSettings.IssuerLogin;
            var IssuerSigningKey = appSettings.SecretLogin;


            return new TokenValidationParameters()
            {
                ValidateLifetime = ValidateLifetime,
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidIssuer = ValidIssuer,
                ValidAudience = appSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(IssuerSigningKey))
            };
        }
    }
}
