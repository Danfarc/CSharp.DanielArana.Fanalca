using System;
using System.Collections.Generic;

#nullable disable

namespace CSharp.DanielArana.Fanalca.Entities.Fanalca
{
    public partial class Employee
    {
        public int Id { get; set; }
        public int DocumentTypeId { get; set; }
        public string Document { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int AreaId { get; set; }
        public int SubAreaId { get; set; }
        public bool? State { get; set; }

        public virtual Area Area { get; set; }
        public virtual DocumentType DocumentType { get; set; }
        public virtual SubArea SubArea { get; set; }
    }
}
