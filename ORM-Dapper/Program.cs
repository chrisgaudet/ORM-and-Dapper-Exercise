using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string? connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);

            var repo = new DapperDepartmentRepo(conn);

            var departments = repo.GetAllDepts();

            foreach (var dept in departments)
            {
                Console.WriteLine($"{dept.DepartmentID} {dept.Name}");
            }

            Console.WriteLine("------------------");

            var repo2 = new DapperProductRepo(conn);

            repo2.CreateProduct("newStuff", 50, 1);

            var products = repo2.GetAllProducts();

            foreach(var product in products)
            {
                Console.WriteLine($"{product.ProductID} {product.Name}");
            }
        }
    }
}
