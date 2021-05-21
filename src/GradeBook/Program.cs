using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Scott's book");
            book.addGrade(89.1);
            book.addGrade(90.5);
            book.addGrade(77.3);
            var stats = book.GetStatistics();

            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The low grade is {stats.Low:N1}");
            Console.WriteLine($"The high grade is {stats.High:N1}");
        }
    }
}
