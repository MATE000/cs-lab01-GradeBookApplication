using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted) 
        {
            base.Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            //If there are less than 5 students throw an InvalidOperationException
            if (Students.Count < 5) throw new InvalidOperationException();
           

            //how many students make up 20%
            int students = Students.Count * 2/10;

            //average grades (list)
            List<double> averageGrades = Students.Select(n => n.AverageGrade).ToList();

            //
            averageGrades.OrderBy(n => n);


            if (averageGrades[students] < averageGrade)
                return 'A';
            else if (averageGrades[students * 2] < averageGrade)
                return 'B';
            else if (averageGrades[students * 3] < averageGrade)
                return 'C';
            else if (averageGrades[students * 4] < averageGrade)
                return 'D';
            else
                return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)

                Console.WriteLine("Ranked grading requires at least 5 students.");

            else

                base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)

                Console.WriteLine("Ranked grading requires at least 5 students.");

            else

                base.CalculateStudentStatistics(name);
        }
    }
}
