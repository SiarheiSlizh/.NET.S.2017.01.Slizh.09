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
        private List<Book> listBooks;

        /// <summary>
        /// Logger provides the posibility to collect the important information for developer.
        /// </summary>
        private ILogger log;

        #endregion


        #region Construtor
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="log"></param>
        public BookListService(List<Book> list, ILogger log)
        {
            if (ReferenceEquals(list, null))
                listBooks = new List<Book>();
            else
                listBooks = list;

            if (ReferenceEquals(log, null))
                throw new ArgumentNullException(nameof(log));

            this.log = log;
            log.Info("Log file is created");
        }

        #endregion


        #region public methods

        /// <summary>
        /// Add the book into list 
        /// </summary>
        /// <param name="book">book for adding</param>
        public void AddBook(Book book)
        {
            log.Debug("Try to add book into list");
            if (ReferenceEquals(book, null))
            {
                log.Trace("Argument book contains null");
                throw new ArgumentNullException(nameof(book));
            }

            foreach (var item in listBooks)
                if (book.Equals(item))
                {
                    log.Trace("Book has already added");
                    throw new ArgumentException("Book has already added");
                }
            listBooks.Add(book);
            log.Debug("The book is added");
        }

        /// <summary>
        /// Try to remove the book from list
        /// </summary>
        /// <param name="book">book for removing</param>
        public void RemoveBook(Book book)
        {
            log.Debug("Try to remove book");
            if (ReferenceEquals(book, null))
            {
                log.Trace("Argument book contains null");
                throw new ArgumentNullException(nameof(book));
            }

            foreach (var item in listBooks)
            {
                if (book.Equals(item))
                {
                    listBooks.Remove(item);
                    log.Debug("The book was removed");
                    return;
                }
            }
            log.Trace("The book was not found");
            throw new ArgumentException();
        }

        /// <summary>
        /// find the book usinf criterion
        /// </summary>
        /// <param name="obj">search this object in list</param>
        /// <param name="criterion">criterion which is used to define the way of finding</param>
        /// <returns></returns>
        public List<Book> FindBookByTag(IFind criterion)
        {
            log.Debug("Try to find book by tag");
            List<Book> findList = new List<Book>();
            findList = listBooks.FindAll(book => criterion.Find(book));

            if (findList.Count == 0)
            {
                log.Trace("The book was not found");
                throw new ArgumentException();
            }
            else {
                log.Debug("The book was found by tag");
                return findList;
            }
        }

        /// <summary>
        /// Sort list of books by criterion
        /// </summary>
        /// <param name="criterion">criterion which is used to define the way of sorting</param>
        public void SortBooksByTag(IComparer<Book> criterion)
        {
            log.Debug("Try to sort list");
            if (ReferenceEquals(criterion, null))
            {
                log.Trace("error with Comparer");
                throw new ArgumentNullException();
            }

            listBooks.Sort(criterion);
            log.Debug($"list is {criterion}");
        }

        /// <summary>
        /// upload books into storage
        /// </summary>
        /// <param name="storage">type of storage</param>
        /// <param name="path">path to repository</param>
        public void Upload(IRepository storage, string path)
        {
            log.Debug("Try to upload books");
            if (ReferenceEquals(storage, null))
            {
                log.Trace("storage is not found");
                throw new ArgumentNullException(nameof(storage));
            }

            if (string.IsNullOrEmpty(path))
            {
                log.Trace("storage is not found");
                throw new ArgumentNullException(nameof(path));
            }

            storage.Write(path, listBooks);
            log.Debug($"Books are uploaded into storage {path}");
        }

        /// <summary>
        /// download books from storage
        /// </summary>
        /// <param name="storage">type of storage</param>
        /// <param name="path">path to repository</param>
        /// <returns>list of books</returns>
        public List<Book> Download(IRepository storage, string path)
        {
            log.Debug("Try to download books");
            if (ReferenceEquals(storage, null))
            {
                log.Trace("storage is not found");
                throw new ArgumentNullException(nameof(storage));
            }

            if (string.IsNullOrEmpty(path))
            {
                log.Trace("storage is not found");
                throw new ArgumentNullException(nameof(path));
            }

            listBooks = storage.Read(path);
            log.Debug($"Books are downloaded from storage {path}");
            return listBooks;
        }

        #endregion
    }
}