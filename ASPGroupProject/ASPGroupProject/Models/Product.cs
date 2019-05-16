using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPGroupProject.Models
{
    public class Product
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCategory { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImagePath { get; set; }

        public Product(string name, string description, string category, decimal price, string imagePath)
        {
            ProductName = name;
            ProductDescription = description;
            ProductCategory = category;
            ProductPrice = price;
            ProductImagePath = imagePath;
        }

    }
}