using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spankomatic
{
    public class Article
    {
        public int id;
        public string EAN;
        public string name;
        public int categoryId;
        public string comment;
        public int price;          //Försäljningspris
        public int cost;           //Inköpspris
        public int internalPrice;   //Internfaktureringspris
        public bool forSale;
        public int nbrPerPack;
    }
}
