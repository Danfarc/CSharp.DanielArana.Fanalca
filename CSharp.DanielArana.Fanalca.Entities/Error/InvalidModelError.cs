using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.DanielArana.Fanalca.Entities.Error
{
    public class InvalidModelError : ApiError
    {
        public InvalidModelError(object modelState) : base(400, HttpStatusCode.BadRequest.ToString(), modelState)
        {

        }
    }
}
