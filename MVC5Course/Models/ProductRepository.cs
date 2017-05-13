using System;
using System.Linq;
using System.Collections.Generic;
using MVC5Course.Models.ViewModels;

namespace MVC5Course.Models
{   
	public  class ProductRepository : EFRepository<Product>, IProductRepository
	{
        public Product getProductByID(int ID)
        {
            return this.All().FirstOrDefault(p => p.ProductId == ID);
        }

        public void Edit(Product product)
        {
            var data = getProductByID(product.ProductId);

            this.Delete(data);
            this.Add(product);
        }

        public IQueryable<ProdectLiteVM> getProductList()
        {
            var data = this.All().Where(p => p.Active == true).OrderByDescending(p => p.ProductId)
                .Select(x => new ProdectLiteVM()
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    Price = x.Price,
                    Stock = x.Stock
                }).Take(10);
            return data;
        }
    }

	public  interface IProductRepository : IRepository<Product>
	{

	}
}