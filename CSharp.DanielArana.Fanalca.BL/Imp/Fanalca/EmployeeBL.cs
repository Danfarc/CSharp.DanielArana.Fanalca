using CSharp.DanielArana.Fanalca.BL.Interfaces.Fanalca;
using CSharp.DanielArana.Fanalca.DAL.Fanalca;
using CSharp.DanielArana.Fanalca.Entities.Fanalca;
using CSharp.DanielArana.Fanalca.Entities.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.DanielArana.Fanalca.BL.Imp.Fanalca
{
    public class EmployeesBL : IEmployeesBL
    {
        public ActionResult<Respuesta> Add(Employee oModel)
        {
            return EmployeesDAL.Add(oModel);
        }

        public ActionResult<Respuesta> Delete(int Id)
        {
            return EmployeesDAL.Delete(Id);
        }

        public ActionResult<Respuesta> Edit(Employee oModel)
        {
            return EmployeesDAL.Edit(oModel);
        }

        public ActionResult<Respuesta> Get(int Id)
        {
            return EmployeesDAL.Get(Id);
        }

        ActionResult<Respuesta> IEmployeesBL.Get()
        {
            return EmployeesDAL.Get();
        }
    }
}
