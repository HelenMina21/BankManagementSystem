using BankManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
namespace BankManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using BankDbContext dbContext = new();
        }
    }
}
