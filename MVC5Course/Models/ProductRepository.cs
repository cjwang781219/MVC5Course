using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class ProductRepository : EFRepository<Product>, IProductRepository
	{
        public Product getProductByID(int ID)
        {
            return this.All().FirstOrDefault(p => p.ProductId == ID);
        }
	}

	public  interface IProductRepository : IRepository<Product>
	{

	}
}