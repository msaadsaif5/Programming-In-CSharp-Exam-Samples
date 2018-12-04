using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DelegatesAndEvents
{
    public class LambaExpressions
    {
        delegate int AddDelegate(int a, int b);
        Func<double> GetValueOfPie;

        [Fact]
        public void TestLambaOnFunc()
        {
            GetValueOfPie = () => Math.PI;
            Assert.Equal(Math.PI, GetValueOfPie());
        }

        [Fact]
        public void TestLambdaExpression()
        {
            AddDelegate addAnonymousMethod = (a, b) => a + b;

            Assert.Equal(7, addAnonymousMethod(3, 4));
        }

        [Fact]
        public void TestAnonymousMethod()
        {
            AddDelegate addAnonymousMethod = delegate (int a, int b)
            {
                return a + b;
            };

            Assert.Equal(7, addAnonymousMethod(3, 4));
        }
    }
}
