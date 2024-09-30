using MongoDB.Driver;
namespace ManagementSystem;
public class ProductService : IProductService{
    private readonly string _connection;
    private readonly IMongoDatabase<Product> _products;
    public ProductService(IMongoClient mongoClient,string databaseName,string collectionName){
        var database = mongoClient.GetDatabase(databaseName);
        _products = database.GetCollection<Product>(collectionName);
    }
    public void AddProduct(Product product){
        _products.InsertOnAsync(product);
    }
    public IEnumerable<Product> GetAllProducts(){
        return _products.GetAll();
    }
    public void EditProduct(string name, Product updatedProduct){
        var filter = Builders<Product>.Filter.Eq(p=>p.Name,name);
        var updates = Builders<Product>.Update.Set(p => p.Name,updatedProduct.Name,)
                                            .Set(p => p.Price,updatedProduct.Price)
                                            .Set(p => p.Quantity,updatedProduct.Quantity);
        _products.UpdateOnAsync(updates);
    }
    public bool DeleteProduct(string name){
        var filter = Builders<Product>.Filter.Eq(p => p.Name,name);
        var result = _products.DeleteOnAsync(filter);
        return result.Result.IsAcknowledge && result.Result.DeletedCount >0;
    }
    public Product SearchProduct(string name){
    var filter = Buliders<Product>.Filter.Eq(p => p.Name,name);
    return _products.Find(filter).FirstOrDefault();
    }   
}
