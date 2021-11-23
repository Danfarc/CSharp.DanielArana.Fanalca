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

namespace CSharp.DanielArana.Fanalca.DAL.Fanalca
{
    public class EmployeesDAL
    {

        public static ActionResult<Respuesta> Get()
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (FanalcaContext db = new FanalcaContext())
                {
                    List<Employee> list = db.Employees.ToList();
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
                    Employee oEmployee = db.Employees.Find(Id);
                    oRespuesta.Data = oEmployee;
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

        public static ActionResult<Respuesta> Add(Employee oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (FanalcaContext db = new FanalcaContext())
                {
                    Employee oEmployee = new Employee();
                    oEmployee.DocumentTypeId = oModel.DocumentTypeId;
                    oEmployee.Document = oModel.Document;
                    oEmployee.Name = oModel.Name;
                    oEmployee.LastName = oModel.LastName;
                    oEmployee.AreaId = oModel.AreaId;
                    oEmployee.SubAreaId = oModel.SubAreaId;
                    oEmployee.State = oModel.State;
                    db.Employees.Add(oEmployee);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = oEmployee;
                }
  
            }
            catch (Exception ex)
            {
                oRespuesta.Menssage = ex.Message;
                return (oRespuesta);

            }
            return (oRespuesta);
        }

        public static ActionResult<Respuesta> Edit(Employee oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (FanalcaContext db = new FanalcaContext())
                {
                    Employee oEmployee = db.Employees.Find(oModel.Id);
                    oEmployee.DocumentTypeId = oModel.DocumentTypeId;
                    oEmployee.Document = oModel.Document;
                    oEmployee.Name = oModel.Name;
                    oEmployee.LastName = oModel.LastName;
                    oEmployee.AreaId = oModel.AreaId;
                    oEmployee.SubAreaId = oModel.SubAreaId;
                    oEmployee.State = oModel.State;
                    db.Entry(oEmployee).State = EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = oEmployee;
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
                    Employee oEmployee = db.Employees.Find(Id);
                    db.Remove(oEmployee);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data= oEmployee;
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
