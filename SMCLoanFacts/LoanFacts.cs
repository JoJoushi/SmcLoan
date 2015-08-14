using SMCLoan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SMCLoanFacts
{
    public class LoanFacts
    {
        public class PayMethod
        {
            [Fact]
            public void DifferentYearPayment_HaveCorrectDays()
            {
                var loan = new Loan(1000000, 1000000, new Bank() { InterestRate = 7 }, new DateTime(2014, 12, 20));
                var p = loan.Pay(new DateTime(2015, 1, 20), 10000);
                Assert.Equal(31, p.Days);
            }

            [Fact]
            public void FirstPay()
            {
             //arrange                
               Bank bank = new Bank("SMC", 7.0);
               Loan loan = new Loan(1000000, 1000000, bank, new DateTime(2015, 7, 1));                                 
               
               // act
               var d = new DateTime(2015, 8, 1);
               var payment = loan.Pay(d, 10000);

               // assert
               Assert.NotNull(payment);
               Assert.Equal(31, payment.Days);
               Assert.Equal(10000, payment.PaidAmount);
               Assert.Equal(d, payment.PaidDate);

               Assert.Equal(5945.21m, payment.InterestAmount);
               Assert.Equal(4054.79m, payment.PaidPrincipalAmount);
               Assert.Equal(995945.21m, payment.Outstanding);
               
               Assert.Equal(d, loan.LastPayDate);
               Assert.Equal(995945.21m, loan.Outstanding);
            }

            [Fact]
            public void PaidAmountIsNotEnoughForInterest()
            {
                // arrange       
                Loan loan = new Loan(
                  principal: 1000000,
                  outstanding: 1000000,
                  previousOwner: new Bank("TEST BANK", 7.0),
                  lastPayDate: new DateTime(2015, 7, 1)); // 1 Jul, 2015.          

                // act
                var d1 = new DateTime(2015, 8, 1);
                var payment1 = loan.Pay(d1, 3000);
             
                // assert
                Assert.NotNull(d1);
                Assert.Equal(31, payment1.Days);
                Assert.Equal(3000m, payment1.PaidAmount);
                Assert.Equal(d1, payment1.PaidDate);

                Assert.Equal(3000m, payment1.InterestAmount);
                Assert.Equal(0m, payment1.PaidPrincipalAmount);
                Assert.Equal(1000000m, payment1.Outstanding);
                Assert.Equal(2945.21m, loan.Accrued);              

                var d2 = new DateTime(2015, 9, 1);
                var payment2 = loan.Pay(d2, 10000);

                Assert.NotNull(payment2);
                Assert.Equal(31, payment2.Days);
                Assert.Equal(10000, payment2.PaidAmount);
                Assert.Equal(d2, payment2.PaidDate);

                Assert.Equal(8890.42m, payment2.InterestAmount);
                Assert.Equal(1109.58m, payment2.PaidPrincipalAmount);
                Assert.Equal(998890.42m, payment2.Outstanding);
                Assert.Equal(0m, loan.Accrued);

                Assert.Equal(d2, loan.LastPayDate);
                Assert.Equal(998890.42m, loan.Outstanding);
                
            }

            [Fact]
            public void PaidDateIsBeforeLastPayDate_ThrowsException()
            {
                // arrange       
                Loan loan = new Loan(
                  principal: 1000000,
                  outstanding: 1000000,
                  previousOwner: new Bank("TEST BANK", 7.0),
                  lastPayDate: new DateTime(2015, 7, 1)); // 1 Jul, 2015.          

                var ex = Assert.ThrowsAny<Exception>(() =>
                {
                    loan.Pay(new DateTime(2015, 6, 15), 10000m);
                });

                Assert.Contains("Last Pay Date is 2015-07-01",ex.Message);
            }
        }
    }
}
