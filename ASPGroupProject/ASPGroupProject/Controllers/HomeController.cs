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
            List<Product> products = new List<Product>();
            double tax = 0.07;
            double totalNoTax = 0;
            if (Session["Cart"] != null)
            {
                products = (List<Product>)Session["Cart"];
                foreach(Product p in products)
                {
                    totalNoTax += Convert.ToDouble(p.Price);
                }
            }
            ViewBag.totalNoTax = totalNoTax;
            ViewBag.Taxes = totalNoTax * tax;
            ViewBag.Total = totalNoTax + ViewBag.Taxes;
            ViewBag.Products = products;
            return View();
        }
        public ActionResult Contact_Us()
        {
            return View();
        }
        public ActionResult User_Profile()
        {
            User u = UserDA.GetUserById(4);
            ViewBag.Message = u;

            return View();
        }
        public ActionResult Product_View(int id)
        {
            Product p = ProductDA.GetProductById(id);
            return View(p);
        }

        [HttpPost]
        public ActionResult add_to_cart(int id)
        {
            List<Product> listOfProducts = ProductDA.GetAllProducts();
            List<string> Categories = new List<string>();
            foreach (Product p in listOfProducts)
            {
                if (!Categories.Contains(p.Category))
                {
                    Categories.Add(p.Category);
                }
            }
            ViewBag.Categories = Categories;
            ViewBag.Message = listOfProducts;
            Product prod = ProductDA.GetProductById(id);
            if (Session["Cart"] == null)
            {
                Session["Cart"] = new List<Product>();
            }

            List<Product> cart = (List<Product>)Session["Cart"];
            cart.Add(prod);
            Session["Cart"] = cart;
            Session["Count"] = cart.Count();
            return View("Store");
        }

        public ActionResult sort_store(string category)
        {
            List<Product> listOfAllProducts = ProductDA.GetAllProducts();
            List<Product> listOfProducts = ProductDA.GetAllProducts(category);
            List<string> Categories = new List<string>();
            foreach (Product p in listOfAllProducts)
            {
                if (!Categories.Contains(p.Category))
                {
                    Categories.Add(p.Category);
                }
            }
            ViewBag.Categories = Categories;
            ViewBag.Message = listOfProducts;
            return View("Store");
        }

        public ActionResult try_purchase(string name, string card_num, string cvc, DateTime expiration)
        {
            bool valid = true;

            if(name.Length <= 0)
            {
                valid = false;
            }

            if(card_num.Length != 16)
            {
                valid = false;

            }

            try
            {
                Convert.ToInt32(card_num);
            }
            catch (Exception e)
            {
                valid = false;
                Console.WriteLine(e);
            }

            if (cvc.Length != 3)
            {
                valid = false;
            }

            try
            {
                Convert.ToInt16(cvc);
            } catch (Exception e)
            {
                Console.WriteLine(e);
            }



            return View("Checkout");
        }
    }
}