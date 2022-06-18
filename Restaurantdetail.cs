using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Billing
{
    public class Restaurantdetail
    {
        string restaurant_name;

        public string Restaurant_name
        {
            get { return restaurant_name; }
            set { restaurant_name = value; }
        }
        int bill_no;

        public int Bill_no
        {
            get { return bill_no; }
            set { bill_no = value; }
        }
        int date;

        public int Date
        {
            get { return date; }
            set { date = value; }
        }
        int total;

        public int Total
        {
            get { return total; }
            set { total = value; }
        }
        string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        int contact_number;

        public int Contact_number
        {
            get { return contact_number; }
            set { contact_number = value; }
        }
        public Restaurantdetail(string name,int no,int dateandtime,int alltotal,string location,int phone_no)
        {
            this.restaurant_name = name;
            this.bill_no = no;
            this.date = dateandtime;
            this.address = location;
            this.contact_number = phone_no;
            this.total = alltotal;
        }
        public Restaurantdetail(string name,string location,int phone_no)
        {
            this.restaurant_name = name;
            this.address = location;
            this.contact_number = phone_no;
        }
        public Restaurantdetail()
        {

        }
    }
}
