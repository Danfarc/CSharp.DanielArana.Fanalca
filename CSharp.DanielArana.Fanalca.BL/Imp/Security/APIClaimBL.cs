using CSharp.DanielArana.Fanalca.BL.Interfaces.Security;
using CSharp.DanielArana.Fanalca.Entities.Security;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.DanielArana.Fanalca.BL.Imp.Security
{
    public class APIClaimBL : IAPIClaimBL
    {
        ///  

        private readonly IHttpContextAccessor _ContextAccessor;

        public APIClaimBL(IHttpContextAccessor contextAccessor)
        {
            _ContextAccessor = contextAccessor;
        }


        private APIClaimModel Claims(IEnumerable<Claim> claims)
        {
            return new APIClaimModel
            {
                Login = claims.Any() ? claims.SingleOrDefault(c => c.Type == "login").Value : string.Empty,
                CodSer = claims.Any() ? claims.SingleOrDefault(c => c.Type == "codigofacturacion").Value : string.Empty,
                IdCliente = claims.Any() ? claims.SingleOrDefault(c => c.Type == "idcliente").Value : string.Empty,
            };
        }

        public string Login
        {
            get
            {
                return Claims(_ContextAccessor.HttpContext.User.Claims).Login;
            }
        }

        public string CodSer
        {
            get
            {
                return Claims(_ContextAccessor.HttpContext.User.Claims).CodSer;
            }
        }

        public string IdCliente
        {
            get
            {
                return Claims(_ContextAccessor.HttpContext.User.Claims).IdCliente;
            }
        }


    }
}
