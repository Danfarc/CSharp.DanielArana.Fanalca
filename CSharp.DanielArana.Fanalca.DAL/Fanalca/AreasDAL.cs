using CSharp.DanielArana.Fanalca.DAL.Connention;
using CSharp.DanielArana.Fanalca.Entities.Fanalca;
using CSharp.DanielArana.Fanalca.Entities.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CSharp.DanielArana.Fanalca.DAL.Fanalca
{
    public class AreasDAL
    {
        public static ActionResult<Respuesta> Get()
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (FanalcaContext db = new FanalcaContext())
                {
                    List<Area> list = db.Areas.ToList();
                    oRespuesta.Data = list;
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Menssage = ex.Message;
                return (oRespuesta);
            }

            return oRespuesta;
        }

        public static ActionResult<Respuesta> Get(int Id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (FanalcaContext db = new FanalcaContext())
                {
                    Area oArea = db.Areas.Find(Id);
                    oRespuesta.Data = oArea;
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Menssage = ex.Message;
                return (oRespuesta);
            }

            return oRespuesta;
        }

        public static ActionResult<Respuesta> Add(Area oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (FanalcaContext db = new FanalcaContext())
                {
                    Area oArea = new Area();
                    oArea.Name = oModel.Name;
                    oArea.State = oModel.State;
                    oArea.Name = oModel.Name;
                    db.Areas.Add(oArea);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = oArea;
                }

            }
            catch (Exception ex)
            {
                oRespuesta.Menssage = ex.Message;
                return (oRespuesta);

            }
            return (oRespuesta);
        }

        public static ActionResult<Respuesta> Edit(Area oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (FanalcaContext db = new FanalcaContext())
                {
                    Area oArea = db.Areas.Find(oModel.Id);
                    oArea.Name = oModel.Name;
                    oArea.State = oModel.State;
                    oArea.Name = oModel.Name;
                    db.Entry(oArea).State = EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = oArea;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Menssage = ex.Message;
                return (oRespuesta);

            }
            return (oRespuesta);
        }

        public static ActionResult<Respuesta> Delete(int Id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (FanalcaContext db = new FanalcaContext())
                {
                    Area oArea = db.Areas.Find(Id);
                    db.Remove(oArea);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = oArea;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Menssage = ex.Message;
                return (oRespuesta);

            }
            return (oRespuesta);
        }
    }
}
