using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPGroupProject.Models
{
    public class User
    {
        public int CustomerID { get; set; }
        public string EmailAddress { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZIP { get; set; }
        public string PhoneNumber { get; set; }
        public string foreignKeyUID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public User(int ID, string email, string bill_country, string bill_address, string bill_city, string bill_state, string bill_zip, string phone, string uID, string fName, string lName, string nameSuffix)
        {
            CustomerID = ID;
            EmailAddress = email;
            Country = bill_country;
            Address = bill_address;
            City = bill_city;
            State = bill_state;
            ZIP = bill_zip;
            PhoneNumber = phone;
            foreignKeyUID = uID;
            FirstName = fName;
            LastName = lName;
            Suffix = nameSuffix;
        }
        public User() { }
    }
}