using System;
using System.Linq;
using System.Collections.Generic;
using MVC5Course.Models.ViewModels;
using System.Data.Entity;

namespace MVC5Course.Models
{   
	public  class ProductRepository : EFRepository<Product>, IProductRepository
	{
        public override IQueryable<Product> All()
        {
            return base.All().Where(p => !p.Is刪除);
        }

        public IQueryable<Product> All(bool showAll)
        {
            if (showAll)
            {
                return base.All();
            }
            else
            {
                return this.All();
            }
        }

        public Product getProductByID(int ID)
        {
            return this.All(true).FirstOrDefault(p => p.ProductId == ID);
        }

        public void Edit(Product product)
        {
            //我的寫法 
            //var data = getProductByID(product.ProductId);
            //this.Delete(data);
            //this.Add(product);

            //保哥的
            this.UnitOfWork.Context.Entry(product).State = EntityState.Modified;
        }

        public IQueryable<ProdectLiteVM> getProductList()
        {
            var data = this.All(true).Where(p => p.Active == true).OrderByDescending(p => p.ProductId)
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