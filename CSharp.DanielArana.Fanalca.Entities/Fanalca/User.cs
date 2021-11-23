using System;
using System.Collections.Generic;

#nullable disable

namespace CSharp.DanielArana.Fanalca.Entities.Fanalca
{
    public partial class User
    {
        public int Id { get; set; }
        public string Nameuser { get; set; }
        public string Password { get; set; }
        public bool? State { get; set; }
    }
}
