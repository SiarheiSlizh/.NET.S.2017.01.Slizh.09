using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Task1
{
    /// <summary>
    /// Adapter for class TxtRepository
    /// </summary>
    public class AdapterTxt : IRepository
    {
        #region private fields
        /// <summary>
        /// Adaptable class which contains the functional
        /// </summary>
        private readonly TxtRepository storage = new TxtRepository();
        #endregion


        #region public methods
        /// <summary>
        /// Save information to file
        /// </summary>
        /// <param name="path">The whole path to file with name</param>
        /// <param name="listBooks">List of books</param>
        void IRepository.Write(string path, IEnumerable<Book> listBooks) => storage.SaveToFile(path, listBooks);

        /// <summary>
        /// Load information from file
        /// </summary>
        /// <param name="path">The whole path to file with name</param>
        /// <returns>List of books</returns>
        List<Book> IRepository.Read(string path) => storage.LoadFromFile(path);
        #endregion
    }
}
