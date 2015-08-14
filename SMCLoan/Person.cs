using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace SMCLoanFacts
{
    class Person
    {
        public double WeightKg { get; set; }
        public double HeightCm { get; set; }

        public double BMI
        {
            get
            {
                return 0;
            }
        }
    }
    public class PersonFacts
    {
        public class BMIProperty
        {

            public void Jenny()
            {
                var jenny = new Person();
                jenny.WeightKg = 50;
                jenny.HeightCm = 160;

                var bmi = jenny.BMI;

                Assert.Equal(19.53, bmi);
            }
        }
    }
}