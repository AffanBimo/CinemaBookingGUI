using System;

namespace CinemaBookingGUI
{
    public class Customer
    {
        public string CustomerID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Customer(string customerId, string name, string email)
        {
            CustomerID = customerId;
            Name = name;
            Email = email;
        }

        public void DisplayCustomerDetails()
        {
            Console.WriteLine($"Customer [{CustomerID}]: {Name} ({Email})");
        }
    }
}