using Dapper;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    public class DapperProductRepo : IProductRepo
    {
        private readonly IDbConnection _connection;
        public DapperProductRepo(IDbConnection connection) 
        {
            _connection = connection;
        }

        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO products(name, price, categoryID) VALUES ( @name, @price, @categoryID); ",
                new { name = name, price = price, categoryID = categoryID });
        }

        public IEnumerable<Products> GetAllProducts()
        {
            return _connection.Query<Products>("SELECT * FROM Products;");
        }

        public void UpdateProduct(int productID, string updateName)
        {
            _connection.Execute("UPDATE Products SET Name = @updatedName WHERE ProductID = @productID;",
                new { updateName = updateName, productID = productID });
        }

        public void DeleteProduct(int productID)
        {
            _connection.Execute("DELETE FROM reviews WHERE ProductID = @productID;",
                new { productID = productID });

            _connection.Execute("DELETE FROM sales WHERE ProductID = @productID;",
                new { ProductID = productID });

            _connection.Execute("DELETE FROM products WHERE ProductID = @productID;",
                new { ProductID = productID });
        }
    }
}
