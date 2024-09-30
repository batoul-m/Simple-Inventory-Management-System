namespace ManagementSystem;
public class ProductServices : IProductServices{
    private readonly IList<Product> _products;
    public ProductService(){
        _products = new List<Product>();
    }
    public void AddProduct(Product product){
        _products.Add(product);
    }
    public IEnumerable<Product> GetAllProducts(){
        return _products;
    }
    public void EditProduct(string name, Product updatedProduct){
        var SearchedProduct = SearchProduct(name);
        if(SearchedProduct != Null){
            SearchedProduct.Name = updatedProduct.Name;
            SearchedProduct.Price = updatedProduct.Price;
            SearchedProduct.Quantity = updatedProduct.Quantity;
        }
    }
    public bool DeleteProduct(string name){
        var SearchedProduct = SearchProduct(name);
        if(SearchedProduct != Null){
            _products.Remove(SearchedProduct);
            return true;
        }
        return false;
    }

    public Product SearchProduct(string name){
        return _products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

}