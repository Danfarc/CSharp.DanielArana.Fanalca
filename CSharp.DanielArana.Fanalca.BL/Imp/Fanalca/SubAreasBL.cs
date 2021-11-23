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
    public class SubAreasBL : ISubAreasBL
    {
        public ActionResult<Respuesta> Add(SubArea oModel)
        {
            return SubAreasDAL.Add(oModel);
        }

        public ActionResult<Respuesta> Delete(int Id)
        {
            return SubAreasDAL.Delete(Id);
        }

        public ActionResult<Respuesta> Edit(SubArea oModel)
        {
            return SubAreasDAL.Edit(oModel);
        }

        public ActionResult<Respuesta> Get(int Id)
        {
            return SubAreasDAL.Get(Id);
        }

        ActionResult<Respuesta> ISubAreasBL.Get()
        {
            return SubAreasDAL.Get();
        }
    }
}
