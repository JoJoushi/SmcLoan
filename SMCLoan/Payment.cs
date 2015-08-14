using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMCLoan
{
    public class Payment
    {
        public DateTime PaidDate { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal InterestAmount { get; set; }
        public decimal PaidPrincipalAmount { get; set; }
        public decimal Outstanding { get; set; }
        public int Days { get; set; }
    }
}
