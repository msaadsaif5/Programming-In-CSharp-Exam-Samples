using System;
using System.Threading;

namespace DelegatesAndEvents
{
    class CookingTask
    {
        public delegate string GetFavoriteDish(long personId);

        GetFavoriteDish getFavDish;

        public CookingTask(GetFavoriteDish getFavoriteDish)
        {
            getFavDish = getFavoriteDish;
        }

        public void CookForPerson(long personId)
        {
            string dish = getFavDish(personId);
            Console.WriteLine("Cooking...");
            Thread.Sleep(1000 * 5);
            Console.WriteLine($"Cooked {dish} for {personId}");
        }
    }
}
