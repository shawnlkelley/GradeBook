using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{

    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public abstract class Book : NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
            }
        }

        public override Statistics GetStatistics()
        {
            
            var grades = new List<double>();
            using(var reader = File.OpenText($"{Name}.txt"))
            {
                var line =reader.ReadLine();
                while(line != null)
                {
                    var number = double.Parse(line);
                    grades.Add(number);
                    line = reader.ReadLine();
                }
            }

            var result = new Statistics();

            result.CalcStatistics(grades);
            return result;
        }
    }
    public class InMemoryBook : Book
    {
        private List<double> grades;


        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
        }

        public void AddGrade(char grade)
        {
            // method overloading C# looks at methods by their signiture this allows for methods with the same name but different input types
            switch (grade)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }
        public override void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            }
            else
            {
                throw new ArgumentException($"{grade} is invalid please enter a number between 0 and 100");
            }
            
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            result.CalcStatistics(grades);
            return result;
        }

    }

    internal interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }

    }
}
