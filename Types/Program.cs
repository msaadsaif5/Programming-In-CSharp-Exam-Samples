using System;

namespace Types
{
    class Program
    {
        static void Main(string[] args)
        {
            ExternSample.First();
            ExternSample.Second();

            TypeConversions.FloatConversion();
            TypeConversions.IntegerConversion();
            TypeConversions.ArrayConversion();

            TypeConversions.ReferenceTypeConversion();

            Console.ReadLine();
        }
    }
}
