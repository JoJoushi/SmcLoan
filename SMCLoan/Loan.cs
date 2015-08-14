using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMCLoan
{
    public class Loan
    {
        public decimal Principle { get; set; }
        public decimal Outstanding { get; set; }
        public decimal Accrued { get; set; }
        public DateTime LastPayDate { get; set; }
        public Bank PreviousOwner { get; set; }

        public Loan()
        {
        }

        public Loan(decimal principal, decimal outstanding, Bank previousOwner, DateTime lastPayDate)
        {
            this.Principle = principal;
            this.Outstanding = outstanding;
            this.PreviousOwner = previousOwner;
            this.LastPayDate = lastPayDate;
        }

        public Payment Pay(DateTime date, decimal amount)
        {
            if (date < this.LastPayDate)
            {
                string s = @"Paid date can not before the last pay date.
                Last Pay Date is " + this.LastPayDate.ToString("yyyy-MM-dd");
                throw new ArgumentException(s, "date"); // nameof(date)
            }

            var pay = new Payment();
            pay.Days = (date.Date - LastPayDate.Date).Days;
            pay.PaidDate = date;
            pay.PaidAmount = amount;

            pay.InterestAmount = Math.Round((this.Outstanding * (decimal)PreviousOwner.InterestRate) * pay.Days / 36500,2, MidpointRounding.AwayFromZero);
            if (this.Accrued != 0)
                pay.InterestAmount += this.Accrued;

            if (amount <= pay.InterestAmount)
            {
                this.Accrued = Math.Round(pay.InterestAmount - amount,2, MidpointRounding.AwayFromZero);
                pay.InterestAmount = amount;
            }

            if (pay.InterestAmount >= amount)
                pay.PaidPrincipalAmount = 0;
            else
            {
                this.Accrued = 0;
                pay.PaidPrincipalAmount = amount - pay.InterestAmount;
            }
            
            pay.Outstanding = this.Outstanding - pay.PaidPrincipalAmount;
            this.Outstanding = pay.Outstanding;
            this.LastPayDate = date;
            return pay; 
        }        
    }
}
