using System;
using System.Threading;
using Xunit;

namespace DelegatesAndEvents
{
    public class CookingTask
    {
        public delegate string GetFavoriteDishDelegate(long personId);

        GetFavoriteDishDelegate getFavDish;

        public CookingTask()
        {
            getFavDish = GetFavoriteDish;
        }

        public bool CookForPerson(long personId)
        {
            string dish = getFavDish(personId);
            Console.WriteLine("Cooking...");
            Thread.Sleep(1000);
            Console.WriteLine($"Cooked {dish} for {personId}");
            return true;
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
        public void CookingTaskTest(int personId)
        {
            Assert.True(CookForPerson(personId));
        }

        string GetFavoriteDish(long personId)
        {
            switch (personId)
            {
                case 1:
                    return "Noodles";
                case 2:
                    return "Biryani";
                case 3:
                    return "Fish";
                default:
                    return "Ice Cream";
            }
        }
    }
}
