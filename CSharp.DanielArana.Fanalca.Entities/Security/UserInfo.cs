using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.DanielArana.Fanalca.Entities.Security
{
    public class UserInfo
    {
        public string login { get; set; }
        public bool estado { get; set; }
        public string token { get; set; }
        public DateTime expiration { get; set; }
    }
}
