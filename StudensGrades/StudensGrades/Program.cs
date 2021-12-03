// See https://aka.ms/new-console-template for more information
using StudentsGrades;

Console.WriteLine("Hello, World!");

var studentsGradesConsole = new StudentsGradesConsole();
while (true)
{
    Console.WriteLine("Please select command 'Add', 'List', 'Select', 'Remove',");
    Console.WriteLine("'BestAverageIn {Students ID list} Subject Class', 'BestAverageAll {Students ID list} Class'");

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
    if (command.Contains("BestAverageIn"))
    {
        studentsGradesConsole.ExecuteBestAverageIn(command);
    }
    if (command.Contains("BestAverageAll"))
    {
        studentsGradesConsole.ExecuteBestAverageAll(command);
    }
}