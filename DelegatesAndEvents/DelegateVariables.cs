using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace DelegatesAndEvents
{
    public class DelegateVariables
    {
        Func<string> buyCar;
        Func<string> buyBike;

        public DelegateVariables()
        {
            buyCar = BuyCar;
            buyBike = BuyBike;
        }

        string BuyCar()
        {
            return "Congratulations! You have bought a brand new car";
        }

        string BuyBike()
        {
            return "Congratulations! You have bought a brand new bike";
        }

        [Fact]
        public void BuyCarTest()
        {
            Assert.Equal("Congratulations! You have bought a brand new car", buyCar());
        }

        [Fact]
        public void BuyBikeTest()
        {
            Assert.Equal("Congratulations! You have bought a brand new bike", buyBike());
        }

        [Fact]
        public void AddDelegatesTest()
        {
            Func<string> buyBoth = buyCar + buyBike; //can add delegates. They will be invoked in order.
            var results = buyBoth.GetInvocationList().Select(d => d.DynamicInvoke()).ToArray();
            Assert.Equal("Congratulations! You have bought a brand new car", results[0]);
            Assert.Equal("Congratulations! You have bought a brand new bike", results[1]);
        }
    }
}
