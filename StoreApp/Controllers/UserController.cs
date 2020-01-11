using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using BLL;

namespace StoreApp.Controllers
{
    public class UserController : Controller
    {
        // GET: Login
        public ActionResult Login() { 
            User model = new User();
            return View(model);
        }


        // GET: Logout
        public ActionResult Logout() {
            User model = new User();
            Session["user"] = null;
            ViewData["LoggedIn"] = "false";
            return RedirectToAction("login", "User");
        }

        // GET: Register
        public ActionResult Register() {

            return View();
        }

        // POST: Register
        [HttpPost]
        public ActionResult Register(string email, string password, string username) {
            Boolean status = UserService.RegisterUser(email, password, username);
            if (status == true) {
                ViewData["status"] = "Registered Succesfully";
                return RedirectToAction("Login", "User");
            }else {
                ViewData["status"] = "Registration Faied";
                return View();
            }
        }


        // POST: User
        [HttpPost]
        public ActionResult Login(string email, string password) {
            User user = UserService.ValidateUser(email, password);
            if (user != null) {
                ViewData["LoggedIn"] = "true";
                Session["user"] = user;
                return RedirectToAction("Index", "Pizza");
            }
            ViewData["status"] = "Invalid email or password";
            return View();
        }


        // Add to Cart
        public ActionResult AddToCart(Pizza pizza) {
            ((List<Pizza>)Session["cart"]).Add(pizza);
            return RedirectToAction("Index", "Pizza");
        }

        // View Cart
        public ActionResult ViewCart() {
            List<Pizza> model = (List<Pizza>)Session["cart"];
            return View(model);
        }
    }
}