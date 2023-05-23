using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Api.DataAccessLayer.Models
{
    public class UserManagement
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string EmailID { get; set; }
        public DateTime DOJ { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string NationalId { get; set; }

    }
}
