using myFinPort_API.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myFinPort_API.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        public int AccountId { get; set; }

        public int? BudgetItemId { get; set; }

        public string OwnerId { get; set; }

        public TransactionType TransactionType { get; set; }

        public DateTime Created { get; set; }

        public decimal Amount { get; set; }

        // this will be things like McDonalds, Gas Bill, Car payment, etc.
        public string Memo { get; set; }

        public bool IsDeleted { get; set; }

    }
}