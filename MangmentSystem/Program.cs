using System;
using System.Collections;

namespace MangmentSystem
{
    class MainClass
    {
        public static ArrayList products = new ArrayList();
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("choose what you want :\n" +
                                    "1.Add a product\n" + "2.View all products\n" + "3.Edit a product\n" +
                                    "4.Delete a product\n" + "5.Search for a product\n" + "6.Exit\n"
                                    );
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddProducts();
                        break;

                    case 2:
                        if (products.Count > 0) {
                             foreach (Product item in products) { 
                                Console.WriteLine(item.toString()); 
                             }
                          } else { 
                            Console.WriteLine("there's no products in the System");
                             }

                        break;

                    case 3:
                        break;

                    case 4:
                        break;

                    case 5:
                        break;

                    case 6:
                        break;

                    default:
                        Console.WriteLine("Invalid choice, please choose a number between 1 and 6.");
                        break;

                }
            }

        }

        public static void AddProducts()
        {
            Console.WriteLine("enter the name of the product");
            string name = Console.ReadLine();
            Console.WriteLine("write the price ");
            int price = int.Parse(Console.ReadLine());
            Console.WriteLine("write the quantity");
            int quantity = int.Parse(Console.ReadLine());
            products.Add(new Product(name, price, quantity));
        }



    }
}
