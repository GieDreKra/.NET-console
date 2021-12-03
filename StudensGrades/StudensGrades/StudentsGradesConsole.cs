using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsGrades
{
    public class StudentsGradesConsole
    {
        private StudentsGrades _studentsGrades = new StudentsGrades();

        public void ExecuteAdd()
        {
            Console.WriteLine("Please enter Student Name:");
            var name = Console.ReadLine();

            Console.WriteLine("Please enter Student Surname:");
            var surname = Console.ReadLine();

            Console.WriteLine("Please enter Student Grade:");
            try
            {
                var classGrade = Convert.ToInt32(Console.ReadLine());
                _studentsGrades.AddStudent(name, surname, classGrade);
            }
            catch (Exception)
            {
                Console.WriteLine("Grade must be a number");
            }

        }

        public void ExecuteBestAverageAll(string command)
        {
            try
            {
                var classGrade = Convert.ToInt32(command.Split(' ').Last());
                var list = command.Split(new string[] { "{" }, StringSplitOptions.None)[1].Split('}')[0].Trim();
                var studentList = list.Split(',').ToList();
                var info = _studentsGrades.Find(studentList,classGrade);
                Console.WriteLine(info);
            }
            catch
            {
                var list = command.Split(new string[] { "{" }, StringSplitOptions.None)[1].Split('}')[0].Trim();
                var studentList = list.Split(',').ToList();
                var info = _studentsGrades.Find(studentList);
                Console.WriteLine(info);
            }
        }

        public void ExecuteBestAverageIn(string command)
        {
            try
            {
                var commandList = command.Split(' ').ToList();
                var classGrade = Convert.ToInt32(commandList[3]);
                var subject = commandList[2];
                var list = command.Split(new string[] { "{" }, StringSplitOptions.None)[1].Split('}')[0].Trim();
                var studentList = list.Split(',').ToList();
                var info = _studentsGrades.Find(studentList, subject, classGrade);
                Console.WriteLine(info);
            }
            catch
            {
                try
                {
                    var subject = command.Split(' ').Last();
                    var list = command.Split(new string[] { "{" }, StringSplitOptions.None)[1].Split('}')[0].Trim();
                    var studentList = list.Split(',').ToList();
                    var info = _studentsGrades.Find(studentList, subject);
                    Console.WriteLine(info);
                }
                catch
                {
                    Console.WriteLine("Please enter valid students list example {0,1,2 ...}");
                }
            }
        }

        public void ExecuteRemove()
        {
            Console.WriteLine("Please enter Student ID which result to delete:");
            try
            {
                var id = Convert.ToInt32(Console.ReadLine());
                var info = _studentsGrades.RemoveStudent(id);
                Console.WriteLine(info);
            }
            catch (Exception)
            {
                Console.WriteLine("Student ID must be number..");
            }
        }

        public void ExecuteList()
        {
            var info = _studentsGrades.GetStudentsInfo();
            Console.WriteLine(info);
        }

        public void ExecuteSelect()
        {
            Console.WriteLine("Please enter Student ID which result to display:");
            try
            {
                var id = Convert.ToInt32(Console.ReadLine());
                var info = _studentsGrades.GetStudentInfo(id);
                Console.WriteLine(info);
            }
            catch (Exception)
            {
                Console.WriteLine("Student ID must be number..");
            }
        }
    }
}
