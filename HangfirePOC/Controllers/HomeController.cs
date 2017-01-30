using HangfirePOC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HangfirePOC.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork _uof;

        public HomeController(IUnitOfWork uof)
        {
            _uof = uof;
        }

        public ActionResult Index()
        {
            var activities = _uof.ActivityRepo.FindAll();

            return View(activities);
        }
    }
}