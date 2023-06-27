using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProduct();
        Product GetProductById(int id);
        void AddProduct(Product Products);
        void UpdateProduct(Product Products);
        void DeleteProduct(int id);
    }
}
