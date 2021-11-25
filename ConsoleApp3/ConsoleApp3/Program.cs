using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student studentas0 = new Student("giedre", "krasauske", 38);
            Student studentas = new Student();
            studentas.Name = "Petras";
            studentas.Surname = "Petrauskas";
            studentas.Age = 34;
            Console.WriteLine(studentas);

            Student studentas2 = new Student();
            studentas2.Name = "Petras2";
            studentas2.Surname = "Petrauskas2";
            studentas2.Age = 3;
            Console.WriteLine(studentas2.ToString());
            //statinese nekvieciami objektai
            sayHi();
            //statinis metodas iškviečiamas per klasę
            Student.sayBye();

            List<Student> students = new List<Student>() { studentas, studentas0, studentas2 };
        
            students.ForEach(s=>Console.WriteLine(s));        
        }
        public static void sayHi()
        {
            Console.WriteLine("Hello");
        }
    }
}
