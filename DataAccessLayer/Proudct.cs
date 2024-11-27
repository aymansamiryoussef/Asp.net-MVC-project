using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Proudct
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required, StringLength(50)]
        [Display(Name ="Description")]
        public string Description { get; set; }
        [Range(0.01,200000)]
        [Display(Name ="price")]
        public decimal Price { get; set; }

        [Required]
        public int Stockquantity { get; set; }
       
        public string? ImageUrl {  get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; } 
        public Category? Category { get; set; }


        public ICollection<Orderitem>? orderitems { get; set; }



    }
}
