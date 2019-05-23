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
            List<Product> listOfProducts = new List<Product>();

            listOfProducts.Add(new Product("test name 1", "sample description 1", "sample category 1", 35.00m, "..\\Images\\Products\\B114\\B114_Alt1.jpg", 3));
            listOfProducts.Add(new Product("test name 2", "sample description 2", "sample category 2", 55.00m, "..\\Images\\Products\\B130\\B130_Alt.jpg", 5));
            listOfProducts.Add(new Product("test name 3", "sample description 3", "sample category 3", 15.00m, "..\\Images\\Products\\N106\\N106_Main.jpg", 18));
            listOfProducts.Add(new Product("test name 4", "sample description 4", "sample category 4", 60.00m, "..\\Images\\Products\\N147\\N147_Alt.jpg", 7));
            listOfProducts.Add(new Product("test name 5", "sample description 5", "sample category 5", 10.00m, "..\\Images\\Products\\S001\\S001_Alt1.jpg", 2));

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