using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : TechJobsController
    {
        public IActionResult Index()
        {
           
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results

        public IActionResult Results(string searchType, string searchTerm)
        {
            if ((!searchType.Equals("all") && searchTerm == null) || 
                (searchTerm != null && searchTerm.Trim() == null) )
            {
                ViewBag.error = "Not a valid entry, please try again";
                return View("Index");
            }
            else if (searchType.Equals("all") && searchTerm == null)
            {
                List<Dictionary<string, string>> jobs = JobData.FindAll();
                ViewBag.columns = ListController.columnChoices;
                ViewBag.jobs = jobs;
                ViewBag.searchTerm = searchTerm;
                return View("Index");
            }
            else if (searchType.Equals("all"))
            {
                List<Dictionary<string, string>> jobs = JobData.FindByValue(searchTerm);
                {
                    ViewBag.columns = ListController.columnChoices;
                    ViewBag.jobs = jobs;
                    ViewBag.searchTerm = searchTerm;
                    return View("Index");
                }
            }
            else
            {
                List<Dictionary<string, string>> jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.columns = ListController.columnChoices;
                ViewBag.jobs = jobs;
                ViewBag.searchTerm = searchTerm;
                return View("Index");
            }
         }
        
        
    }
}
