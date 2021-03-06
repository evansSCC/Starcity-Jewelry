﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPGroupProject.Models
{
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public int Qty { get; set; }
        public int Id { get; set; }

        public Product(string name, string description, string category, double price, string imagePath, int qty)
        {
            Name = name;
            Description = description;
            Category = category;
            Price = price;
            Image = imagePath;
            Qty = qty;
        }

        public Product()
        {
        }
    }
}