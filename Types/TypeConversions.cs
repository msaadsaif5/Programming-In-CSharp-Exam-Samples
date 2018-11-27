using System;
using System.Collections.Generic;
using System.Text;

namespace Types
{
    class TypeConversions
    {
        public static void FloatConversion()
        {
            double d = 3.402823E39;
            float f = (float)d;
            Console.WriteLine(f == float.PositiveInfinity ? "Positive Infinity" : f.ToString());
        }

        public static void IntegerConversion()
        {
            Console.WriteLine($"Maximum value of short: {short.MaxValue}");
            int i = 33000;
            short s = (short)i;
            Console.WriteLine($"Integer value: {i}\nShort value: {s}");
        }

        public static void ReferenceTypeConversion()
        {
            Employee emp = new Employee { EmployeeId = 1, Name = "Employee1" };

            Person p = emp;
            p.Name = "Best Employee";

            Employee emp1 = (Employee)p;

            if (p.GetHashCode() == emp.GetHashCode())
                Console.WriteLine("Person and Employee are same objects after conversion.");

            if (p.GetHashCode() == emp1.GetHashCode())
                Console.WriteLine("Person and Employee1 are same objects after conversion.");

            Console.WriteLine($"Employee name after casting to Person and updating its name: {emp.Name}");
        }

        public static void ArrayConversion()
        {
            Employee[] employees = new Employee[10];
            for (int i = 0; i < 10; i++)
            {
                employees[i] = new Employee { Name = $"Employee{i}", EmployeeId = i };
            }

            Person[] persons = employees; //implict converison;

            Employee[] employeesConverted = (Employee[])persons;
        }

        public static void SystemConverstionTest()
        {
            float value = 9.5F;

            //round off rules: 
            //if decimal value is less than 5 then round to previous value
            //if decimal value is greater than 5, then round to next value
            //if decimal value is exactly 5 then round to nearest even number

            int i = Convert.ToInt32(value);
            Console.WriteLine($"9.5 converted to int is {i}");

            value = 10.5F;
            i = Convert.ToInt32(value);
            Console.WriteLine($"10.5 converted to int is {i}");
        }

        public static void ByteConversion()
        {
            int i = 45;
            byte[] bytes = BitConverter.GetBytes(i);

            var isLittleEndian = BitConverter.IsLittleEndian;

            i = BitConverter.ToInt32(bytes, 0);
        }
    }

    class Person
    {
        public string Name { get; set; }
    }
    class Employee : Person
    {
        public int EmployeeId { get; set; }
    }
}
