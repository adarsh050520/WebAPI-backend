using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Transactions
    {
        public int Id { get; set; }
        public int OrderId  { get; set; }
        public string ModeOfTran { get; set; }
        public string Status { get; set; }
        public string CardNo { get; set; }
        public string TotalCost { get; set; }
    }
}
