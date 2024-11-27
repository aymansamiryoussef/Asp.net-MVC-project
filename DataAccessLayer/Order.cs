using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Order
    {
        public int Id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserID { get; set; }
        public ApplicationUser ApplicationUser{ get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; }
        [Required]
        [Range(0.001,20000000)]
        public decimal TotalAmount { get; set; }

        public string OrderStatus { get; set; }

        public ICollection<Orderitem> Items { get; set; }


    }
}
