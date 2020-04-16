using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Assignment4.Models;
using Assignment4.APIHandlerManager;
using Assignment4.DataAccess;

namespace Assignment4.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext dbContext;
        public HomeController(ApplicationDbContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DataView()
        {
            APIHandler webHandler = new APIHandler();
            GenData result = webHandler.GetGenData();
            
            foreach(var item in result.data)
            {
                HospitalData MyData = new HospitalData();
                MyData.drg_definition = item.drg_definition;
                MyData.provider_id = item.provider_id;
                MyData.provider_name = item.provider_name;
                MyData.provider_city = item.provider_city;
                MyData.provider_state = item.provider_state;
                MyData.provider_street_address = item.provider_street_address;
                MyData.provider_zip_code = item.provider_zip_code;
                MyData.hospital_referral_region_description = item.hospital_referral_region_description;
                MyData.total_discharges = item.total_discharges;
                MyData.average_covered_charges = item.average_covered_charges;
                MyData.average_medicare_payments = item.average_medicare_payments;
                MyData.average_medicare_payments_2 = item.average_medicare_payments_2;
                dbContext.StgModel.Add(MyData);
            }
            
            dbContext.SaveChanges();

            return View(result);
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
