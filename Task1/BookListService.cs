using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class BookListService
    {
        private List<Book> listBooks = new List<Book>();

        public List<Book> ListBooks
        {
            get { return listBooks; }
            set { listBooks = value; }
        }

        public void AddBook(Book book)
        {
            if (ReferenceEquals(book, null))
                throw new ArgumentNullException(nameof(book));

            foreach (var item in listBooks)
                if (book.Equals(item))
                    throw new ArgumentException();

            listBooks.Add(book);
        }

        public void RemoveBook(Book book)
        {
            if (ReferenceEquals(book, null))
                throw new ArgumentNullException(nameof(book));

            foreach (var item in listBooks)
            {
                if (book.Equals(item))
                {
                    listBooks.Remove(item);
                    return;
                }
            }
            throw new ArgumentException();
        }

        public List<Book> FindBookByTag(object obj, IFind criterion)
        {
            List<Book> findList = new List<Book>();
            findList = listBooks.FindAll(book => criterion.Find(obj, book));

            if (findList.Count == 0)
                throw new ArgumentException();
            else return findList;
        }

        public void SortBooksByTag(IComparer<Book> criterion)
        {
            listBooks.Sort(criterion);
        }
    }
}