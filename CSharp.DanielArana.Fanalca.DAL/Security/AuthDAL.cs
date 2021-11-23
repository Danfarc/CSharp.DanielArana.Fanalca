using Csharp.DanielArana.Fanalca.Utility;
using CSharp.DanielArana.Fanalca.Entities.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.DanielArana.Fanalca.DAL.Security
{
    public static class AuthDAL
    {
        public static async Task<UserInfo> Authorize(LoginEntity objLogin)
        {
            try
            {
                var userInfo = new UserInfo();
                string LoginUsuario = string.Empty;

                using (SqlConnection conn = new SqlConnection(ApiConnectionStrings.ConnectionStrinDB))
                {
                    SqlCommand cmd = new SqlCommand("dbo.GetUsername", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", objLogin.Username);

                    try
                    {
                        await conn.OpenAsync();
                        SqlDataReader Rd = await cmd.ExecuteReaderAsync();
                        while (Rd.Read())
                        {
                            userInfo.login = Rd.GetString("Nameuser").ToString();
                            userInfo.estado = Convert.ToBoolean(Rd.GetBoolean("State"));
                        }
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                return userInfo;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }




        }
    }
}
