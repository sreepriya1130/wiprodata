using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_2;
using NUnitBookTest;

namespace NUnitBookTest
{
    [TestFixture]
    public class LibraryTests
    {
        private Library library = null!;
        private Book book = null!;
        private Borrower borrower = null!;

        [SetUp]
        public void SetUp()
        {
            library = new Library();
            book = new Book("Clean Code", "Robert C. Martin", "9780132350884");
            borrower = new Borrower("Alice", "CARD-001");
        }

        [Test]
        public void AddBook_BookAppearsInBooksCollection()
        {
            library.AddBook(book);
            Assert.Contains(book, library.Books.ToList());
        }

        [Test]
        public void RegisterBorrower_BorrowerAppearsInBorrowersCollection()
        {
            library.RegisterBorrower(borrower);
            Assert.Contains(borrower, library.Borrowers.ToList());
        }

        [Test]
        public void BorrowBook_SetsIsBorrowedAndAddsToBorrower()
        {
            library.AddBook(book);
            library.RegisterBorrower(borrower);

            library.BorrowBook(book.ISBN, borrower.LibraryCardNumber);

            Assert.IsTrue(book.IsBorrowed);
            Assert.Contains(book, borrower.BorrowedBooks.ToList());
        }

        [Test]
        public void ReturnBook_ClearsIsBorrowedAndRemovesFromBorrower()
        {
            library.AddBook(book);
            library.RegisterBorrower(borrower);
            library.BorrowBook(book.ISBN, borrower.LibraryCardNumber);

            library.ReturnBook(book.ISBN, borrower.LibraryCardNumber);

            Assert.IsFalse(book.IsBorrowed);
            Assert.IsFalse(borrower.BorrowedBooks.Contains(book));
        }

        [Test]
        public void Collections_HaveCorrectCountsAfterOperations()
        {
            library.AddBook(book);
            library.RegisterBorrower(borrower);

            Assert.AreEqual(1, library.Books.Count);
            Assert.AreEqual(1, library.Borrowers.Count);
        }
    }


}
