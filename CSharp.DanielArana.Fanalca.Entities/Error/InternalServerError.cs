using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.DanielArana.Fanalca.Entities.Error
{
    public class InternalServerError : ApiError
    {
        public new static int StatusCode { get; } = 500;
        public static int StatusCodeModel { get; } = 400;

        public InternalServerError() : base(500, HttpStatusCode.InternalServerError.ToString())
        {
        }

        public InternalServerError(Exception exception, string username) : base(500, HttpStatusCode.InternalServerError.ToString(), exception.Message)
        {
        }
    }
}