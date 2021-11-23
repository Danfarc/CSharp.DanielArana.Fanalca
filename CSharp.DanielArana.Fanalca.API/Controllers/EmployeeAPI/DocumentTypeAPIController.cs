using CSharp.DanielArana.Fanalca.BL.Interfaces.Fanalca;
using CSharp.DanielArana.Fanalca.BL.Interfaces.Security;
using CSharp.DanielArana.Fanalca.Entities.Fanalca;
using CSharp.DanielArana.Fanalca.Entities.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CSharp.DanielArana.Fanalca.API.Controllers.EmployeeAPI
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypeAPIController : ControllerBase
    {

        private IDocumentTypeBL _accionBL_Consultar;
        private IManagementTokenBL _managementToken { get; }
        private IConfiguration _Configuration { get; }

        private IHostingEnvironment Environment;
        private IAPIClaimBL _Claim { get; }
        private IAuthBL _Auth { get; }

        public DocumentTypeAPIController(

                                                 IDocumentTypeBL accionBL_Consultar,
                                                 IManagementTokenBL managementToken,
                                                 IConfiguration configuration,
                                                 IHostingEnvironment _environment,
                                                 IAPIClaimBL aPIClaim,
                                                 IAuthBL auth)
        {
            this._accionBL_Consultar = accionBL_Consultar;
            _managementToken = managementToken;
            _Configuration = configuration;
            Environment = _environment;
            _Claim = aPIClaim;
            _Auth = auth;
        }


        // GET: api/<DocumentTypeAPIController>
        [HttpGet]
        public ActionResult<Respuesta> Get()
        {
            try
            {
                return Ok(_accionBL_Consultar.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Id")]
        public ActionResult<Respuesta> Get(int Id)
        {
            try
            {
                return Ok(_accionBL_Consultar.Get(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Id")]
        public ActionResult<Respuesta> Delete(int Id)
        {
            try
            {
                return Ok(_accionBL_Consultar.Delete(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Respuesta> Add(DocumentType oModel)
        {
            try
            {
                ActionResult<Respuesta> data = _accionBL_Consultar.Add(oModel);
                if (data.Value.Exito == 0)
                    return BadRequest(data);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult<Respuesta> Edit(DocumentType oModel)
        {
            try
            {
                ActionResult<Respuesta> data = _accionBL_Consultar.Edit(oModel);
                if (data.Value.Exito == 0)
                    return BadRequest(data);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
