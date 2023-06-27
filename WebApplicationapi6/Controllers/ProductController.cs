using Microsoft.AspNetCore.Mvc;
using Domain;
using Application;
using Microsoft.Data.SqlClient;
using System.Data;

namespace WebApplicationapi6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService ProductService)
        {
            _productService = ProductService;
        }
        [HttpGet("all")]
        public IActionResult GetAllProduct()
        {
            var Product = _productService.GetAllProduct().Where(x => x.Status == 1).ToList(); ;


            return Ok(Product);
        }
        [HttpGet]
        public IActionResult GetAllsumProduct()
        {
            using (SqlConnection connection = new SqlConnection("Server =.\\SQLEXPRESS; Database = Stock_T; User Id = sa; Password = 123456; TrustServerCertificate = true"))
            {
                connection.Open();


                string storedProcedureName = "GetProductSum";
               

                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Dictionary<string, object> row = new Dictionary<string, object>();

                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                string columnName = reader.GetName(i);
                                object columnValue = reader.GetValue(i);
                                row[columnName] = columnValue;
                            }

                            results.Add(row);
                        }
                      
                    }
                    return Ok(results);
                }
            }
           

        }
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var Product = _productService.GetProductById(id);
            if (Product == null)
            {
                return NotFound();
            }
            return Ok(Product);
        }

        [HttpPost]
        public IActionResult AddProduct(Product Products)
        {
            _productService.AddProduct(Products);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product Products)
        {
            var Productsid = _productService.GetProductById(id);
            if (Productsid == null)
            {
                return NotFound();
            }

            //Productsid. = Productsid.FirstName;
           // Productsid.LastName = Productsid.LastName;
           // Productsid.Position = Productsid.Position;

            _productService.UpdateProduct(Productsid);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var Product = _productService.GetProductById(id);
            if (Product == null)
            {
                return NotFound();
            }

            _productService.DeleteProduct(id);
            return Ok();
        }

      

    }
}
