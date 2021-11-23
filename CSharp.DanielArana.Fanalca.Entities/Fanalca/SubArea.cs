using System;
using System.Collections.Generic;

#nullable disable

namespace CSharp.DanielArana.Fanalca.Entities.Fanalca
{
    public partial class SubArea
    {
        public SubArea()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public int AreaId { get; set; }
        public string Name { get; set; }
        public bool? State { get; set; }

        public virtual Area Area { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
