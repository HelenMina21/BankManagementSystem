Bank Management System

An Entity Framework Core Code-First project for managing a banking system.

*Project Overview

The National Bank Group operates multiple branches and needs a reliable system to manage:

- Bank branches and their managers
- Customers (Individuals and Businesses)
- Bank accounts
- Joint account ownership
- Account transactions and transaction history

This project focuses on building the EF Core Code-First data layer that can later be integrated with an application.

*Technologies

- C#
- .NET
- Entity Framework Core
- SQL Server
- LINQ
- Fluent API
- Code First Migrations

*Database Structure

The system contains the following main entities:

- Branch
- Manager
- Customer
- Account
- CustomerAccount
- Transaction

"CustomerAccount" represents the relationship between customers and accounts and stores information such as ownership type, ownership start date, and account status.

*Main Relationships

- One Branch manages many Accounts.
- Each Account belongs to one Branch.
- Each Branch has one Manager.
- One Account can have many Transactions.
- Customers can own multiple Accounts.
- An Account can be shared by multiple Customers through "CustomerAccount".

*EF Core Features

The project demonstrates:

- Entity classes based on an ER diagram
- Relationships between entities
- Fluent API configuration
- Primary and foreign keys
- Code First Migrations
- Database generation
- Seed data
- LINQ queries
- CRUD operations
- Navigation properties and related data loading

*Seed Data

Initial data is seeded into the database, including data for:

- Branches
- Managers

Additional test data can be added for customers, accounts, and transactions.

*Console Application

The application provides an interactive menu with the following operations:

1. Add a new Customer
2. Open a new Account for a Customer
3. Update Account Status
4. Remove an Account from a Customer
5. List all Customers with their Accounts
6. Exit

The application validates user input and handles invalid input without crashing.

*Business Rules

When opening an account:

- The selected Branch must exist.
- The Customer(s) must already be registered.
- Joint accounts must contain all participating customers as account owners.

For transactions:

- Deposits increase the account balance.
- Withdrawals and payments decrease the account balance.
- Every transaction is linked to the account it affects.

*Project Purpose

This project was developed as part of the Route ASP.NET Course – EF Core to practice building a complete Code-First database layer using Entity Framework Core.
