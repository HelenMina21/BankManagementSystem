using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem.Models
{
    public class Account
    {
        public string AccountNumber { get; set; } = string.Empty;
        public string AccountType { get; set; } = string.Empty;
        public decimal Balance { get; set; } 
        public DateTime OpeningDate { get; set; }

        public string? BranchCode { get; set; }
        public Branch? Branch { get; set; }

        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        public ICollection<CustomerAccount> CustomerAccounts { get; set; }
    = new List<CustomerAccount>();

    }
}
