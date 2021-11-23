using CSharp.DanielArana.Fanalca.DAL.Connention;
using CSharp.DanielArana.Fanalca.Entities.Fanalca;
using CSharp.DanielArana.Fanalca.Entities.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.DanielArana.Fanalca.DAL.Fanalca
{
    public class DocumentTypeDAL
    {

        public static ActionResult<Respuesta> Get()
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                AdminConexion adminConexion = new AdminConexion();

                var mensajeDeError = string.Empty;


                DataTable datos = adminConexion.ObtenerDataTable("Get_DocumentType", ref mensajeDeError);
                var lista = new List<DocumentType>();


                foreach (DataRow r in datos.Rows)
                {
                    var entidad = new DocumentType
                    {
                        Id = int.Parse(r["Id"].ToString()),
                        Name = r["Name"].ToString(),
         
                    };
                    lista.Add(entidad);
                }

                oRespuesta.Exito = 1;
                oRespuesta.Data = lista;
                return (oRespuesta);

            }
            catch (Exception ex)
            {
                oRespuesta.Menssage = ex.Message;
                return (oRespuesta);
            }
        }

        public static ActionResult<Respuesta> Get(int Id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                AdminConexion adminConexion = new AdminConexion();

                var mensajeDeError = string.Empty;

                SqlParameter[] parametrosSP =
                {
                  new SqlParameter { ParameterName = "Id", Value=Id},
                };


                DataTable datos = adminConexion.ObtenerDataTable("Get_DocumentTypeById", ref mensajeDeError, parametrosSP);
                var lista = new List<DocumentType>();


                foreach (DataRow r in datos.Rows)
                {
                    var entidad = new DocumentType
                    {
                        Id = int.Parse(r["Id"].ToString()),
                        Name = r["Name"].ToString(),

                    };
                    lista.Add(entidad);
                }

                oRespuesta.Exito = 1;
                oRespuesta.Data = lista;
                return (oRespuesta);

            }
            catch (Exception ex)
            {
                oRespuesta.Menssage = ex.Message;
                return (oRespuesta);
            }
        }

        public static ActionResult<Respuesta> Add(DocumentType oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                AdminConexion adminConexion = new AdminConexion();

                var mensajeDeError = string.Empty;

                SqlParameter[] parametrosSP =
                {
                  new SqlParameter { ParameterName = "Name", Value=oModel.Name},
                };


                DataTable datos = adminConexion.ObtenerDataTable("Post_DocumentType", ref mensajeDeError, parametrosSP);
                var lista = new List<DocumentType>();


                foreach (DataRow r in datos.Rows)
                {
                    var entidad = new DocumentType
                    {
                        Id = int.Parse(r["Id"].ToString()),
                        Name = r["Name"].ToString(),

                    };
                    lista.Add(entidad);
                }

                oRespuesta.Exito = 1;
                oRespuesta.Data = lista;
                return (oRespuesta);

            }
            catch (Exception ex)
            {
                oRespuesta.Menssage = ex.Message;
                return (oRespuesta);
            }
        }

        public static ActionResult<Respuesta> Edit(DocumentType oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                AdminConexion adminConexion = new AdminConexion();

                var mensajeDeError = string.Empty;

                SqlParameter[] parametrosSP =
                {
                  new SqlParameter { ParameterName = "Id", Value=oModel.Id},
                  new SqlParameter { ParameterName = "Name", Value=oModel.Name},
                };

                DataTable datos = adminConexion.ObtenerDataTable("Edit_DocumentType", ref mensajeDeError, parametrosSP);
                var lista = new List<DocumentType>();


                foreach (DataRow r in datos.Rows)
                {
                    var entidad = new DocumentType
                    {
                        Id = int.Parse(r["Id"].ToString()),
                        Name = r["Name"].ToString(),

                    };
                    lista.Add(entidad);
                }

                oRespuesta.Exito = 1;
                oRespuesta.Data = lista;
                return (oRespuesta);

            }
            catch (Exception ex)
            {
                oRespuesta.Menssage = ex.Message;
                return (oRespuesta);
            }
        }

        public static ActionResult<Respuesta> Delete(int Id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                AdminConexion adminConexion = new AdminConexion();

                var mensajeDeError = string.Empty;

                SqlParameter[] parametrosSP =
                {
                  new SqlParameter { ParameterName = "Id", Value=Id},
                };

                var datos = adminConexion.Ejecutar("Delete_DocumentType", ref mensajeDeError, parametrosSP);
                
                oRespuesta.Exito = 1;
                oRespuesta.Data = datos;
                return (oRespuesta);

            }
            catch (Exception ex)
            {
                oRespuesta.Menssage = ex.Message;
                return (oRespuesta);
            }
        }
    }
}
