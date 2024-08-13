using System;
namespace MangmentSystem
{
    public class Product
    {   private string name { get; set; }
        private double price { get; set; }
        private double quantity { get; set; }

        public Product(string name,double price,double quantity)
        {
            setName(name);
            setPrice(price);
            setQuantity(quantity);
        }
        public string getName()
        {
            return name;
        }

        public double getPrice()
        {
            return price;
        }

        public double getQuantity()
        {
            return quantity;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public void setPrice(double price)
        {
            this.price = price >= 0 ? price : 0;
        }

        public void setQuantity(double quantity)
        {
            this.quantity = quantity >= 0 ? quantity : 0;
        }

        public string toString()
        {
            return $"name = {name}  price = {price}  quantity = {quantity}";
        }


    }
}
