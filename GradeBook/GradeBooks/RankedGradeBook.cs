using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook.GradeBooks
{
    using Enums;

    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name)
            : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException();

            IEnumerable<Student> students = Students.OrderByDescending(s => s.AverageGrade);

            int fifth = Students.Count / 5;

            if (averageGrade > students.Take(fifth).Last().AverageGrade)
                return 'A';
            if (averageGrade > students.Take(fifth * 2).Last().AverageGrade)
                return 'B';
            if (averageGrade > students.Take(fifth * 3).Last().AverageGrade)
                return 'C';
            if (averageGrade > students.Take(fifth * 4).Last().AverageGrade)
                return 'D';
            return 'F';
        }
    }
}
