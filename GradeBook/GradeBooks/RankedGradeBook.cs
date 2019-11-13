using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook.GradeBooks
{
    using Enums;

    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted)
            : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException();

            IEnumerable<Student> students = Students.OrderByDescending(s => s.AverageGrade);

            int aCount = (int)Math.Ceiling(Students.Count * 0.2);
            int bCount = (int)Math.Ceiling(Students.Count * 0.4);
            int cCount = (int)Math.Ceiling(Students.Count * 0.6);
            int dCount = (int)Math.Ceiling(Students.Count * 0.8);

            if (averageGrade >= students.Take(aCount).Last().AverageGrade)
                return 'A';
            if (averageGrade >= students.Take(bCount).Last().AverageGrade)
                return 'B';
            if (averageGrade >= students.Take(cCount).Last().AverageGrade)
                return 'C';
            if (averageGrade >= students.Take(dCount).Last().AverageGrade)
                return 'D';
            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }
    }
}
