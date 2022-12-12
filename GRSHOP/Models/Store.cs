using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GRSHOP.Models
{
    public class Store
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Logo { get; set; }
        [Required]
        public string Address { get; set; }

        public List<Grocery> Groceries { get; set; }
        public List<Brand> Brands { get; set; }


    }
}
