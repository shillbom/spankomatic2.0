using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Spankomatic
{
    public class Inkop
    {
        public int id {get; set;}
        public DateTime date { get; set; }
        public string article {get; set;}
        public string quantity {get; set;}
        public bool purchased {get; set;}
    }
}
