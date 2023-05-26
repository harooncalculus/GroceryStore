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
    public class ProdCategoryManagementController : ControllerBase
    {
        private readonly DataContext _db;
        private readonly ILogger<ProdCategoryManagementController> _logger;
        public ProdCategoryManagementController(ILogger<ProdCategoryManagementController> logger)
        {
            _logger = logger;
            _db = new DataContext();

        }
        [HttpPost]
        [Route("~/api/AddProductCategory")]
        public void AddProductCategory(string supplierjson)
        {

            //OrderResponse oresponse = null;
            try
            {
                Prod_categoryManagement Prod_Cat = JsonConvert.DeserializeObject<Prod_categoryManagement>(supplierjson);
                if (!string.IsNullOrEmpty(Prod_Cat.Name))
                {
                    GSDatabaseManager gsMgmt = new GSDatabaseManager(_db);
                    gsMgmt.AddorUpdateSupplier(Prod_Cat);
                }
            }
            catch (Exception ex)
            {
            }
            //return oresponse;
        }
    }
}
