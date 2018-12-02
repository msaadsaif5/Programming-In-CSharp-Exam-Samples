using System;

namespace DelegatesAndEvents
{
    class StaticAndInstanceDelegates
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

        public void Run()
        {
            iD(1000, 2);
            sD(1000, 2);
        }

        static decimal CalculateInterestStatic(decimal principal, int years)
        {
            var interest = principal * (INTEREST_RATE_STATIC / 100) * years;
            Console.WriteLine($"Instance delegate interest is {interest}");
            return interest;
        }

        decimal CalculateInterestInstance(decimal principal, int years)
        {
            var interest = principal * (INTEREST_RATE / 100) * years;
            Console.WriteLine($"Instance delegate interest is {interest}");
            return interest;
        }
    }
}
