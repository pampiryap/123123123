using System;
using System.Collections.Generic;
using System.IO;

namespace _123123123
{
    class Program
    {
        static void Main(string[] args)
        {
            LibraryCatalog catalog = new LibraryCatalog();

            // Пример использования
            catalog.AddBook(new Book { Title = "The Catcher in the Rye", Author = "J.D. Salinger", TotalCopies = 5, CopiesOnHand = 3 });
            catalog.AddBook(new Book { Title = "To Kill a Mockingbird", Author = "Harper Lee", TotalCopies = 3, CopiesOnHand = 2 });

            catalog.PrintCatalog();

            catalog.CheckoutBook("The Catcher in the Rye");
            catalog.PrintCatalog();

            catalog.ReturnBook("The Catcher in the Rye");
            catalog.PrintCatalog();

            // Сохранение каталога в файл и загрузка из файла
            catalog.SaveCatalogToFile("catalog.txt");
            catalog.LoadCatalogFromFile("catalog.txt");
            catalog.PrintCatalog();
        }
    }
}
