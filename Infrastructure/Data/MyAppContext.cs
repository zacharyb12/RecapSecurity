using Microsoft.EntityFrameworkCore;
using Models.ProductModels;
using Models.UserModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public class MyAppContext : DbContext
    {

        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products {  get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(MyAppContext).Assembly);
        }
    }
}
