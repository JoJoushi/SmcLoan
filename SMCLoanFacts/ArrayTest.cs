using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SMCLoanFacts
{
    public class ArrayTest : IDisposable
    {
        private static List<int> data;

        public ArrayTest()
        {
            data = new List<int>();
        }

        [Fact]
        public void Initial_HasNoData()
        {
            Assert.Equal(0, data.Count);
        }

        [Fact]
        public void AddTwoItems_HasTwoItems()
        {
            data.Add(10);
            data.Add(20);
            Assert.Equal(2, data.Count);
        }

        [Fact]
        public void AddDuplicateThreeItems_HasThreeItems()
        {
            data.Add(10);
            data.Add(10);
            data.Add(10);
            Assert.Equal(3, data.Count);
        }

        public void Dispose()
        {
            data.Clear();
        }
    }
}
