using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HangfirePOC.Web.Controllers
{
    public class WorkController : Controller
    {
        // GET: Work
        public ActionResult Index()
        {
            //BackgroundJob.Enqueue(() => Console.Write("Lock dog")); 
            return View(); 
        }
    }
}