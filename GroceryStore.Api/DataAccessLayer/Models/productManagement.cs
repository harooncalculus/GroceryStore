using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Api.DataAccessLayer.Models
{
    public class productManagement
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public int Category_ID
        {
            get; set;
        }
}
