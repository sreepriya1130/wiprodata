using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    public class Library
    {
        public List<Book> Books { get; set; }

        public List<Borrower> Borrowers { get; set; }

        public Library()
        {
            Books = new List<Book>();
            Borrowers = new List<Borrower>();
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
            Console.WriteLine("Book added successfully.");

        }

        public void RegisterBorrower(Borrower borrower)
        {
            Borrowers.Add(borrower);
            Console.WriteLine("Borrower registered successfully.");
        }

        public void BorrowBook(string isbn, string libraryCardNumber)
        {
            Book book1 = null;
            //bool flag = false;
            foreach (Book book in this.Books)
            {
                if (book.ISBN == isbn)
                {
                    book1 = book;
                    break;
                }
            }

            Borrower borrower1 = null;
            foreach (Borrower borrower in this.Borrowers)
            {
                if (borrower.LibraryCardNumber == libraryCardNumber)
                {
                    borrower1 = borrower;
                }
            }

            bool status = false;

            status = borrower1.BorrowBook(book1);
            if (status)
            {
                Console.WriteLine("Book Borrowed successfully");
            }
            else
            {
                Console.WriteLine("Book Borrowed failed");
            }
        }

        public void ReturnBook(string isbn, string libraryCardNumber)
        {
            Book book2 = null;
            foreach (Book book in this.Books)
            {
                if (book.ISBN == isbn)
                {
                    book2 = book;
                    break;
                }
            }

            Borrower borrower2 = null;
            foreach (Borrower borrower in this.Borrowers)
            {
                if (borrower.LibraryCardNumber == libraryCardNumber)
                {
                    borrower2 = borrower;
                    break;
                }
            }

            bool status = true;
            status = borrower2.ReturnBook(book2);
            if (status)
            {
                Console.WriteLine("Book returned successfully");
                Console.WriteLine("Book is available for borrowing again");
            }
            else
            {
                Console.WriteLine("Book Returned failed");
            }

        }

        public void ViewBooks()
        {
            foreach (Book book in this.Books)
            {
                Console.WriteLine(book);

            }
        }

        public void ViewBorrowers()
        {
            foreach (Borrower borrower in this.Borrowers)
            {
                Console.WriteLine(borrower);
            }

        }
    }
}
