using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using shopRootsAdmin.core.models;
namespace shopRoots.infrastructure.helpers
{
   public class dbHelper : DbContext
    {
        public dbHelper(DbContextOptions<dbHelper> options) : base(options) {
        }
        public DbSet<userModel> Users { get; set; }
        public DbSet<AddressModel> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<userModel>().ToTable("Users");
            modelBuilder.Entity<AddressModel>().ToTable("Address");
        }
    }
}

