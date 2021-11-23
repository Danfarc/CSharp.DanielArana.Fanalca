using Csharp.DanielArana.Fanalca.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.DanielArana.Fanalca.DAL.Connention
{
    public class AdminConexion
    {
        public string cadenaConexion = string.Empty;

        public int Ejecutar(string procedimiento, ref string mensajeDeError, SqlParameter[] parametros = null)
        {
            
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(procedimiento, ApiConnectionStrings.ConnectionStrinDB);
            int exitoso = 0;

            try
            {
                sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                if (parametros != null)
                {
                    sqlDataAdapter.SelectCommand.Parameters.AddRange(parametros);
                }

                sqlDataAdapter.SelectCommand.Connection.Open();
                DataTable t = new DataTable();
                var result = sqlDataAdapter.Fill(t).ToString();

                exitoso = Convert.ToInt32(result);

            }
            catch (Exception excepcion)
            {
                mensajeDeError = excepcion.Message;
            }

            return exitoso;
        }


        public DataTable ObtenerDataTable(string procedimiento, ref string mensajeDeError, SqlParameter[] parametros = null)
        {
            DataTable datos = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(procedimiento, ApiConnectionStrings.ConnectionStrinDB);

            try
            {
                sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                if (parametros != null)
                {
                    sqlDataAdapter.SelectCommand.Parameters.AddRange(parametros);
                }
                sqlDataAdapter.SelectCommand.Connection.Open();
                sqlDataAdapter.Fill(datos);
            }
            catch (Exception excepcion)
            {
                mensajeDeError = excepcion.Message;
            }
            finally
            {
                sqlDataAdapter.SelectCommand.Connection.Close();
                sqlDataAdapter.SelectCommand.Dispose();
            }
            return datos;
        }

    }
}
