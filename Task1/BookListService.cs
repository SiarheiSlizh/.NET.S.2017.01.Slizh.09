using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Task1
{
    /// <summary>
    /// Class manages books
    /// </summary>
    public class BookListService
    {
        #region private fields
        /// <summary>
        /// List of books
        /// </summary>
        private List<Book> listBooks = new List<Book>();

        /// <summary>
        /// Logger provides the posibility to collect the important information for developer.
        /// </summary>
        private Logger log = LogManager.GetCurrentClassLogger();
        #endregion

        #region Property
        /// <summary>
        /// Allows to work with list of books
        /// </summary>
        public List<Book> ListBooks
        {
            get { return listBooks; }
            private set { listBooks = value; }
        }
        #endregion

        #region public methods
        /// <summary>
        /// Add the book into list 
        /// </summary>
        /// <param name="book">book for adding</param>
        public void AddBook(Book book)
        {
            log.Info("Try to add book into list");
            if (ReferenceEquals(book, null))
            {
                log.Error("Argument book contains null");
                throw new ArgumentNullException(nameof(book));
            }

            foreach (var item in listBooks)
                if (book.Equals(item))
                {
                    log.Error("Book has already added");
                    throw new ArgumentException("Book has already added");
                }
            listBooks.Add(book);
        }

        /// <summary>
        /// Try to remove the book from list
        /// </summary>
        /// <param name="book">book for removing</param>
        public void RemoveBook(Book book)
        {
            log.Info("Try to remove book");
            if (ReferenceEquals(book, null))
            {
                log.Error("Argument book contains null");
                throw new ArgumentNullException(nameof(book));
            }

            foreach (var item in listBooks)
            {
                if (book.Equals(item))
                {
                    listBooks.Remove(item);
                    log.Info("The book was removed");
                    return;
                }
            }
            log.Error("The book was not found");
            throw new ArgumentException();
        }

        /// <summary>
        /// find the book usinf criterion
        /// </summary>
        /// <param name="obj">search this object in list</param>
        /// <param name="criterion">criterion which is used to define the way of finding</param>
        /// <returns></returns>
        public List<Book> FindBookByTag(object obj, IFind criterion)
        {
            log.Info("Try to find book by tag");
            List<Book> findList = new List<Book>();
            findList = listBooks.FindAll(book => criterion.Find(obj, book));

            if (findList.Count == 0)
            {
                log.Error("The book was not found");
                throw new ArgumentException();
            }
            else {
                log.Info("The book was found by tag");
                return findList;
            }
        }

        /// <summary>
        /// Sort list of books by criterion
        /// </summary>
        /// <param name="criterion">criterion which is used to define the way of sorting</param>
        public void SortBooksByTag(IComparer<Book> criterion)
        {
            listBooks.Sort(criterion);
        }
        #endregion
    }
}