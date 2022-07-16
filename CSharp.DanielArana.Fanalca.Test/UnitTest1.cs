using CSharp.DanielArana.Fanalca.API.Controllers.EmployeeAPI;
using CSharp.DanielArana.Fanalca.BL.Imp.Fanalca;
using CSharp.DanielArana.Fanalca.BL.Interfaces.Fanalca;
using CSharp.DanielArana.Fanalca.BL.Interfaces.Security;
using CSharp.DanielArana.Fanalca.Entities.Fanalca;
using CSharp.DanielArana.Fanalca.Entities.Response;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Threading.Tasks;

namespace CSharp.DanielArana.Fanalca.Test
{
    [TestClass]
    public class Tests
    {

        private Mock<IDocumentTypeBL> _accionBL_Consultar = new Mock<IDocumentTypeBL>();
        private Mock<IManagementTokenBL> _managementToken = new Mock<IManagementTokenBL>();
        private Mock<IConfiguration> _configuration = new Mock<IConfiguration>();
        private Mock<IHostingEnvironment> _environment = new Mock<IHostingEnvironment>();
        private Mock<IAPIClaimBL> _Claim = new Mock<IAPIClaimBL>();
        private Mock<IAuthBL> _Auth = new Mock<IAuthBL>();
        private Task<ActionResult<Respuesta>> resultTest;


        [TestMethod]
        public void TestMethodConsultar()
        {

            Respuesta oRespuesta = new Respuesta();

            var accion = _accionBL_Consultar.Setup(y => y.Get().Result).Returns(oRespuesta);

            DocumentTypeAPIController Get =
                new DocumentTypeAPIController
                (
                     _accionBL_Consultar.Object,
                    _managementToken.Object,
                    _configuration.Object,
                    _environment.Object,
                    _Claim.Object,
                    _Auth.Object
                );

            var result = Get.Get().Result.Value;

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(result.Exito, 1);


        }
    }
}