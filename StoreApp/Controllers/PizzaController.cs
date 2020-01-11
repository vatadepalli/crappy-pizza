using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using BLL;

namespace StoreApp.Controllers
{
    public class PizzaController : Controller
    {
        // GET: Pizza
        public ActionResult Index()
        {
            List<Pizza> pizzas = PizzaService.GetAllPizzas();
            ViewData["username"] = ((User)Session["user"]).Username;
            ViewData["isAdmin"] = ((User)Session["user"]).Role;
            return View(pizzas);
        }
    }
}