using Domain;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productReposity;

        public ProductService(IProductRepository ProductReposity)
        {
            _productReposity = ProductReposity;
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return _productReposity.GetAllProduct();
        }

        public Product GetProductById(int id)
        {
            return _productReposity.GetProductById(id);
        }

        public void AddProduct(Product Products)
        {
            _productReposity.AddProduct(Products);
        }

        public void UpdateProduct(Product Products)
        {
            _productReposity.UpdateProduct(Products);
        }

        public void DeleteProduct(int id)
        {
            _productReposity.DeleteProduct(id);
        }
    }
}
