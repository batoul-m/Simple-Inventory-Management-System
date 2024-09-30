using System;
using System.Collections;
namespace ManagementSystem;
class MainClass
{
    private static IProductService _productService;

    public MainClass(IProductService productService)
    {
        _productService = productService;
    }

    public static void Main(string[] args)
    {
        IProductService productService = new ProductService();
        MainClass program = new MainClass(productService);

        while (true)
        {
            Console.WriteLine("Choose what you want:\n" +
                              "1. Add a product\n" +
                              "2. View all products\n" +
                              "3. Edit a product\n" +
                              "4. Delete a product\n" +
                              "5. Search for a product\n" +
                              "6. Exit\n");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddProducts();
                    break;

                case 2:
                    ViewAllProducts();
                    break;

                case 3:
                    EditProducts();
                    break;

                case 4:
                    DeleteProducts();
                    break;

                case 5:
                    SearchProducts();
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

    private static void AddProducts()
    {
        Console.WriteLine("Enter the name of the product:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter the price:");
        double price = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter the quantity:");
        double quantity = double.Parse(Console.ReadLine());

        _productService.AddProduct(new Product(name, price, quantity));
    }

    private static void ViewAllProducts()
    {
        var products = _productService.GetAllProducts();
        if (products.Any())
        {
            foreach (var product in products)
            {
                Console.WriteLine(product.ToString());
            }
        }
        else
        {
            Console.WriteLine("There's no products in the system.");
        }
    }

    private static void EditProducts()
    {
        Console.WriteLine("Enter the name of the product to edit:");
        string name = Console.ReadLine();

        var product = _productService.SearchProduct(name);
        if (product != null)
        {
            Console.WriteLine("Enter the new name:");
            string newName = Console.ReadLine();

            Console.WriteLine("Enter the new price:");
            double newPrice = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the new quantity:");
            double newQuantity = double.Parse(Console.ReadLine());

            _productService.EditProduct(name, new Product(newName, newPrice, newQuantity));
            Console.WriteLine("Product updated successfully.");
        }
        else
        {
            Console.WriteLine("There is no product with this name.");
        }
    }

    private static void DeleteProducts()
    {
        Console.WriteLine("Enter the name of the product to delete:");
        string name = Console.ReadLine();

        if (_productService.DeleteProduct(name))
        {
            Console.WriteLine("Product deleted successfully.");
        }
        else
        {
            Console.WriteLine("There is no product with this name.");
        }
    }

    private static void SearchProducts()
    {
        Console.WriteLine("Enter the name of the product:");
        string name = Console.ReadLine();

        var product = _productService.SearchProduct(name);
        if (product != null)
        {
            Console.WriteLine(product.ToString());
        }
        else
        {
            Console.WriteLine("There is no product with this name.");
        }
    }
}

