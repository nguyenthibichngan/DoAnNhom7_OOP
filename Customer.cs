using System;
using System.Collections.Generic;
using System.Text;

namespace DoAnCuoiKy
{
    public class Customer
    {
        private string customerID;
        private string name;
        private string address;
        private string phone;
        private string date;
        public string CustomerID { get => customerID; set => customerID = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Date { get => date; set => date = value; }


        public Customer()
        {
            this.customerID = "";
            this.name = "";
            this.address = "";
            this.phone = "";
            this.date = "";
        }
        public Customer(string customerID, string name, string address, string phone, string date)
        {
            this.customerID = customerID;
            this.name = name;
            this.address = address;
            this.phone = phone;
            this.date = date;
        }
        public Customer(Customer newCustomer)
        {
            this.customerID = newCustomer.customerID;
            this.name = newCustomer.name;
            this.address = newCustomer.address;
            this.phone = newCustomer.phone;
            this.date = newCustomer.date;
        }
        public override string ToString()
        {
            return $"({customerID}, {name}, {address}, {phone}, {date})";
        }

    }

}
