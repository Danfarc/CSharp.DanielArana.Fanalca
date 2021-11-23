using CSharp.DanielArana.Fanalca.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.DanielArana.Fanalca.BL.Interfaces.Security
{
    public interface IAuthBL
    {
        Task<UserInfo> Authorize(LoginEntity objLogin);
    }
}
