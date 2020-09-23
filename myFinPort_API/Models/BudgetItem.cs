using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myFinPort_API.Models
{
    public class BudgetItem
    {
        public int Id { get; set; }

        public int BudgetId { get; set; }

        public DateTime Created { get; set; }

        public string ItemName { get; set; }

        public decimal TargetAmount { get; set; }

        public decimal CurrentAmount { get; set; }

        public bool IsDeleted { get; set; }
    }
}