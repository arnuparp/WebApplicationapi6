using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("Tbl_Product")]
    public class Product
    {
        [Key]
        public int Id_Product { get; set; }
        public string? Product_Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int Status { get; set; }

        public DateTime Cre_date { get; set; }
    }
}
