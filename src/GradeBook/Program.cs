using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new InMemoryBook("Scott's book");
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);

           
            var stats = book.GetStatistics();
            
            Console.WriteLine(InMemoryBook.CATEGORY);
            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The low grade is {stats.Low:N1}");
            Console.WriteLine($"The high grade is {stats.High:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }

        private static void EnterGrades(Book book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                    book.AddGrade('A');
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }
            }
        }

        static void OnGradeAdded(Object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }
}
