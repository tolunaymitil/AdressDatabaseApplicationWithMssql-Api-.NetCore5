using AdressDatabaseApplicationWithMssql_Api_.NetCore5.DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DatabaseApiFront.Controllers
{
    public class DefaultController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:5001/api/Default");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Class1>>(jsonString);
            return View(values);
        }
    }
    public class Class1
    {
        public int AddressID { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string FullAddress { get; set; }
        public int PersonID { get; set; }
        public virtual Person Person { get; set; }
    }
    
}