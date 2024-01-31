using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ORM_Dapper;
using System.Data;


            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

            var repo = new DapperProductRepository(conn);

            Console.WriteLine("What is the name of your new product?");
            var prodName = Console.ReadLine();

            Console.WriteLine("What is the price?");
            var prodPrice = double.Parse(Console.ReadLine());

            Console.WriteLine("What is the category ID?");
            var prodCat = int.Parse(Console.ReadLine());

            repo.CreateProduct(prodName, prodPrice, prodCat);

            Console.WriteLine("Would you like to update a product? Press y for yes. Press n for no.");
            var yesOrNo = Console.ReadLine();
            if(yesOrNo == "y")
            {
                Console.WriteLine("What is the product ID you want to update?");
                var prodIdForUpdate = int.Parse(Console.ReadLine());
                Console.WriteLine("What is the new name of the product?");
                var newProdName = Console.ReadLine();
                repo.UpdateProduct(prodIdForUpdate, newProdName);
            }

            Console.WriteLine("Would you like to delete a product? Press y for yes. Press n for no.");
            var yesOrNoDelete = Console.ReadLine();
            if(yesOrNoDelete == "y")
            {
                Console.WriteLine("What is the product ID you want to delete?");
                var prodIdForDelete = int.Parse(Console.ReadLine());
                repo.DeleteProduct(prodIdForDelete);
            }

            var prodList = repo.GetAllProducts();

            foreach (var prod in prodList)
            {
                Console.WriteLine($"{prod.ProductID} - {prod.Name} - {prod.Price} - {prod.CategoryID}");
            }