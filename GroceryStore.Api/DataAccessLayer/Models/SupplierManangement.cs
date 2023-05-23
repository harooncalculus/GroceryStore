using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Api.DataAccessLayer.Models
{
    public class SupplierManangement
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string GST { get; set; }
        public string AccountNumber { get; set; }
        public string Bank { get; set; }
        public string IFSC_Code { get; set; }
        public string PaymentID { get; set; }

    }
}
