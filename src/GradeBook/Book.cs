using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        List<double> grades;

        public void addGrade(double grade)
        {
            grades.Add(grade);
        }
    }
}