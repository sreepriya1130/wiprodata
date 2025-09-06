using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    public class Book
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }

        public bool IsBorrowed { get; set; }

        public Book() { }
        public Book(string title, string author, string iSBN)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            IsBorrowed = false;
        }

        public void Borrow()
        {
            IsBorrowed = true;

        }

        public void Return()
        {
            IsBorrowed = false;
        }

        public override string ToString()
        {
            return "Book Title: " + this.Title + "\n" + "Book Author: " + this.Author + "\n" + "Book ISBN: " + this.ISBN;
        }
    }
}
