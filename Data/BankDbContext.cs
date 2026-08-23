using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BankManagementSystem.Models;

namespace BankManagementSystem.Data
{
    public class BankDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-3M086AQ;Database=BankManagementSystem;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
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

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.Property(m => m.FullName)
                      .IsRequired();

                entity.Property(m => m.Email)
                      .IsRequired();

                entity.Property(m => m.PhoneNumber)
                      .IsRequired();
            });

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(a => a.AccountNumber);

                entity.Property(a => a.AccountType)
                      .IsRequired();

                entity.Property(a => a.Balance)
                      .HasPrecision(18, 2)
                      .IsRequired();

                entity.Property(a => a.OpeningDate)
                      .IsRequired();
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(c => c.Address).IsRequired();
                entity.Property(c => c.FullName).IsRequired();
                entity.Property(c => c.NationalId).IsRequired();
                entity.Property(c => c.PhoneNumber).IsRequired();
                entity.Property(c => c.Email).IsRequired();
                entity.Property(c => c.CustomerType).IsRequired();
                entity.Property(c => c.DateOfBirth).IsRequired();
            }
            );

            modelBuilder.Entity<Transaction>(entity=>
            {
                entity.HasKey(t => t.TransactionNumber);
                entity.Property(t => t.TransactionType).IsRequired();
                entity.Property(t => t.Amount).HasPrecision(18,2).IsRequired();
                entity.Property(t => t.TransactionDate).IsRequired();
                entity.Property(t => t.Note).IsRequired();
            }
            );

            modelBuilder.Entity<CustomerAccount>()
               .HasKey(ca => new { ca.CustomerId, ca.AccountNumber });

            modelBuilder.Entity<Manager>()
               .HasOne(m => m.Branch)
               .WithOne(b => b.Manager)
               .HasForeignKey<Manager>(m => m.BranchCode);

            modelBuilder.Entity<Account>()
               .HasOne(a => a.Branch)
               .WithMany(b => b.Accounts)
               .HasForeignKey(a => a.BranchCode);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Account)
                .WithMany(a => a.Transactions)
                .HasForeignKey(t => t.AccountNumber);

            modelBuilder.Entity<CustomerAccount>()
               .HasOne(ca => ca.Customer)
               .WithMany(c => c.CustomerAccounts)
               .HasForeignKey(ca => ca.CustomerId);

            modelBuilder.Entity<CustomerAccount>()
               .HasOne(ca => ca.Account)
               .WithMany(a => a.CustomerAccounts)
               .HasForeignKey(ca => ca.AccountNumber);
        }

    }
}
