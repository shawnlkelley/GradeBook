using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("Scott's Grade Book");

            
            EnterGrades(book);

            var stats = book.GetStatistics();

            Console.WriteLine($"{book.Name}.");
            Console.WriteLine($"The average grade is {stats.Average:N1}.");
            Console.WriteLine($"The lowest grade is {stats.High}.");
            Console.WriteLine($"The highest grade is {stats.Low}.");
            Console.WriteLine($"The letter grade is {stats.Letter}.");
        }

        private static void EnterGrades(IBook book)
        {
            var done = false;
            while (!done)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    done = true;
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }

            }
        }
    }
}
