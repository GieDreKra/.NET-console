using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsGrades
{
    public class StudentsGrades
    {

        private List<Student> Students = new List<Student>()
        {
            new Student() {
                Id = Student.IdCounter++,
                Name = "Jonas",
                Surname = "Jonaitis",
                ClassGrade = 5

                },
             new Student() {
                Id = Student.IdCounter++,
                Name = "Petras",
                Surname = "Petraitis",
                ClassGrade = 10
                },
             new Student() {
                Id = Student.IdCounter++,
                Name = "Testas",
                Surname = "Testauskas",
                ClassGrade = 10
             }
        };

        public string GetStudentsInfo()
        {
            var info = "";
            foreach (var student in Students)
            {
                var studentInfo = StudentInfoPrint(student);
                info = info + studentInfo + "\n";
            }
            return info;
        }

        public string GetStudentInfo(int id)
        {
            var st = new Student();
            st = Students.Find(x => x.Id == id);
            if (st is not null)
            {
                var avgM = st.Grades.Math.Average();
                var avgB = st.Grades.Biology.Average();
                var info = StudentInfoPrint(st) + $", Math average: {avgM}, Biology average: {avgB}\n";
                return info;
            }
            else { return "Student ID not found .."; }
        }

        public string Find(List<string> studentList, string subject)
        {
            double av = 0;
            Student stMax = new Student();
            try
            {
                for (int i = 0; i < studentList.Count; i++)
                {
                    var st = new Student();
                    st = Students.Find(x => x.Id == Convert.ToInt32(studentList[i]));
                    if (st is not null)
                    {
                        if (subject == "Math")
                        {
                            if (st.Grades.Math.Average() > av)
                            {
                                av = st.Grades.Math.Average();
                                stMax = st;
                            }
                        }
                        if (subject == "Biology")
                        {
                            if (st.Grades.Biology.Average() > av)
                            {
                                av = st.Grades.Biology.Average();
                                stMax = st;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return "Students list is not correct..";
            }
            av = Math.Round(av, 2);
            var info = StudentInfoPrint(stMax) + $", average {subject} is: {av}";
            return info;
        }

        public string Find(List<string> studentList, string subject, int classGrade)
        {
            double av = 0;
            Student stMax = new Student();
            try
            {
                for (int i = 0; i < studentList.Count; i++)
                {
                    var st = new Student();
                    st = Students.Find(x => x.Id == Convert.ToInt32(studentList[i]));
                    if (st is not null)
                    {
                        if (subject == "Math" && st.ClassGrade.Equals(classGrade))
                        {
                            if (st.Grades.Math.Average() > av)
                            {
                                av = st.Grades.Math.Average();
                                stMax = st;
                            }
                        }
                        if (subject == "Biology" && st.ClassGrade.Equals(classGrade))
                        {
                            if (st.Grades.Biology.Average() > av)
                            {
                                av = st.Grades.Biology.Average();
                                stMax = st;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return "Students list is not correct..";
            }
            av = Math.Round(av, 2);
            var info = StudentInfoPrint(stMax) + $", average {subject} in class {classGrade} is: {av}";
            return info;
        }

        public string Find(List<string> studentList)
        {
            double av = 0;
            Student stMax = new Student();
            try
            {
                for (int i = 0; i < studentList.Count; i++)
                {
                    var st = new Student();
                    st = Students.Find(x => x.Id == Convert.ToInt32(studentList[i]));
                    if (st is not null)
                    {
                        if ((st.Grades.Math.Average() + st.Grades.Biology.Average()) > av)
                        {
                            av = st.Grades.Math.Average() + st.Grades.Biology.Average();
                            stMax = st;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return "Students list is not correct..";
            }
            av = Math.Round(av / 2, 2);
            var info = StudentInfoPrint(stMax) + $", average best in Math and Biology is: {av}";
            return info;
        }

        public string Find(List<string> studentList, int classGrade)
        {
            double av = 0;
            Student stMax = new Student();
            try
            {
                for (int i = 0; i < studentList.Count; i++)
                {
                    var st = new Student();
                    st = Students.Find(x => x.Id == Convert.ToInt32(studentList[i]));
                    if (st is not null)
                    {
                        if ((st.Grades.Math.Average() + st.Grades.Biology.Average()) > av && (st.ClassGrade.Equals(classGrade)))
                        {
                            av = st.Grades.Math.Average() + st.Grades.Biology.Average();
                            stMax = st;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return "Students list is not correct..";
            }
            av = Math.Round(av / 2, 2);
            var info = StudentInfoPrint(stMax) + $", average best in class {classGrade} in Math and Biology is: {av}";
            return info;
        }

        public string RemoveStudent(int id)
        {
            var st = new Student();
            st = Students.Find(x => x.Id == id);
            if (st is not null)
            {
                Students.Remove(st);
                return "Student was removed.";
            }
            else { return "Student ID not found .."; }
        }

        public string StudentInfoPrint(Student student)
        {
            var studentInfo = $"id:{student.Id}, name:{student.Name}, surname:{student.Surname}, grade:{student.ClassGrade}, math:";
            for (int i = 0; i < student.Grades.Math.Count(); i++)
            {
                studentInfo = studentInfo + student.Grades.Math[i] + " ";
            }
            studentInfo = studentInfo + ", biology:";
            for (int i = 0; i < student.Grades.Biology.Count(); i++)
            {
                studentInfo = studentInfo + student.Grades.Biology[i] + " ";
            }
            return studentInfo;
        }

        public void AddStudent(string name, string surname, int classGrade)
        {
            Students.Add(new Student()
            {
                Id = Student.IdCounter++,
                Name = name,
                Surname = surname,
                ClassGrade = Convert.ToInt32(classGrade)
            });
        }
    }
}
