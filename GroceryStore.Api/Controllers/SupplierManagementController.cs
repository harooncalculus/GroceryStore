using GroceryStore.Api.DataAccessLayer;
using GroceryStore.Api.DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;

namespace GroceryStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierManagementController : ControllerBase
    {
        private readonly DataContext _db;
        private readonly ILogger<SupplierManagementController> _logger;
        public SupplierManagementController(ILogger<SupplierManagementController> logger)
        {
            _logger = logger;
            _db = new DataContext();

        }
        [HttpPost]
        [Route("~/api/AddSupplier")]
        public void AddSupplier(string supplierjson)
        {

            //OrderResponse oresponse = null;
            try
            {
                SupplierManangement supplier = JsonConvert.DeserializeObject<SupplierManangement>(supplierjson);
                if (!string.IsNullOrEmpty(supplier.Name) &&
                    !string.IsNullOrEmpty(supplier.Phone) &&
                    !string.IsNullOrEmpty(supplier.Bank)
                    )
                {
                    GSDatabaseManager gsMgmt = new GSDatabaseManager(_db);
                    gsMgmt.AddorUpdateSupplier(supplier);
                }
            }
            catch (Exception ex)
            {
            }
            //return oresponse;
        }
        [HttpPost]
        [Route("~/api/deletesupplier")]
        public void DeleteSupplier(int id)
        {
            try
            {


                GSDatabaseManager gsMgmt = new GSDatabaseManager(_db);
                gsMgmt.DeleteSupplierbyId(id);

            }
            catch (Exception ex)
            {
            }
        }
    }
}
