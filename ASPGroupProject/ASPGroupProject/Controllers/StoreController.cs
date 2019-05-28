using ASPGroupProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPGroupProject.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        [Route("Store/Index")]
        public ActionResult Index()
        {
            List<Product> products = ProductDA.GetAllProducts();
            return View(products);
        }

        public ActionResult Checkout()
        {
            return View();
        }
    }
}