using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsGrades
{
    public class Student
    {
        public static int IdCounter = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int ClassGrade { get; set; }
        public Grade Grades { get; set; }

        Random rnd = new Random();

        public Student()
        {
            List<int> list1 = new List<int>();
            for (int i = 0; i < rnd.Next(5, 8); i++)
            {
                list1.Add(rnd.Next(1, 11));
            }
            List<int> list2 = new List<int>();
            for (int i = 0; i < rnd.Next(5, 8); i++)
            {
                list2.Add(rnd.Next(1, 11));
            }
            Grades = new Grade() { Math = list1, Biology = list2 };
        }
    }
}
