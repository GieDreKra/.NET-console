// See https://aka.ms/new-console-template for more information
using BookStoreApplication.Models;

Console.WriteLine("Welcome to Bookstore!");
var books=new List<Book>();
while (true) {
    Console.WriteLine("Please enter one command 'Add','List','Delete BookName','Update BookName'");
    var command = Console.ReadLine();
    if (command == "Add") {
        Console.WriteLine("Please enter the book tite:");
        var bookTitle=Console.ReadLine();
        Console.WriteLine("Please enter the book description:");
        var bookDescription = Console.ReadLine();
        Console.WriteLine("Please enter the amount:");
        try
        {
            var bookAmount = Convert.ToInt32(Console.ReadLine());
            var exists = false;
            foreach (var book in books) { if (book.Title == bookTitle) exists = true; };
            if (!exists)
                books.Add(new Book(bookTitle, bookDescription, bookAmount));
            else Console.WriteLine("Book title already exists.");
        }
        catch
        {
            Console.WriteLine("Amount must be a number..");
        }
    }
    if (command == "List")
    {
        foreach (var book in books) { Console.WriteLine($"title:{book.Title},description: {book.Description}, amount:{book.Amount}"); };
    }
    if (command.Contains("Delete"))   {       
        string bookName = command.Split("Delete ", StringSplitOptions.None).Last();
         try
        {
            var item = books.Single(x => x.Title.Equals(bookName));
            books.Remove(item);
        }
        catch { Console.WriteLine("No title ...");  }

    }
    if (command.Contains("Update"))
    {
        string bookName = command.Split("Update ", StringSplitOptions.None).Last();
        if (books.Where(x => x.Title == bookName).Count() == 0)
        {
            Console.WriteLine("No title to update ...");
        }
        else
        {
            Console.WriteLine("Write new book TITLE or leave empty (if no update need):");
            var bookName2 = Console.ReadLine();
            if (bookName2.Count() != 0) {
                books.Where(x => x.Title == bookName).ToList().ForEach(y => y.Title = bookName2);
                bookName=bookName2;
            }
            Console.WriteLine("Write new DESCRIPTION or leave empty (if no update need):");
            var bookName3 = Console.ReadLine();
            if (bookName3.Count() != 0)
                books.Where(x => x.Title == bookName).ToList().ForEach(y => y.Description = bookName3);
            Console.WriteLine("Write new AMOUNT or leave empty (if no update need):");
            try
            {
                var bookName4 = Console.ReadLine();
                if (bookName4.Count() != 0)
                    books.Where(x => x.Title == bookName).ToList().ForEach(y => y.Amount = Convert.ToInt32(bookName4));
            }
            catch { Console.WriteLine("Amount must be a number.."); }

        }

    }
}
