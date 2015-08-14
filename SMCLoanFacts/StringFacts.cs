using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SMCLoanFacts
{
    public class StringFacts
    {
        public class LengthProperty
        {
            [Fact(Skip="Just demo")]
            public void EmptyString_ShouldHaveZeroLength()
            {
                // arrange
                string s = string.Empty;

                // act1
                int n = s.Length;

                // assert
                Assert.Equal(0, n);
            }
        }
    }
}
