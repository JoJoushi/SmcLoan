using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMCLoan
{
    public class Bank
    {
        public string Name { get; set; }
        public double InterestRate { get; set; }

        public Bank()
        {

        }

        public Bank(string name, double interestRate)
        {
            this.Name = name;
            this.InterestRate = interestRate;
        }
    }
}
