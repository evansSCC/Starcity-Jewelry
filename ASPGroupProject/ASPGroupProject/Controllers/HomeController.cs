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
            List<Product> listOfProducts = ProductDA.GetAllProducts();
            List<Product> shortList = new List<Product>();

            for (int i = 0; i <=2; i++)
            {
                shortList.Add(listOfProducts[i]);
            }

            ViewBag.Message = shortList;
            
            return View();
        }

        public ActionResult Store()
        {
            List<Product> listOfProducts = ProductDA.GetAllProducts();
            List<string> Categories = new List<string>();
            foreach(Product p in listOfProducts)
            {
                if (!Categories.Contains(p.Category))
                {
                    Categories.Add(p.Category);
                }
            }
            ViewBag.Categories = Categories;
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
        public ActionResult Product_View(int id)
        {
            Product p = ProductDA.GetProductById(id);
            return View(p);
        }

        [HttpPost]
        public void add_to_cart(int id)
        {
            Product p = ProductDA.GetProductById(id);
            if(Session["Cart"] == null)
            {
                Session["Cart"] = new List<Product>();
            }

            List<Product> cart = (List<Product>)Session["Cart"];
            cart.Add(p);
            Session["Cart"] = cart;
            Response.Redirect("Store");
        }

    }
}