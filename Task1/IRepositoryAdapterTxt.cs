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
    public class IRepositoryAdapterTxt : IRepository
    {
        #region private fields
        /// <summary>
        /// Type is used to manage with list of books
        /// </summary>
        private BookListService bls;

        /// <summary>
        /// Adaptable class whic contains the functional
        /// </summary>
        private readonly AdapteeRepositoryTxt storage = new AdapteeRepositoryTxt();
        #endregion

        #region Constructor
        /// <summary>
        /// Initialize BookListService
        /// </summary>
        /// <param name="service">Type is used to manage with list of books</param>
        public IRepositoryAdapterTxt(BookListService service)
        {
            bls = service;
        }
        #endregion

        #region public methods
        /// <summary>
        /// Save information to file
        /// </summary>
        /// <param name="path">The whole path to file with name</param>
        public void Save(string path) => storage.SaveToFile(path, bls);

        /// <summary>
        /// Load information from file
        /// </summary>
        /// <param name="path">The whole path to file with name</param>
        public void Load(string path) => storage.LoadFromFile(path, bls);
        #endregion
    }
}
