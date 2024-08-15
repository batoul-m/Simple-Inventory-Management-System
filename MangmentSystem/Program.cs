using System;
using System.Collections;

namespace ManagementSystem
{
    class MainClass
    {
        public static ArrayList products = new ArrayList();

        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose what you want:\n" +
                                    "1. Add a product\n" +
                                    "2. View all products\n" +
                                    "3. Edit a product\n" +
                                    "4. Delete a product\n" +
                                    "5. Search for a product\n" +
                                    "6. Exit\n"
                                );

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddProducts();
                        break;

                    case 2:
                        if (products.Count > 0)
                        {
                            foreach (Product item in products)
                            {
                                Console.WriteLine(item.ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine("There's no products in the system.");
                        }
                        break;

                    case 3:
                        if (products.Count > 0)
                        {
                            EditProducts();
                        }
                        else
                        {
                            Console.WriteLine("There's no products in the system.");
                        }
                        break;

                    case 4:
                        if (products.Count > 0)
                        {
                            if (!DeleteProducts())
                            {
                                Console.WriteLine("There is no product with this name.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("There's no products in the system.");
                        }
                        break;

                    case 5:
                        if (products.Count > 0)
                        {
                            Console.WriteLine("Enter the name of the product:");
                            string name = Console.ReadLine();
                            bool foundProduct = false;

                            foreach (Product item in products)
                            {
                                if (name.Equals(item.Name, StringComparison.OrdinalIgnoreCase))
                                {
                                    foundProduct = true;
                                    Console.WriteLine(item.ToString());
                                }
                            }

                            if (!foundProduct)
                            {
                                Console.WriteLine("There is no product with this name.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("There's no products in the system.");
                        }
                        break;

                    case 6:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice, please choose a number between 1 and 6.");
                        break;
                }
            }
        }

        public static void AddProducts()
        {
            Console.WriteLine("Enter the name of the product:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the price:");
            double price = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the quantity:");
            double quantity = double.Parse(Console.ReadLine());

            products.Add(new Product(name, price, quantity));
        }

        public static void EditProducts()
        {
            Console.WriteLine("Enter the name of the product to edit:");
            string name = Console.ReadLine();
            bool foundProduct = false;

            foreach (Product item in products)
            {
                if (name.Equals(item.Name, StringComparison.OrdinalIgnoreCase))
                {
                    foundProduct = true;

                    Console.WriteLine("Enter the new name:");
                    item.Name = Console.ReadLine();

                    Console.WriteLine("Enter the new price:");
                    item.Price = double.Parse(Console.ReadLine());

                    Console.WriteLine("Enter the new quantity:");
                    item.Quantity = double.Parse(Console.ReadLine());

                    Console.WriteLine("Product updated successfully.");
                    break;
                }
            }

            if (!foundProduct)
            {
                Console.WriteLine("There is no product with this name.");
            }
        }

        public static bool DeleteProducts()
        {
            Console.WriteLine("Enter the name of the product to delete:");
            string name = Console.ReadLine();

            foreach (Product item in products)
            {
                if (name.Equals(item.Name, StringComparison.OrdinalIgnoreCase))
                {
                    products.Remove(item);
                    Console.WriteLine("Product deleted successfully.");
                    return true;
                }
            }

            return false;
        }
    }
}
