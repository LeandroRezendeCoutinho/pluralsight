using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] { 12.7, 10.3, 6.11, 4.1 };

            var result = 0.0;
            foreach (var number in numbers)
            {
                result += number;
            }
            Console.WriteLine($"The average grade is {result}");
        }
    }
}
