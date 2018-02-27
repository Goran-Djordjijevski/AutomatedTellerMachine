using AutomatedTellerMachine.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutomatedTellerMachine.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var checkingAccountId = db.CheckingAccounts.Where(c => c.ApplicationUserId == userId).FirstOrDefault();

            ViewBag.CheckingAccountId = checkingAccountId;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Having trouble? Send us a message.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(string message)
        {
            ViewBag.Message = "Thanks, we got your message!";

            return View();
        }

        public ActionResult Foo()
        {
            return View(viewName: "About");
        }

        public ActionResult Serial(string letterCase)
        {
            string serial = "ASPNETMVC5";

            if (letterCase == "lower")
            {
                return Content(serial.ToLower());
            }

            return Content(serial);
        }
    }
}