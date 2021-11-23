using CSharp.DanielArana.Fanalca.BL.Interfaces.Security;
using CSharp.DanielArana.Fanalca.DAL.Security;
using CSharp.DanielArana.Fanalca.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.DanielArana.Fanalca.BL.Imp.Security
{
    public class AuthBL : IAuthBL
    {
        public async Task<UserInfo> Authorize(LoginEntity objLogin)
        {
            return await AuthDAL.Authorize(objLogin);
        }
    }
}
