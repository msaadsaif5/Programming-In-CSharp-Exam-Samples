using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesAndEvents
{
    class DelegateVariables
    {
        Action buyCar;
        Action buyBike;

        public DelegateVariables()
        {
            buyCar = BuyCar;
            buyBike = BuyBike;
        }

        public void BuyVehicle(bool? isCarOrBike)
        {
            if (isCarOrBike == null)
            {
                Action buyBoth = buyCar + buyBike; //can add action delegates. They will be invoked in order.
                buyBoth();
            }
            else if (isCarOrBike.HasValue && isCarOrBike.Value)
            {
                buyCar();
            }
            else
            {
                buyBike();
            }
        }

        void BuyCar()
        {
            Console.WriteLine("Congratulations! You have bought a brand new car");
        }

        void BuyBike()
        {
            Console.WriteLine("Congratulations! You have bought a brand new bike");
        }
    }
}
