using System;
namespace MangmentSystem
{
    public class Product
    {   public string name { get; set; }
        public double price { get; set; }
        public double quantity { get; set; }

        public Product(string name,double price,double quantity)
        {
            this.name = name;
            this.price = price > 0 ? price : 0;
            this.quantity = quantity > 0 ? quantity : 0;
        }

        public string ToString()
        {
            return $"name = {name}  price = {price}  quantity = {quantity}";
        }


    }
}
