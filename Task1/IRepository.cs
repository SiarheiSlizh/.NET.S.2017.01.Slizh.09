using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// interface provides the possibility to load and save information from and to file
    /// </summary>
    public interface IRepository
    {

        /// <summary>
        /// Save information to file
        /// </summary>
        /// <param name="path">The whole path to file with name</param>
        /// <param name="listBooks">List of books</param>
        void Write(string path, List<Book> listBooks);

        /// <summary>
        /// Load information from file
        /// </summary>
        /// <param name="path">The whole path to file with name</param>
        /// <returns>List of books</returns>
        IEnumerable<Book> Read(string path);
    }
}
