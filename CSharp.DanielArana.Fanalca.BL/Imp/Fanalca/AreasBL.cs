using CSharp.DanielArana.Fanalca.BL.Interfaces;
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
    public class AreasBL : IAreasBL
    {
        public ActionResult<Respuesta> Add(Area oModel)
        {
            return AreasDAL.Add(oModel);
        }

        public ActionResult<Respuesta> Delete(int Id)
        {
            return AreasDAL.Delete(Id);
        }

        public ActionResult<Respuesta> Edit(Area oModel)
        {
            return AreasDAL.Edit(oModel);
        }

        public ActionResult<Respuesta> Get(int Id)
        {
            return AreasDAL.Get(Id);
        }

        ActionResult<Respuesta> IAreasBL.Get()
        {
            return AreasDAL.Get();
        }
    }
}
