using System;
using Xunit;

namespace DelegatesAndEvents
{
    public class StaticAndInstanceDelegates
    {
        public decimal INTEREST_RATE = 4.8M;
        public static decimal INTEREST_RATE_STATIC = 5M;

        public delegate decimal InstanceDelegae(decimal principal, int years);
        public delegate decimal StaticDelegae(decimal principal, int years);

        InstanceDelegae iD;
        StaticDelegae sD;

        public StaticAndInstanceDelegates()
        {
            iD = CalculateInterestInstance;
            sD = CalculateInterestStatic;
        }

        static decimal CalculateInterestStatic(decimal principal, int years)
        {
            return principal * (INTEREST_RATE_STATIC / 100) * years;
        }

        decimal CalculateInterestInstance(decimal principal, int years)
        {
            return principal * (INTEREST_RATE / 100) * years;
        }

        [Fact]
        public void StaticDelegateMethodTest()
        {
            Assert.Equal(1000 * (INTEREST_RATE_STATIC / 100) * 2, sD(1000, 2));
        }

        [Fact]
        public void InstanceDelegateMethodTest()
        {
            Assert.Equal(1000 * (INTEREST_RATE / 100) * 2, iD(1000, 2));
        }
    }
}
