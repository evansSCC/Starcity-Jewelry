using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPGroupProject.Models
{
    public class Order
    {
        public int ProductID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderPrice { get; set; }
        public bool ShippingAddressDifferentFromBilling { get; set; }

        public Order(int product_ID, int customer_ID, DateTime orderDate, decimal priceOfOrder, bool isShippingDifferentThanBilling)
        {
            ProductID = product_ID;
            CustomerID = customer_ID;
            OrderDate = orderDate;
            OrderPrice = priceOfOrder;
            ShippingAddressDifferentFromBilling = isShippingDifferentThanBilling;
        }
    }
}