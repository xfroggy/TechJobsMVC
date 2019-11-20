using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobs.Controllers
{
    public class TechJobsController : Controller
    {
        internal static Dictionary<string, string> actionChoices = new Dictionary<string, string>();

        // This is a "static constructor" which can be used
        // to initialize static members of a class
        static TechJobsController() 
        {
            actionChoices.Add("search", "Search");
            actionChoices.Add("list", "List");
        }


        public override ViewResult View()
        {
            ViewBag.choices = actionChoices;
            ViewBag.actions = actionChoices; 
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return base.View();
        }

        public override ViewResult View(string viewName)
        {
            ViewBag.choices = actionChoices;
            ViewBag.actions = actionChoices;
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return base.View(viewName);
        }
    }
}
