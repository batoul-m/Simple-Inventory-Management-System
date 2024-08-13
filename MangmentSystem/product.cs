using System;
namespace MangmentSystem
{
    public class Product
    {   private string name { get; set; }
        private double price { get; set; }
        private double quantity { get; set; }

        public Product(string name,double price,double quantity)
        {
            this.name = name;
            this.price = price >= 0? price : 0;
            this.quantity = quantity >= 0 ? quantity : 0;
        }

        public string toString()
        {
            return $"name = {name}  price = {price}  quantity = {quantity}";
        }


    }
}
