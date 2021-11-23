using System;
using System.Collections.Generic;

#nullable disable

namespace CSharp.DanielArana.Fanalca.Entities.Fanalca
{
    public partial class Area
    {
        public Area()
        {
            Employees = new HashSet<Employee>();
            SubAreas = new HashSet<SubArea>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? State { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<SubArea> SubAreas { get; set; }
    }
}
