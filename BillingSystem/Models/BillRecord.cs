using System;

namespace BillingSystem.Models
{
    public class BillRecord
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public decimal BillAmount { get; set; }
        public DateTime SubmissionTime { get; set; } = DateTime.Now;
    }
}
