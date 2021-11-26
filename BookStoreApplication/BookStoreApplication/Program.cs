// See https://aka.ms/new-console-template for more information
using BookStoreApplication.Models;

Console.WriteLine("Welcome to Bookstore!");
var books=new List<Book>();
while (true) {
    Console.WriteLine("Please enter one command 'Add','List','Delete BookName'");
    var command = Console.ReadLine();
    if (command == "Add") {
        Console.WriteLine("Please enter the book tite:");
        var bookTitle=Console.ReadLine();
        Console.WriteLine("Please enter the book description:");
        var bookDescription = Console.ReadLine();
        Console.WriteLine("Please enter the amount:");
        var bookAmount = Convert.ToInt32(Console.ReadLine());
        var exists=false;
        foreach (var book in books) { if (book.Title == bookTitle) exists = true; };
        if (!exists)
            books.Add(new Book(bookTitle, bookDescription, bookAmount));
        else Console.WriteLine("Book title already exists.");
    }
    if (command == "List")
    {
        foreach (var book in books) { Console.WriteLine($"title:{book.Title},description: {book.Description}, amount:{book.Amount}"); };
    }
    if (command.Contains("Delete"))   {       
        string bookName = command.Split(new string[] { "Delete " }, StringSplitOptions.None).Last();
        try
        {
            var item = books.Single(x => x.Title.Contains(bookName));
            books.Remove(item);
        }
        catch { Console.WriteLine("No title ...");  }

    }
    

}
