using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spankomatic
{
    public class Sale
    {
        public int articleID    //varuID
        {
            get;
            set;
        }

        public int price    //Försäljningspriset
        {
            get;
            set;
        }

        public int cost     //Inköpspriset
        {
            get;
            set;
        }

        public bool arbetsGladje    //true om arbetsglädje
        {
            get;
            set;
        }
    }
}
