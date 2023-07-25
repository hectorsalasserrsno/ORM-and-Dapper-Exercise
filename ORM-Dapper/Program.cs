using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System.Drawing.Printing;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {

            //^^^^MUST HAVE USING DIRECTIVES^^^^
            # region configuration
            var config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .Build();
            string connString = config.GetConnectionString("DefaultConnection");
             # endregion      //Console.WriteLine(connString);
            IDbConnection conn = new MySqlConnection(connString);
            DapperDepartmentRepository repo = new DapperDepartmentRepository(conn);
            Console.WriteLine("Hello user, here are the current departments: ");
            Console.WriteLine("Please press enter...");
            Console.ReadLine();
            var depos = repo.GetAllDepartments();
            Print(depos);
           
            Console.WriteLine("Do you want to add a department?");
            string userResponse = Console.ReadLine();
            if (userResponse.ToLower() == "yes") 
            {
                Console.WriteLine("What is the name of your new department?");
                userResponse = Console.ReadLine();
                repo.InsertDepartment(userResponse);
                repo.GetAllDepartments();
                Print(repo.GetAllDepartments());
            }
            Console.WriteLine("Have a great day!");
           
            IDbConnection connection = new MySqlConnection(connString);
            DapperProductRepository productrepo = new DapperProductRepository(connection);
            Console.WriteLine("Hello user, here are the current products: ");
            Console.WriteLine("Please press enter...");
            Console.ReadLine();

            productrepo.DeleteProduct(887);
            
            var products = productrepo.GetAllProducts();            
            Console.WriteLine();
            foreach (var product in products) 
            {
                Console.WriteLine(product.ProductID);
                Console.WriteLine(product.Name);
                Console.WriteLine(product.Price);
                Console.WriteLine(product.CategoryID);
                Console.WriteLine(product.OnSale);
                Console.WriteLine(product.StockLevel);
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine("What is the product ID you want to update");
            var prodID = int.Parse(Console.ReadLine());

            Console.WriteLine("What is the new product name?");
            var newName = (Console.ReadLine());
            productrepo.UpdateProduct(prodID, newName);
        }
        private static void Print(IEnumerable<Department> depos)
        {
            foreach (var depo in depos)
            {
                Console.WriteLine($"Id: {depo.DepartmentID} Name: {depo.Name}");
            }
        }
       
}
}
