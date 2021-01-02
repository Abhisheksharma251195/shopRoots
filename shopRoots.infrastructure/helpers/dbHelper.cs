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
            var test = "";
        }
        public DbSet<userModel> Users { get; set; }
        public DbSet<AddressModel> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<userModel>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(x => x.Id);
                //entity.HasMany(a => a.Address);

            });
            modelBuilder.Entity<AddressModel>(entity =>
            {
                entity.ToTable("Address");
                entity.HasKey(x => x.Id);
                //entity.HasOne(x => x.User).WithMany(y => y.Address).HasForeignKey(z => z.UserId);
            });
        }
    }
}

