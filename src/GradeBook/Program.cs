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
            book.addGrade(77.5);
            book.showStatistics();
        }
    }
}
