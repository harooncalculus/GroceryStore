using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Api.DataAccessLayer.Models
{
    public class Prod_PriceManagement
    {
        public int? ID { get; set; }
        public int Prod_ID { get; set; }
        public decimal Price { get; set; }
    }
}
