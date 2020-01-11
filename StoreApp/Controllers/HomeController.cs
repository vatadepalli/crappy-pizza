using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace StoreApp.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            if(Session["user"] == null) {
                return RedirectToAction("Login", "User");
            }
            else {
                return RedirectToAction("Index", "Pizza");
            }
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}