using myFinPort_API.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myFinPort_API.Models
{
    public class BankAccount
    {
        public int Id { get; set; }

        public int HouseholdId { get; set; }

        public string OwnerId { get; set; }

        public string AccountName { get; set; }

        public DateTime Created { get; set; }

        public decimal StartingBalance { get; set; }

        public decimal CurrentBalance { get; set; }

        public decimal WarningBalance { get; set; }

        public bool IsDeleted { get; set; }

        public AccountType AccountType { get; set; }

    }
}