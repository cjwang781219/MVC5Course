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
            return base.All().Where(p => !p.Is�R��);
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
            //�ڪ��g�k 
            //var data = getProductByID(product.ProductId);
            //this.Delete(data);
            //this.Add(product);

            //�O����
            this.UnitOfWork.Context.Entry(product).State = EntityState.Modified;
        }

        public IQueryable<Product> getProductList()
        {
            var data = this.All(true).Where(p => p.Active == true).OrderByDescending(p => p.ProductId);
            return data;
        }
        public override void Delete(Product entity)
        {
            entity.Is�R�� = true;
            //this.UnitOfWork.Context.Entry(entity).State = EntityState.Modified;
        }
    }

	public  interface IProductRepository : IRepository<Product>
	{

	}
}