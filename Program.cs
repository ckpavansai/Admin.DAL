using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin.DAL;
using System.Data;

namespace Admin.DAL
{
    public class Program
    {
        static void Main()
        {
            int ch = 0;

            Console.WriteLine("1 - Add products to the website");
            Console.WriteLine(" 2 - View order details of the customer");

            Console.WriteLine("Enter your choice :");
            _ = int.Parse(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    Console.WriteLine("Enter orderID :");
                    int OrderID = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter order name :");
                    string Order_Name = Console.ReadLine();


                    Console.WriteLine("Enter order date :");
                    DateTime Order_Date = DateTime.Parse(Console.ReadLine());

                    break;

               



            }

            Console.WriteLine("Done");
            Console.ReadKey();

        }
    }
}
