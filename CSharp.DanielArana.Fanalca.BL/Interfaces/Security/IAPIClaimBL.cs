using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.DanielArana.Fanalca.BL.Interfaces.Security
{
    public interface IAPIClaimBL
    {
        string Login { get; }
        string CodSer { get; }
        string IdCliente { get; }
    }
}
