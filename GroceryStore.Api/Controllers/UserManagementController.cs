using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryStore.Api.DataAccessLayer;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using GroceryStore.Api.DataAccessLayer.Models;
using Newtonsoft.Json;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GroceryStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        //// GET: api/<UserManagementController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<UserManagementController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<UserManagementController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<UserManagementController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<UserManagementController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
        private readonly DataContext _db;
        private readonly ILogger<UserManagementController> _logger;
        public UserManagementController(ILogger<UserManagementController> logger)
        {
            _logger = logger;
            _db = new DataContext();
           
        }
        private HttpClient GetHttpClient(string endpointURL, string accessToken)
        {

            HttpClientHandler handler = new HttpClientHandler() { UseDefaultCredentials = false };
            HttpClient client = new HttpClient(handler);

            try
            {
                client.BaseAddress = new Uri(endpointURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return client;
        }
        [HttpPost]
        [Route("~/api/AddUser")]
        public void AddUser(string userjson)
        {
            
            //OrderResponse oresponse = null;
            try
            {
                UserManagement user = JsonConvert.DeserializeObject<UserManagement>(userjson);
                if (!string.IsNullOrEmpty(user.EmailID) &&
                    !string.IsNullOrEmpty(user.Password) &&
                    !string.IsNullOrEmpty(user.Name)
                    )
                {
                    GSDatabaseManager gsMgmt = new GSDatabaseManager(_db);
                    gsMgmt.AddorUpdateUser(user);
                }
            }
            catch (Exception ex)
            {
            }
            //return oresponse;
        }
        [HttpPost]
        [Route("~/api/deleteuser")]
        public void DeleteUser(int id)
        {
            try
            {
                
               
                    GSDatabaseManager gsMgmt = new GSDatabaseManager(_db);
                    gsMgmt.DeleteUser(gsMgmt.GetUserById(id));
                
            }
            catch (Exception ex)
            {
            }
        }
    }
}
