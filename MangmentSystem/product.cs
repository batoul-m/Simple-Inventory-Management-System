using System;

namespace ManagementSystem
{
    public class Product
    {
        private string _name;
        private double _price;
        private double _quantity;

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Product name cannot be null or empty.");
                }
                _name = value;
            }
        }

        public double Price
        {
            get => _price;
            set => _price = value > 0 ? value : 0;
        }

        public double Quantity
        {
            get => _quantity;
            set => _quantity = value > 0 ? value : 0;
        }

        public Product(string name, double price, double quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"Name = {Name}, Price = {Price}, Quantity = {Quantity}";
        }
    }
}
