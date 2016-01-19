using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Database.Models
{
    public partial class Option
    {
        //public int OID { get; set; }
        public string Name { get; set; }
        public Enum Value { get; set; }
    }
}
