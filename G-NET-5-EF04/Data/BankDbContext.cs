using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BankManagementSystem.Models;

namespace BankManagementSystem.Data
{
    internal class BankDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-3M086AQ;Database=BankManagementSystem;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public DbSet<Branch> Branches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>(entity =>
            {
                entity.HasKey(b => b.Code);

                entity.Property(b => b.Name)
                      .IsRequired();

                entity.Property(b => b.Address)
                      .IsRequired();

                entity.Property(b => b.PhoneNumber)
                      .IsRequired();
            });
        }

    }
}
