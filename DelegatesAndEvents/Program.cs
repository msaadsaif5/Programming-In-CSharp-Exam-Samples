using System;

namespace DelegatesAndEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = new CookingTask(GetFavoriteDish);
            task.CookForPerson(1);
            task.CookForPerson(2);
            task.CookForPerson(9);

            Console.ReadLine();
        }

        static string GetFavoriteDish(long personId)
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
