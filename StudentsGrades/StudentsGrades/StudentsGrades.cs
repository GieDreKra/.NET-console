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
             },
                new Student() {
                Id = Student.IdCounter++,
                Name = "Testas2",
                Surname = "Testauskas2",
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
                var avgM = Math.Round(st.Grades.Math.Average(), 2);
                var avgB = Math.Round(st.Grades.Biology.Average(), 2);
                var info = StudentInfoPrint(st) + $", Math average: {avgM}, Biology average: {avgB}\n";
                return info;
            }
            else { return "Student ID not found .."; }
        }

        public string Find(List<string> studentList, string subject)
        {
            try
            {
                List<Student> studentsOrder = new List<Student>();
                if (subject == "Math")
                {
                    studentsOrder = Students.OrderByDescending(x => x.Grades.Math.Average()).ToList();
                    foreach (var student in studentsOrder)
                    {
                        foreach (var id in studentList)
                        {
                            if (student.Id == Convert.ToInt32(id))
                            {
                                return StudentInfoPrint(student) + $", average {subject} is: {Math.Round(student.Grades.Math.Average(), 2)}";

                            };
                        };
                    };
                }
                else if (subject == "Biology")
                {
                    studentsOrder = Students.OrderByDescending(x => x.Grades.Biology.Average()).ToList();
                    foreach (var student in studentsOrder)
                    {
                        foreach (var id in studentList)
                        {
                            if (student.Id == Convert.ToInt32(id))
                            {
                                return StudentInfoPrint(student) + $", average {subject} is: {Math.Round(student.Grades.Biology.Average(), 2)}";
                            };
                        };
                    };
                }
                else
                {
                    return "No subject found ..";
                }
            }
            catch (Exception ex)
            {
                return "Students list is not correct..";
            }
            return "No students found ..";
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
            if (av > 0)
            {
                var info = StudentInfoPrint(stMax) + $", average {subject} in class {classGrade} is: {av}";
                return info;
            }
            else
            {
                return "No students found ..";
            }
        }

        public string Find(List<string> studentList)
        {
            List<Student> studentsOrder = new List<Student>();
            try
            {
                studentsOrder = Students.OrderByDescending(x => (x.Grades.Math.Average() + x.Grades.Biology.Average())).ToList();
                foreach (var student in studentsOrder)
                {
                    foreach (var id in studentList)
                    {
                        if (student.Id == Convert.ToInt32(id))
                        {
                            var info = StudentInfoPrint(student) + $", average best in Math and Biology is: " +
                                $"{Math.Round(((student.Grades.Math.Average() + student.Grades.Biology.Average()) / 2), 2)}";
                            return info;
                        };
                    };
                };
            }
            catch
            {
                return "Students list is not correct..";
            }
            return "No students found ..";
        }

        public string Find(List<string> studentList, int classGrade)
        {
            List<Student> studentsOrder = new List<Student>();
            try
            {
                studentsOrder = Students.OrderByDescending(x => (x.Grades.Math.Average() + x.Grades.Biology.Average())).Where(y => y.ClassGrade == classGrade).ToList();
                foreach (var student in studentsOrder)
                {
                    foreach (var id in studentList)
                    {
                        if (student.Id == Convert.ToInt32(id))
                        {
                            var info = StudentInfoPrint(student) + $", average best in class {classGrade} in Math and Biology is: " +
                                $"{Math.Round(((student.Grades.Math.Average() + student.Grades.Biology.Average()) / 2), 2)}";
                            return info;
                        };
                    };
                };
            }
            catch
            {
                return "Students list is not correct..";
            }
            return "No students found ..";
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