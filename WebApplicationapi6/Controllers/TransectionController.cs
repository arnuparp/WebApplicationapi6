using Application;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationapi6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransectionController : Controller
    {
        private readonly ITransectionService _TransectionService;
        public TransectionController(ITransectionService TransectionServices)
        {
            _TransectionService = TransectionServices;
        }

        [HttpGet]
        public IActionResult GetAllTransection()
        {
            var Transection = _TransectionService.GetAllTransection().Where(x => x.Status == 1).ToList(); ;

            return Ok(Transection);
        }

        [HttpPost]
        public IActionResult AddTransection(Transection Transections)
        {
            var Product = _TransectionService.GetAllTransection().ToList().OrderByDescending(u => u.Id_tran).FirstOrDefault();
            if (Product==null)
            {
                Transections.Id_tran = 1;
            }
            else
            {
 Transections.Id_tran = Convert.ToInt32(Product.Id_tran) + 1;
            }

            Transections.Cre_date = DateTime.Now;
            _TransectionService.AddTransection(Transections);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTransection(int id)
        {
            var Productsid = _TransectionService.GetTransectionById(id);
            if (Productsid == null)
            {
                return NotFound();
            }
            Productsid.Status = 2;



            _TransectionService.UpdateTransection(Productsid);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTransection(int id)
        {
            var Product = _TransectionService.GetTransectionById(id);
            if (Product == null)
            {
                return NotFound();
            }

            _TransectionService.DeleteTransection(id);
            return Ok();
        }
    }
}
