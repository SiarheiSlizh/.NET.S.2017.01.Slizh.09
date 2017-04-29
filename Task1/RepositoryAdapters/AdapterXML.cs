using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// Adapter for class XMLRepository
    /// </summary>
    public class AdapterXML : IRepository
    {
        #region private fields
        /// <summary>
        /// Adaptable class whic contains the functional
        /// </summary>
        private readonly XMLRepository storage = new XMLRepository();
        #endregion


        #region public methods
        /// <summary>
        /// Load information from XML file
        /// </summary>
        /// <param name="path">The whole path to XML file with name</param>
        /// <returns>List of books</returns>
        List<Book> IRepository.Read(string path) => storage.LoadFromXml(path);

        /// <summary>
        /// Save information to XML file
        /// </summary>
        /// <param name="path">The whole path to XML file with name</param>
        /// <param name="listBooks">List of books</param>
        void IRepository.Write(string path, IEnumerable<Book> listBooks) => storage.SaveToXml(path, listBooks);
        #endregion
    }
}
