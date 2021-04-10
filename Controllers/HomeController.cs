using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Rocket_Elevators_Customer_Portal.Models;
using Newtonsoft.Json;

namespace Rocket_Elevators_Customer_Portal.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var userName = User.Identity.Name;
            
            List<Customers> customers = new List<Customers>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://rocket-elevator-rest-api1.herokuapp.com/customer/" + userName))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    System.Diagnostics.Debug.WriteLine("--------------------------api Response---------------------");
                    System.Diagnostics.Debug.WriteLine(apiResponse);
                    customers = JsonConvert.DeserializeObject<List<Customers>>(apiResponse);
                }
            }
            System.Diagnostics.Debug.WriteLine("--------------------------customers---------------------");
            System.Diagnostics.Debug.WriteLine(customers);
            return View(customers);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}