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

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(t => t.TransactionNumber);
                entity.Property(t => t.TransactionType).IsRequired();
                entity.Property(t => t.Amount).HasPrecision(18, 2).IsRequired();
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


            //DATA SEEDING
            modelBuilder.Entity<Branch>().HasData(
    new Branch
    {
        Code = "B001",
        Name = "Main Branch",
        Address = "Cairo",
        PhoneNumber = "01000000000"
    },
    new Branch
    {
        Code = "B002",
        Name = "Nasr City Branch",
        Address = "Nasr City",
        PhoneNumber = "01100000000"
    }
);

            modelBuilder.Entity<Manager>().HasData(
    new Manager
    {
        Id = 1,
        FullName = "Ahmed Hassan",
        Email = "ahmed.hassan@bank.com",
        PhoneNumber = "01011111111",
        HireDate = new DateTime(2020, 1, 15),
        BranchCode = "B001"
    },
    new Manager
    {
        Id = 2,
        FullName = "Sara Mohamed",
        Email = "sara.mohamed@bank.com",
        PhoneNumber = "01022222222",
        HireDate = new DateTime(2021, 6, 10),
        BranchCode = "B002"
    }
);

            modelBuilder.Entity<Customer>().HasData(
    new Customer
    {
        Id = 1,
        FullName = "Mohamed Ali",
        Email = "mohamed.ali@email.com",
        CustomerType = "Individual",
        Address = "Cairo",
        NationalId = "29505201234567",
        PhoneNumber = "01033333333",
        DateOfBirth = new DateTime(1995, 5, 20)

    },
    new Customer
    {
        Id = 2,
        FullName = "Mariam Adel",
        Email = "mariam.adel@email.com",
        CustomerType = "Individual",
        Address = "Giza",
        NationalId = "29808121234567",
        PhoneNumber = "01044444444",
        DateOfBirth = new DateTime(1998, 8, 12)
    }
);

            modelBuilder.Entity<Account>().HasData(
    new Account
    {
        AccountNumber = "ACC001",
        AccountType = "Savings",
        Balance = 15000.00m,
        OpeningDate = new DateTime(2023, 1, 10),
        BranchCode = "B001"
    },
    new Account
    {
        AccountNumber = "ACC002",
        AccountType = "Current",
        Balance = 25000.00m,
        OpeningDate = new DateTime(2023, 5, 15),
        BranchCode = "B002"
    }
);

            modelBuilder.Entity<CustomerAccount>().HasData(
    new CustomerAccount
    {
        CustomerId = 1,
        AccountNumber = "ACC001",
        OwnershipType = "Primary",
        OwnershipStartDate = new DateTime(2023, 1, 10),
        AccountStatus = "Active"
    },
    new CustomerAccount
    {
        CustomerId = 1,
        AccountNumber = "ACC002",
        OwnershipType = "Primary",
        OwnershipStartDate = new DateTime(2023, 5, 15),
        AccountStatus = "Active"
    },
    new CustomerAccount
    {
        CustomerId = 2,
        AccountNumber = "ACC002",
        OwnershipType = "CoHolder",
        OwnershipStartDate = new DateTime(2023, 5, 15),
        AccountStatus = "Active"
    }
);

            modelBuilder.Entity<Transaction>().HasData(
    new Transaction
    {
        TransactionNumber = 1,
        TransactionDate = new DateTime(2023, 2, 15),
        Note = "Initial deposit",
        TransactionType = "Deposit",
        Amount = 5000.00m,
        AccountNumber = "ACC001"
    },
    new Transaction
    {
        TransactionNumber = 2,
        TransactionDate = new DateTime(2023, 6, 1),
        Note = "ATM withdrawal",
        TransactionType = "Withdrawal",
        Amount = 2000.00m,
        AccountNumber = "ACC002"
    },
    new Transaction
    {
        TransactionNumber = 3,
        TransactionDate = new DateTime(2023, 6, 10),
        Note = "Monthly payment",
        TransactionType = "Payment",
        Amount = 1000.00m,
        AccountNumber = "ACC002"
    }
);
        }

    }
}
