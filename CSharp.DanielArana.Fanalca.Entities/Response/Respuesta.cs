using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.DanielArana.Fanalca.Entities.Response
{

    public class Respuesta
    {
        public int Exito { get; set; }
        public string Menssage { get; set;}
        public object Data { get; set; }

        public Respuesta()
        {
            Exito = 0;  
        }
    }
}
