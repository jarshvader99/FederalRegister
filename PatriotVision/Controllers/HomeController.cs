using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PatriotVision.Models;
using PatriotVision.Models.Documents;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PatriotVision.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            DocumentsModel documentsInfo = new DocumentsModel();
            string Baseurl = "https://localhost:44326/";
            var documentsResponse = "";
                using (var client = new HttpClient())
                {
                    //Passing service base url  
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //Sending request to find web api REST service resource using HttpClient  
                    HttpResponseMessage Res = await client.GetAsync("https://www.federalregister.gov/api/v1/documents.json?per_page=20&order=newest");
                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        documentsResponse = Res.Content.ReadAsStringAsync().Result;
                        //Deserializing the response recieved from web api and storing into the Model
                        documentsInfo = JsonConvert.DeserializeObject<DocumentsModel>(documentsResponse);
                }
            }
            return View(documentsInfo);
        }

        public async Task<IActionResult> NextPage(string page)
        {
            DocumentsModel documentsInfo = new DocumentsModel();
            string Baseurl = "https://localhost:44326/";
            var documentsResponse = "";
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("https://www.federalregister.gov/api/v1/documents?format=json&order=newest&page=" + page + "&per_page=20");
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    documentsResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Model
                    documentsInfo = JsonConvert.DeserializeObject<DocumentsModel>(documentsResponse);
                }
            }
            return View(documentsInfo);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
