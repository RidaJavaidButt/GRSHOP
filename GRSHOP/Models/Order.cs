using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GRSHOP.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Quantity { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string LastUpdated { get; set; }

        public List<IdentityUser> Users { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual IdentityUser User { get; set; }


        [ForeignKey("GroceryBrand")]

        public int BrandId { get; set; }
        public virtual Brand GroceryBrand { get; set; }




    }
}
