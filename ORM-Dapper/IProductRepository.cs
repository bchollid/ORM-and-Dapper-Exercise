using System;
namespace ORM_Dapper
{
	public interface IProductRepository
	{
		IEnumerable<Product> GetAllProducts();
		void CreateProduct(string name, double price, int categoryID);
		void UpdateProduct(int productID, string newName);
		void DeleteProduct(int productID);
	}
}

