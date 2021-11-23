using CSharp.DanielArana.Fanalca.Entities.Fanalca;
using CSharp.DanielArana.Fanalca.Entities.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.DanielArana.Fanalca.BL.Interfaces.Fanalca
{
    public interface IEmployeesBL
    {
        public ActionResult<Respuesta> Get();
        public ActionResult<Respuesta> Get(int Id);
        public ActionResult<Respuesta> Add(Employee oModel);
        public ActionResult<Respuesta> Edit(Employee oModel);
        public ActionResult<Respuesta> Delete(int Id);
    }
}
