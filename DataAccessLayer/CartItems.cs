using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class CartItems
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Proudct")]
        public int ProudctId { get; set; }

        public Proudct proudct { get; set; }

        public string ProudctName { get; set; }
  
        public int Quantity { get; set; }

        public string? ImageUrl { get; set; }

        public decimal Price { get; set; }

        public decimal TotalPrice => Price*Quantity;


    }
}
