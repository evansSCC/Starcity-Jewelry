using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPGroupProject.Models
{
    public class User
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string BillingAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public User(int ID, string name, string address, string phone, string email)
        {
            CustomerID = ID;
            CustomerName = name;
            BillingAddress = address;
            PhoneNumber = phone;
            EmailAddress = email;
        }
    }
}