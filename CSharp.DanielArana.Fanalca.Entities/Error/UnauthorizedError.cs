using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.DanielArana.Fanalca.Entities.Error
{
    public class UnauthorizedError:ApiError
    {
        public UnauthorizedError(): base(401, HttpStatusCode.Unauthorized.ToString())
        {
        }

        public UnauthorizedError(string message): base(401, HttpStatusCode.Unauthorized.ToString(), message)
        {
        }
    }
}
