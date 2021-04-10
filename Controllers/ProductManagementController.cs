using Newtonsoft.Json;
using Rocket_Elevators_Customer_Portal.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Rocket_Elevators_Customer_Portal.Controllers
{
    public class ProductManagementController : Controller
    {
        // GET: ProductManagement
        public async Task<ActionResult> Index()
        {
            var userName = User.Identity.Name;

            // Get customer info
            List<Customers> customers = new List<Customers>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://rocket-elevator-rest-api1.herokuapp.com/customer/" + userName))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    customers = JsonConvert.DeserializeObject<List<Customers>>(apiResponse);
                }
            }

            // Get owned buildings
            List<Buildings> allBuildings = new List<Buildings>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://rocket-elevator-rest-api1.herokuapp.com/building/CustomerId/" + customers[0].Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    allBuildings = JsonConvert.DeserializeObject<List<Buildings>>(apiResponse);
                }
            }

            // Get all batteries
            List<Batteries> allBatteries = new List<Batteries>();
            List<Batteries> batteries = new List<Batteries>();

            foreach (var building in allBuildings)
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("https://rocket-elevator-rest-api1.herokuapp.com/batteries/buildingId/" + building.Id))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        batteries = JsonConvert.DeserializeObject<List<Batteries>>(apiResponse);
                    }
                }
                foreach (var battery in batteries)
                {
                    allBatteries.Add(battery);
                }
            }

            // Get all columns
            List<Columns> allColumns = new List<Columns>();
            List<Columns> columns = new List<Columns>();

            foreach (var battery in allBatteries)
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("https://rocket-elevator-rest-api1.herokuapp.com/columns/batteriesId/" + battery.Id))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        columns = JsonConvert.DeserializeObject<List<Columns>>(apiResponse);
                    }
                }
                foreach (var column in columns)
                {
                    allColumns.Add(column);
                }
            }

            // Get all elevators
            List<Elevators> allElevators = new List<Elevators>();
            List<Elevators> elevators = new List<Elevators>();

            foreach (var column in allColumns)
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("https://rocket-elevator-rest-api1.herokuapp.com/elevators/columnId/" + column.Id))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        elevators = JsonConvert.DeserializeObject<List<Elevators>>(apiResponse);
                    }
                }
                foreach (var elevator in elevators)
                {
                    allElevators.Add(elevator);
                }
            }

            ViewBag.allBatteries = allBatteries;
            ViewBag.allColumns = allColumns;
            ViewBag.allElevators = allElevators;
            ViewBag.customerId = customers[0].Id;

            return View();
        }

        // GET: ProductManagement/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductManagement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductManagement/Create
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

        // GET: ProductManagement/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductManagement/Edit/5
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

        // GET: ProductManagement/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductManagement/Delete/5
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