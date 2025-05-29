using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

    public class Transaction
    {
        // Unique ID for the transaction
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; } = null!;

        public DateTime Date { get; set; }

        public bool IsIncome { get; set; }

        public User? User { get; set; }
    }
}
