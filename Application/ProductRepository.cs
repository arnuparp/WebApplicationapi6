using Domain;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class ProductRepository:IProductRepository
    {
        private readonly ProductDbContext _dbContext;

        public ProductRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return _dbContext.Products;
        }

        public Product GetProductById(int id)
        {
            return _dbContext.Products.Find(id);
        }

        public void AddProduct(Product Products)
        {
            _dbContext.Products.Add(Products);
            _dbContext.SaveChanges();
        }

        public void UpdateProduct(Product Products)
        {
            _dbContext.Products.Update(Products);
            _dbContext.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var Products = _dbContext.Products.Find(id);
            if (Products != null)
            {
                _dbContext.Products.Remove(Products);
                _dbContext.SaveChanges();
            }
        }

    }
}
