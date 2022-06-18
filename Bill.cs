using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Billing
{
    public class Bill
    {

        int s_no;

        public int S_no
        {
            get { return s_no; }
            set { s_no = value; }
        }
        string item_name;

        public string Item_name
        {
            get { return item_name; }
            set { item_name = value; }
        }
        int qty;

        public int Qty
        {
            get { return qty; }
            set { qty = value; }
        }
        int price;

        public int Price
        {
            get { return price; }
            set { price = value; }
        }
        int amount;

        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        public Bill(int sno,string name,int price,int quantity)
        {
            this.s_no =sno ;
            this.item_name = name;
            this.qty = quantity;
            this.price =price ;
            this.amount = qty*price;
        }
       
    }
}
