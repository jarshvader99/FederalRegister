using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PatriotVision.Models.Agencies;
using PatriotVision.Models.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PatriotVision.Controllers.Agencies
{
    public class AgenciesController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<AgenciesModel> agenciesInfo = new List<AgenciesModel>();
            string Baseurl = "https://localhost:44326/";
            var agenciesResponse = "";
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("https://www.federalregister.gov/api/v1/agencies");
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    agenciesResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Model
                    agenciesInfo = JsonConvert.DeserializeObject<List<AgenciesModel>>(agenciesResponse);
                }
            }

            return View(agenciesInfo);
        }
    }
}
