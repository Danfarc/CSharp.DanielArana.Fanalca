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
    public class SubAreasDAL
    {
        public static ActionResult<Respuesta> Get()
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (FanalcaContext db = new FanalcaContext())
                {
                    List<SubArea> list = db.SubAreas.ToList();
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
                    SubArea oSubArea = db.SubAreas.Find(Id);
                    oRespuesta.Data = oSubArea;
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

        public static ActionResult<Respuesta> Add(SubArea oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (FanalcaContext db = new FanalcaContext())
                {
                    SubArea oSubArea = new SubArea();
                    oSubArea.AreaId = oModel.AreaId;
                    oSubArea.State = oModel.State;
                    oSubArea.Name = oModel.Name;
                    db.SubAreas.Add(oSubArea);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = oSubArea;
                }

            }
            catch (Exception ex)
            {
                oRespuesta.Menssage = ex.Message;
                return (oRespuesta);

            }
            return (oRespuesta);
        }

        public static ActionResult<Respuesta> Edit(SubArea oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (FanalcaContext db = new FanalcaContext())
                {
                    SubArea oSubArea = db.SubAreas.Find(oModel.Id);
                    oSubArea.Name = oModel.Name;
                    oSubArea.State = oModel.State;
                    oSubArea.AreaId = oModel.AreaId;
                    db.Entry(oSubArea).State = EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = oSubArea;
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
                    SubArea oArea = db.SubAreas.Find(Id);
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
