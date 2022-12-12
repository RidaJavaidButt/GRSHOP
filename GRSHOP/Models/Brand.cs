using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GRSHOP.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }


        public string URL { get; set; }

        public List<Grocery> Groceries { get; set; }
        public List<Order> Orders { get; set; }

    }
}
