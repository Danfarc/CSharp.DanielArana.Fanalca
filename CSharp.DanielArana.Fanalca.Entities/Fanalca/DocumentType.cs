using System;
using System.Collections.Generic;

#nullable disable

namespace CSharp.DanielArana.Fanalca.Entities.Fanalca
{
    public partial class DocumentType
    {
        public DocumentType()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
