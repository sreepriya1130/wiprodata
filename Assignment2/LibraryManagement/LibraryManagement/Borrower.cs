using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    public class Borrower
    {
        public string Name { get; set; }

        public string LibraryCardNumber { get; set; }

        public List<Book> BorrowedBooks { get; set; }

        public Borrower()
        {

        }
        public Borrower(string name, string libraryCardNumber)
        {
            this.Name = name;
            this.LibraryCardNumber = libraryCardNumber;
            this.BorrowedBooks = new List<Book>();

        }

        public bool BorrowBook(Book book)
        {
            this.BorrowedBooks.Add(book);
            book.Borrow();
            return true;
        }

        public bool ReturnBook(Book book)
        {
            //List<Book> booksList = new List<Book>(this.BorrowedBooks);
            foreach (Book books in this.BorrowedBooks)
            {
                if (books.ISBN == book.ISBN)
                {
                    this.BorrowedBooks.Remove(book);
                    book.Return();
                    return true;

                }
            }
            return false;

        }

        public override string ToString()
        {
            return "Borrower name: " + this.Name + "\n" + "Library Card Number: " + this.LibraryCardNumber;
        }
    }
}
