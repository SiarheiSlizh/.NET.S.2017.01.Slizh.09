using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Task1
{
    /// <summary>
    /// Adapter for class AdapteeRepositoryTxt
    /// </summary>
    public class RepositoryAdapterTxt : IRepository
    {
        #region private fields

        /// <summary>
        /// Adaptable class whic contains the functional
        /// </summary>
        private readonly AdapteeRepositoryTxt storage = new AdapteeRepositoryTxt();

        #endregion


        #region public methods

        /// <summary>
        /// Save information to file
        /// </summary>
        /// <param name="path">The whole path to file with name</param>
        /// <param name="listBooks">List of books</param>
        void IRepository.Write(string path, List<Book> listBooks) => storage.SaveToFile(path, listBooks);

        /// <summary>
        /// Load information from file
        /// </summary>
        /// <param name="path">The whole path to file with name</param>
        /// <returns>List of books</returns>
        IEnumerable<Book> IRepository.Read(string path) => storage.LoadFromFile(path);
      
        #endregion
    }
}
