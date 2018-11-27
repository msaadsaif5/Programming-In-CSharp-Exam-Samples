using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Types
{
    class Parsing
    {
        public static void ParseDecimalTest()
        {
            string justDecimal = "452.63";
            Console.WriteLine($"Just decimal parsed: {decimal.Parse(justDecimal)}");

            string symbolDecimal = "$45,2.63";

            //If you provide any NumberStyles values, any default values are removed. For example, by default
            //decimal.Parse enables thousands and decimal separators. If you pass the value NumberStyles.AllowCurrencySymbol
            //to the method, it no longer enables thousands and decimal separators. To
            //allow all three, you need to pass the method all three values as in the following code:

            decimal symbolDecimalParsed = decimal.Parse(symbolDecimal, NumberStyles.AllowCurrencySymbol | NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint);
            var info = NumberFormatInfo.InvariantInfo;
            Console.WriteLine($"Symbol decimal parsed: {symbolDecimalParsed}");

        }
    }
}
