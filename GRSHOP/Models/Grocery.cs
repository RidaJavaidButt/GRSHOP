using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GRSHOP.Models
{
    public class Grocery
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string URL { get; set; }
        [Required]
        public int Price { set; get; }

        [ForeignKey("GroceryBrand")]

        public int BrandId { get; set; }
        public virtual Brand GroceryBrand { get; set; }


        [ForeignKey("GroceryStore")]

        public int StoreId { get; set; }
        public virtual Store GroceryStore { get; set; }









    }
}
