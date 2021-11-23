using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.DanielArana.Fanalca.Entities.Security
{
    public class AppSettings
    {
        public string SecretLogin { get; set; }
        public int ExpireTimeSession { get; set; }
        public string Audience { get; set; }

        public string IssuerLogin { get; set; }



        public string LoginUsuario { get; set; }

        public string PasswordUsuario { get; set; }

        public int EstadoUsuario { get; set; }
    }
}
