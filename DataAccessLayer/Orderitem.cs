using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Orderitem
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("Order")]
        public int OrderID { get; set; }
        public Order Order { get; set; }
        
        [Required]
        [ForeignKey("Proudct")]
        public int ProductID { get; set; }
        public Proudct Proudct { get; set; }


        [Required]
        public int quantity { get; set; }
        [Range(0.01,100000)]
        public decimal price { get; set; }

        public decimal TotalPrice { get; set; }

    }
}
