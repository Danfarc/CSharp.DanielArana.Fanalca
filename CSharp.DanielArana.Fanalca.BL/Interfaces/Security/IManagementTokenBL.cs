using CSharp.DanielArana.Fanalca.Entities.Security;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.DanielArana.Fanalca.BL.Interfaces.Security
{
    public interface IManagementTokenBL
    {
        string BuildToken(IEnumerable<Claim> claims);
        string GenerateToken(UserInfo user);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        TokenValidationParameters GetValidationParameters();
    }
}
