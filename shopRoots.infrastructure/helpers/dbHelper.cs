using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using shopRootsAdmin.core.models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using System.Data.Entity.Core.Objects;
using System.Linq;
namespace shopRoots.infrastructure.helpers
{
   public class dbHelper : DbContext
    {
        public dbHelper(DbContextOptions<dbHelper> options) : base(options) {
            //Configuration.LazyLoadingEnabled = true;
        }
        public DbSet<AddressModel> Addresses { get; set; }
        public virtual DbSet<userModel> Users { get; set; }
        public virtual DbSet<AuthModel> Authentication { get; set; }
        public virtual DbSet<logModel> Logs { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<userModel>(entity =>
            {
                //entity.ToTable("Users");
            });

            modelBuilder.Entity<AddressModel>(entity =>
            {
                //entity.ToTable("Address");
            });
            modelBuilder.Entity<AuthModel>(entity =>
            {
                //entity.ToTable("Address");
            });
            modelBuilder.Entity<logModel>(entity =>
            {
                entity.ToTable("Logs");
            });
        }
    }
}

