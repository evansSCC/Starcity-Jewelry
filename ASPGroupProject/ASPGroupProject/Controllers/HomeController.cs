using ASPGroupProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPGroupProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Store()
        {
            List<Product> listOfProducts = ProductDA.GetAllProducts();

            ViewBag.Message = listOfProducts;
            return View();
        }
        public ActionResult Shopping_Cart()
        {
            return View();
        }
        public ActionResult Checkout()
        {
            return View();
        }
        public ActionResult Contact_Us()
        {
            return View();
        }
        public ActionResult User_Profile()
        {
            return View();
        }
        public ActionResult Product_View()
        {
            return View();
        }

    }
}