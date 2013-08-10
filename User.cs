using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spankomatic
{
    public class User
    {
        public int id { get; set; }
        public string login { get; set; }
        public string realName { get; set; }

        public override string ToString()
        {
            return realName + " (" + login + ")";
        }

        public bool Equals(User other)
        {
            return this.id == other.id;
        }
    }
}
