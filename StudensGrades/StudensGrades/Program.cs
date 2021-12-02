// See https://aka.ms/new-console-template for more information
using StudentsGrades;

Console.WriteLine("Hello, World!");

var studentsGradesConsole = new StudentsGradesConsole();
while (true)
{
    Console.WriteLine("Please select command 'Add', 'List', 'Select', 'Remove', 'Find {Students ID list} Subject' ");
    var command = Console.ReadLine();
    if (command == "Add")
    {
        studentsGradesConsole.ExecuteAdd();
    }
    if (command == "List")
    {
        studentsGradesConsole.ExecuteList();
    }
    if (command == "Select")
    {
        studentsGradesConsole.ExecuteSelect();
    }
    if (command == "Remove")
    {
        studentsGradesConsole.ExecuteRemove();
    }
    if (command.Contains("Find"))
    {
        studentsGradesConsole.ExecuteFind(command);
    }

}