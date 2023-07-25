using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    public class DapperProductRepository : IProductRepository
    {
        
        private readonly IDbConnection _connection;

        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }


        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO products (Name, Price, CategoryID) " 
                +"VALUES (@Name, @Price, @CategoryID);",
              new { Name = name, Price = price, CategoryID = categoryID });
        }

        public void DeleteProduct(int productID)
        {
            _connection.Execute("DELETE FROM sales WHERE productID = @productID;", new {productID = productID });
            _connection.Execute("DELETE FROM reviews WHERE productID = @productID;", new { productID = productID });
            _connection.Execute("DELETE FROM products WHERE productID = @productID;", new { productID = productID });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM products;");
        }

        public void UpdateProduct(int productID, string updatedName)
        {
            _connection.Execute("UPDATE products SET name = @updatedName WHERE ProductID = @productID;",
             new { productID = productID, updatedName = updatedName });
        }
    }
}
