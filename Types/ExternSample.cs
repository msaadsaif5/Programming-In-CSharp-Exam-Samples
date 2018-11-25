using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Types
{
    static class ExternSample
    {
        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(IntPtr h, string m, string c, int type);

        public static void First()
        {
            string myString;
            Console.Write("Enter your message: ");
            myString = Console.ReadLine();
            MessageBox((IntPtr)0, myString, "My Message Box", 0);
        }


        [DllImport("cmdll.dll", CharSet = CharSet.Unicode)]
        public static extern int Multiply(int first, int second);

        public static int Second()
        {
            Console.WriteLine("Enter integers to multiply");
            int f = Int32.Parse(Console.ReadLine());
            int s = Int32.Parse(Console.ReadLine());

            Directory.SetCurrentDirectory(@"..\..\..\externalCode");
            int result = Multiply(f, s);
            MessageBox((IntPtr)0, "Result: " + result, "My Message Box", 0);
            return result;
        }
    }
}
