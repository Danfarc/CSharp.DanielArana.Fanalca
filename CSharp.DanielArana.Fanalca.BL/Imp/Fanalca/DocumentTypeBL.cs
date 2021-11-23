using CSharp.DanielArana.Fanalca.BL.Interfaces;
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
    public class DocumentTypeBL : IDocumentTypeBL
    {
        public ActionResult<Respuesta> Add(DocumentType oModel)
        {
            return DocumentTypeDAL.Add(oModel);
        }

        public ActionResult<Respuesta> Delete(int Id)
        {
            return DocumentTypeDAL.Delete(Id);
        }

        public ActionResult<Respuesta> Edit(DocumentType oModel)
        {
            return DocumentTypeDAL.Edit(oModel);
        }

        public ActionResult<Respuesta> Get()
        {
            return DocumentTypeDAL.Get();
        }

        public ActionResult<Respuesta> Get(int Id)
        {
            return DocumentTypeDAL.Get(Id);
        }
    }
}
