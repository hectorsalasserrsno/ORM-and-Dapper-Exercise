using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    public class Product
    {
        public int ProductID { get; set; }

        public string Name { get; set; }

        public string Price { get; set; }
        public string CategoryID { get; set; }

        public string OnSale { get; set; }

        public string StockLevel { get; set; }


    }
}
