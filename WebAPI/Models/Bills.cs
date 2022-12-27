using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Bills
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TransactionId { get; set; }
        public string TransactionMode { get; set; }
        public decimal BillCost { get; set; }
        public DateTime BillDate { get; set; }
        public string BillStatus { get; set; }
        public string BillingAddress { get; set; }
        
    }
}
