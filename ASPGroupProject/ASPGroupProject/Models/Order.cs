using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPGroupProject.Models
{
    public class Order
    {
        public int ID { get; set; }
        public List<Product> Products { get; set; }
        public String CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public bool ShippingAddressDifferentFromBilling { get; set; }
        public decimal OrderPrice { get; set; }

        public Order(int order_ID, List<Product> products_list, String customer_ID, DateTime orderDate, bool isShippingDifferentThanBilling)
        {
            ID = order_ID;
            Products = products_list;
            CustomerID = customer_ID;
            OrderDate = orderDate;
            OrderPrice = calcOrderPrice(Products);
            ShippingAddressDifferentFromBilling = isShippingDifferentThanBilling;
        }

        public Order() { }

        private decimal calcOrderPrice(List<Product> productList)
        {
            decimal total = 0;

            foreach (Product p in productList)
            {
                total += p.Price;
            }
            return total;
        }
    }

    
}