using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Api.DataAccessLayer.Models
{
    public class prod_inventoryManagement
    {
        public int? ID { get; set; }
        public int Prod_ID { get; set; }
        public decimal Quantity_balance { get; set; }
        public int Sup_ID { get; set; }
        public string DOP { get; set; }
        public string DOS { get; set; }
        public decimal Qty_Purchase { get; set; }
        public decimal Qty_Sell { get; set; }
        public decimal Purchase_Price { get; set; }
    }
}
