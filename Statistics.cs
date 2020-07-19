using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public class Statistics
    {
        public double Average;
        public double High;
        public double Low;
        public char Letter;
        public double Sum;

        public Statistics()
        {
            Average = 0.0;
            High = double.MinValue;
            Low = double.MaxValue;
            Sum = 0.0;
        }

        public void CalcStatistics(List<double> grades)
        {
            foreach (double grade in grades)
            {
                Low = Math.Min(grade, Low);
                High = Math.Max(grade, High);

                Sum += grade;
            }
            Average = Sum/grades.Count;

            Letter = GetLetterGrade();
            
        }

        private char GetLetterGrade()
        {
            switch (Average)
            {
                case var d when d >= 90.0:
                    return 'A';
                case var d when d >= 80.0:
                    return 'B';
                case var d when d >= 70.0:
                    return 'C';
                case var d when d >= 60.0:
                    return 'D';
                default:
                    return 'F';
            }
        }
    }
}
