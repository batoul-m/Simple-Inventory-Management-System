namespace ManagementSystem;
public class Product{
    public string Name;
    public decimal Price;
    public float Quantity;
    public Product(string name, double price, double quantity)
    {
        Name = string.IsNullOrWhiteSpace(name) ? throw new ArgumentException("Product name cannot be null or empty."): name;
        Price = price > 0 ? price : 0 ;
        Quantity = quantity > 0 ? quantity : 0;
    }
    public override string ToString()
    {
        return $"Name = {Name}, Price = {Price}, Quantity = {Quantity}";
    }
}
