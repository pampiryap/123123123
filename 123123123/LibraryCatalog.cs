using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _123123123
{
    class LibraryCatalog
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void RemoveBook(string title)
        {
            books.RemoveAll(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }

        public Book FindBookByTitle(string title)
        {
            return books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }

        public Book FindBookByAuthor(string author)
        {
            return books.Find(b => b.Author.Equals(author, StringComparison.OrdinalIgnoreCase));
        }

        public void PrintCatalog()
        {
            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Total Copies: {book.TotalCopies}, Copies On Hand: {book.CopiesOnHand}");
            }
        }

        public void SaveCatalogToFile(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var book in books)
                {
                    writer.WriteLine($"{book.Title},{book.Author},{book.TotalCopies},{book.CopiesOnHand}");
                }
            }
        }

        public void LoadCatalogFromFile(string filename)
        {
            books.Clear();
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    Book book = new Book
                    {
                        Title = parts[0],
                        Author = parts[1],
                        TotalCopies = int.Parse(parts[2]),
                        CopiesOnHand = int.Parse(parts[3])
                    };
                    books.Add(book);
                }
            }
        }

        public void CheckoutBook(string title)
        {
            Book book = FindBookByTitle(title);
            if (book != null && book.CopiesOnHand > 0)
            {
                book.CopiesOnHand--;
                Console.WriteLine($"Book '{title}' checked out successfully.");
            }
            else
            {
                Console.WriteLine($"Book '{title}' is not available for checkout.");
            }
        }

        public void ReturnBook(string title)
        {
            Book book = FindBookByTitle(title);
            if (book != null && book.CopiesOnHand < book.TotalCopies)
            {
                book.CopiesOnHand++;
                Console.WriteLine($"Book '{title}' returned successfully.");
            }
            else
            {
                Console.WriteLine($"Book '{title}' cannot be returned.");
            }
        }
    }
}
