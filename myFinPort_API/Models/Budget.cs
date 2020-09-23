using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myFinPort_API.Models
{
    public class Budget
    {
        public int Id { get; set; }

        public int HouseholdId { get; set; }

        public string OwnerId { get; set; }

        public DateTime Created { get; set; }

        public string BudgetName { get; set; }

        public decimal CurrentAmount { get; set; }
    }
}