using LibraryManagement.Services;
using System;

namespace LibraryManagement
{
    public class LibraryUi
    {
        private readonly BookService bookService;
        private readonly AuthorService authorService;
         

        public LibraryUi(BookService bookService, AuthorService authorService)
        {
            this.bookService = bookService;
            this.authorService = authorService;

        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\n=== Library Menu ===");
                Console.WriteLine("1. Add Author");
                Console.WriteLine("2. Add Book");
                Console.WriteLine("3. Update Book");
                Console.WriteLine("4. Delete Book");
                Console.WriteLine("5. List Books");
                Console.WriteLine("6. List Authors");
                Console.WriteLine("0. Exit");

                Console.Write("Choose: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddAuthor();
                        break;

                    case "2":
                        AddBook();
                        break;

                    case "3":
                        UpdateBook();
                        break;

                    case "4":
                        DeleteBook();
                        break;

                    case "5":
                        ListBooks();
                        break;

                    case "6":
                        ListAuthors();
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
        private void AddAuthor()
        {
            Console.Write("Author name: ");
            var name = Console.ReadLine();

            authorService.AddAuthor(name);
            Console.WriteLine("Author added.");


            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Invalid name.");
                return;
            }
            try
            {
                authorService.AddAuthor(name);
                Console.WriteLine("Author added.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private void AddBook()
        {
            Console.Write("Title: ");
            var title = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Invalid title.");
                return;
            }

            Console.Write("Genre: ");
            var genre = Console.ReadLine();

            Console.Write("Author Id: ");
            int authorId = int.Parse(Console.ReadLine());

            Console.Write("Copies: ");
            int copies = int.Parse(Console.ReadLine());

            bookService.AddBook(title, genre, authorId, copies);
            Console.WriteLine("Book added.");
        }

        private void UpdateBook()
        {
            Console.Write("Book Id: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("New title: ");
            var title = Console.ReadLine();

            Console.Write("New genre: ");
            var genre = Console.ReadLine();

            Console.Write("New author Id: ");
            int authorId = int.Parse(Console.ReadLine());

            Console.Write("New copies: ");
            int copies = int.Parse(Console.ReadLine());

            bookService.UpdateBook(id, title, genre, authorId, copies);
            Console.WriteLine("Book updated.");
        }

        private void DeleteBook()
        {
            Console.Write("Book Id: ");
            int id = int.Parse(Console.ReadLine());

            bookService.DeleteBook(id);
            Console.WriteLine("Book deleted.");
        }

        private void ListBooks()
        {
            var books = bookService.GetAllBooks();

            foreach (var b in books)
            {
                Console.WriteLine($"{b.Id}: {b.Title} ({b.Genre}) - Copies: {b.Copies}");
            }
        }

        private void ListAuthors()
        {
            var authors = authorService.GetAllAuthors();

            foreach (var a in authors)
            {
                Console.WriteLine($"{a.Id}: {a.Name}");
            }
        }
    }
}