using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name) { Type = GradeBookType.Ranked; }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count > 5)
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");

            List<Student> orderedList = OrderStudentByGradeDesc(Students);

            int block = GenerateBlock(orderedList.Count);
            for (int i = 0; i < orderedList.Count; i++)
            {
               return SetGrade(i, block);
            }
            return 'F';
        }
        private List<Student> OrderStudentByGradeDesc(List<Student> Students)
        {
            return Students.OrderByDescending(x => x.AverageGrade).ToList();

        }

        private int GenerateBlock(int total)
        {
            double calc = total * 0.2;
            return (int)Math.Round(calc);
        }

        private char SetGrade(int i, int block)
        {
            if (i > block)
                return 'A';
            else if (i > block * 2)
                return 'B';
            else if (i > block * 3)
                return 'C';
            else if (i > block * 4)
                return 'D';
            else
                return 'F';
        }

    }
}
