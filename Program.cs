using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Restaurant_Billing
{
    class Program
    {
        static string inputpath = "E:\\Database\\restaurentbilling\\itemdetail.txt";
        static string outputpath = "E:\\Database\\restaurentbilling\\itemdetail.txt";
        static string detailinputpath = "E:\\Database\\restaurentbilling\\shopdetail.txt";
        static string detailoutputpath = "E:\\Database\\restaurentbilling\\shopdetail.txt";
        static Dictionary<int, Item> MyDatabase = new Dictionary<int, Item>();
        static List<Bill> bill = new List<Bill>();
        static List<Restaurantdetail> detail = new List<Restaurantdetail>();
       // static Bill billist = new Bill();
       
        static void Main(string[] args)
        {
            file_to_dict();
            file_to_detaillist();
            process();
        }
        static void process()
        {
            Console.Write("menu-m;print-p");
            //Console.Clear();
            if (Console.ReadKey().Key==ConsoleKey.M)
            {
                Console.Clear();
                Console.Write("Add,edit,remove:item-i;shop-ss");
                //Console.Clear();
                if (Console.ReadKey().Key==ConsoleKey.I)
                {
                    Console.Clear();
                    Console.Write("add-a;edit-ee;remove-rrr");
                    //Console.Clear();
                    if (Console.ReadKey().Key == ConsoleKey.A)
                    {
                        Console.Clear();
                        add_item();
                    }
                    else if (Console.ReadKey().Key == ConsoleKey.E)
                    {
                        Console.Clear();
                        edit_item();
                    }
                    else if (Console.ReadKey().Key == ConsoleKey.R)
                    {
                        Console.Clear();
                        remove_item();
                    }
                    else
                    {
                        process();
                    }
                }
                else if (Console.ReadKey().Key==ConsoleKey.S)
                {
                    Console.Clear();
                    Console.Write("add-a;edit-ee");
                    //Console.Clear();
                    if (Console.ReadKey().Key == ConsoleKey.A)
                    {
                        Console.Clear();
                        add_detail();
                    }
                    else if (Console.ReadKey().Key == ConsoleKey.E)
                    {
                        //Console.Clear();
                        edit_detail();
                    }
                    else
                    {
                        process();
                    }
                }
            }
            else if (Console.ReadKey().Key==ConsoleKey.P)
            {
                bill_print();
            }
        }

        
        static void add_item()
        {
            //file_to_dict();
            do
            {
                Console.Write("ITEM NO: ");
                int item_no = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (MyDatabase.ContainsKey(item_no))
                {
                    Console.Write("Already given these Item numbers");
                    Console.Clear();
                    add_item();
                }
                else
                {
                    Console.Write("ITEM NAME: ");
                    string name = Console.ReadLine();
                    Console.Clear();
                    Console.Write("ITEM PRICE: ");
                    int rate = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    MyDatabase.Add(item_no, new Item(item_no, name, rate));
                    Console.Write("Continue-enter,finish-f");
                    //Console.Clear();
                }
            } while (Console.ReadKey().Key == ConsoleKey.Enter);
            Console.Clear();
            dict_to_file();
            process();
        }
        static void edit_item()
        {
            Console.Clear();
            Console.Write("ITEM NO: ");
            int item_no = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            if (MyDatabase.ContainsKey(item_no))
            {
                Item val = MyDatabase[item_no];
                Console.Write("ITEM PRICE: ");
                val.Item_price = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                MyDatabase[item_no] = val;
            }
            else if (!MyDatabase.ContainsKey(item_no))
            {
                Console.Write("item code not in memory");
                //Console.Clear();
                edit_item();
            }
            dict_to_file();
            process();
        }
        static void remove_item()
        {
            Console.Clear();
            Console.Write("ITEM NO: ");
            int no = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            if (MyDatabase.ContainsKey(no))
            {
                MyDatabase.Remove(no);
            }
            else
            {
                Console.Write("plz give correct no");
                //Console.Clear();
                remove_item();
            }
            dict_to_file();
            process();
        }
        static void add_detail()
        {
            Console.Clear();
           // file_to_detaillist();
            if (detail.Count==0)
            {
                Console.Write("HOTEL NAME: ");
                string name = Console.ReadLine();
                Console.Clear();
                Console.Write("ADDRESS:");
                string location = Console.ReadLine();
                Console.Clear();
                Console.Write("PH_NO:");
                int phone_no = Convert.ToInt32(Console.ReadLine());
                detail.Add(new Restaurantdetail(name, location, phone_no));
                Console.Clear();
            }
            else
            {
                Console.Write("already have detail");
                //Console.Clear();
                
            }
            detaillist_to_file();
            process();

        }
        static void edit_detail()
        {
            Console.Clear();
           // file_to_detaillist();
            if (detail.Count == 1)
            {
                for (int i = 0; i < detail.Count; i++)
                {
                    Restaurantdetail val = detail[i];
                    val.Restaurant_name = Console.ReadLine();
                    val.Address = Console.ReadLine();
                    val.Contact_number = Convert.ToInt32(Console.ReadLine());
                    detail[i] = val;
                }
            }
            else if(detail.Count>1)
            {
                Console.Write("already have detail");
               // Console.Clear();
            }
            else
            {
                Console.Write("No detail plz add");
                //Console.Clear();
            }
            detaillist_to_file();
            process();
        }
        
        static void file_to_dict()
        {
            string[] data = File.ReadAllLines(inputpath);
            foreach (string item in data)
            {
                
                string[] file_data = item.Split(',');
                int no = Convert.ToInt32(file_data[0]);
                string name = file_data[1];
                int rate = Convert.ToInt32(file_data[2]);
                MyDatabase.Add(no,new Item(no,name,rate));
            }
        }
        static void dict_to_file()
        {
            string x = "";
            foreach (Item item in MyDatabase.Values)
            {
                x += item.Item_code + "," + item.Item_name + "," + item.Item_price;
            }
            File.WriteAllText(outputpath, x);
        }
        static void detaillist_to_file()
        {
            string x = "";
            foreach (Restaurantdetail item in detail)
            {
                x += item.Restaurant_name+"/"+item.Address+"/"+item.Contact_number;
            }
            File.WriteAllText(detailoutputpath, x);
        }
        static void file_to_detaillist()
        {
            string[] data = File.ReadAllLines(detailinputpath);
            foreach (string item in data)
            {
                string[] val = item.Split('/');
                detail.Add(new Restaurantdetail(val[0],val[1],Convert.ToInt32(val[2])));
            }
        }

        static void bill_print()
        {
            do
            {
                Console.Clear();
                Console.Write("ITEM NO: ");
                int no = Convert.ToInt32(Console.ReadLine());
                if (MyDatabase.ContainsKey(no))
                {
                    Item val = MyDatabase[no];
                    string name = val.Item_name;
                    int rate = val.Item_price;
                    Console.Clear();
                    Console.Write(name+"  "+rate);
                    int qty = Convert.ToInt32(Console.ReadLine());
                    int sno=1;
                    bill.Add(new Bill(sno, name, rate, qty));
                    Console.Clear();
                    Console.Write(name+"  "+bill[sno-1].Amount);
                    sno++;
                    Console.Write("continue-enter:finish-f");

                }
            } while (Console.ReadKey().Key==ConsoleKey.Enter);
        }
    }
}
