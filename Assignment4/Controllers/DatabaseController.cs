using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment4.DataAccess;
using Assignment4.Models;

namespace MVC_EF_Start.Controllers
{
    public class DatabaseExampleController : Controller
    {
        public ApplicationDbContext dbContext;

        public DatabaseExampleController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ViewResult> DatabaseOperations()
        {
            // CREATE operation
            StgData MyData = new StgData();

            dbContext.StgModels.Add(MyData);

            dbContext.SaveChanges();

            // READ operation
            StgData CompanyRead1 = dbContext.StgModels
                                    .Where(c => c.provider_city == "DOTHAN")
                                    .First();
/*
            // UPDATE operation
            CompanyRead1.iexId = "MCOB";
            dbContext.Companies.Update(CompanyRead1);
            //dbContext.SaveChanges();
            await dbContext.SaveChangesAsync();

            // DELETE operation
            dbContext.Companies.Remove(CompanyRead1);
            await dbContext.SaveChangesAsync();
*/
            return View();
        }
    }
}