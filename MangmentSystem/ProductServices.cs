namespace ManagementSystem;
using System.Data.SqlClient;
public class ProductServices : IProductServices{
    private readonly string _connection;
    public ProductService(string connectionString){
        _connection = connectionString;
    }
    public void AddProduct(Product product){
        using(var connection = new Sql SqlConnection(_connectionString)){
            connection.Open();
            using(var command = new SqlCommand("INSERT INTO product (Name , Price, Quantity) VALUES (@Name, @Price, @Quantity)", connection)){
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Quantity", product.Quantity);
                command.ExecuteNonQuery();
            }
        }
    }
    public IEnumerable<Product> GetAllProducts(){
        using (var connection = new SqlConnection(_connection)){
            connection.Open();
            using(var command = new SqlCommand("SELECT * FROM product",connection)){
                using(var reader = command.ExecuteReader()){
                    while(reader.Read()){
                        yield return new Product(
                            reader["Name"].ToString(),
                            Convert.ToDouble(reader["Price"]),
                            Convert.ToDouble(reader["Quantity"])
                        );
                    }
                }
            }
        }
    }
    public void EditProduct(string name, Product updatedProduct){
        var SearchedProduct = SearchProduct(name);
        if(SearchedProduct != Null){
            using(var connection = new SqlConnection(_connectionString)){
                connection.Open();
                using(var command = new Sql Command("UPDATE product SET Name = @NewName, Price = @NewPrice, Quantity = @NewQuantity WHERE Name = @OldName", connection)){
                    command.Parameters.AddWithValue("@NewName", updatedProduct.Name);
                    command.Parameters.AddWithValue("@NewPrice", updatedProduct.Price);
                    command.Parameters.AddWithValue("@NewQuantity", updatedProduct.Quantity);
                    command.Parameters.AddWithValue("@OldName", name);
                    command.ExecuteNonQuery();
                }
            }
        }

    }
    public bool DeleteProduct(string name){
        var SearchedProduct = SearchProduct(name);
        if(SearchedProduct != Null){
            using(var connection = new SqlConnection(_connectionString)){
                connection.Open();
                using(var command = new Sql Command("DELETE FROM product WHERE Name = @Name", connection)){
                    command.Parameters.AddWithValue("@Name", name);
                    command.ExecuteNonQuery();
                }
            }
            return true;
        }
        return false;
    }

        public Product SearchProduct(string name)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            using (var command = new SqlCommand("SELECT * FROM Products WHERE Name = @Name", connection)){
                command.Parameters.AddWithValue("@Name", name);
                using (var reader = command.ExecuteReader()){
                    if (reader.Read()){
                        return new Product(
                            reader["Name"].ToString(),
                            Convert.ToDouble(reader["Price"]),
                            Convert.ToDouble(reader["Quantity"])
                        );
                    }
                }
            }
        }
        return null;
    }

}