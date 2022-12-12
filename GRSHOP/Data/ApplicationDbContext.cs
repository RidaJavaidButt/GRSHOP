using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using GRSHOP.Models;

namespace GRSHOP.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<GRSHOP.Models.Grocery> Grocery { get; set; }

        public DbSet<GRSHOP.Models.Brand> Brand { get; set; }

        public DbSet<GRSHOP.Models.Store> Store { get; set; }

        public DbSet<GRSHOP.Models.Order> Order { get; set; }





    }
}
