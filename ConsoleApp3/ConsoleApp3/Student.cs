using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }
        //galime turėti to pačio vardo funkcijas, jei skiriasi parametrų kiekis arba jų tipai
        public Student()
        {
           
        }
        public Student(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }
        public Student(string name, int age,string surname)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Grade = 1;
        }
        public Student(string name, string surname="Pavarde")
        {
            Name = name;
            Surname = surname;
            Age = 89;
            Grade = 1;
        }


        //perrasom nes ToString yra default funkcija
        public override string ToString()
        {
            return "Studento vardas:"+Name+" Pavarde:" +Surname+" Amzius:"+Age;
        }
        public static void sayBye()
        {
            Console.WriteLine("Bye");
        }
    }
}
