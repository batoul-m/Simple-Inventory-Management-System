namespace ManagementSystem;
public interface IProductServices{
    void AddProduct(Product product);
    IEnumerable<Product> GetAllProducts();
    void EditProduct(string name, Product updatedProduct);
    bool DeleteProduct(string name);
    Product SearchProduct(string name);
}
