using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Billing
{
    public class Item
    {
        int item_code;

        public int Item_code
        {
            get { return item_code; }
            set { item_code = value; }
        }
        string item_name;

        public string Item_name
        {
            get { return item_name; }
            set { item_name = value; }
        }
        int item_price;

        public int Item_price
        {
            get { return item_price; }
            set { item_price = value; }
        }
        public Item(int code,string name,int rate)
        {
            this.item_code = code;
            this.item_name = name;
            this.item_price = rate;
        }

        public Item()
        {

        }

        
    }
}
