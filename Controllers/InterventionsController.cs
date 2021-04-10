using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rocket_Elevators_Customer_Portal.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Rocket_Elevators_Customer_Portal.Controllers
{
    public class InterventionsController : Controller
    {
        // GET: Interventions
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

    

        // GET: Interventions/Details/5

        public ActionResult get()
        {
            return View();
        }
        //public async Task<IActionResult> GetCustomerID()
        //{
        //    string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        //    var httpClient = new HttpClient();
        //    var response = await httpClient.GetAsync($"https://rocket-elevator-rest-api1.herokuapp.com/customer/{userName}");
        //    var customer = new Customers();

        //    return View();
        //}

        // GET: Interventions/Create
        [Route("Interventions/Create")]
        public async Task<ActionResult> Create()
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
            

        // POST: Interventions/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Interventions/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Interventions/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Interventions/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Interventions/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
