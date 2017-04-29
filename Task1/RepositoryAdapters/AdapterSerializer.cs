using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// Adapter for class BinarySerializer
    /// </summary>
    public class AdapterSerializer : IRepository
    {
        #region private fields
        /// <summary>
        /// Adaptable class which contains the functional
        /// </summary>
        private readonly BinarySerializer storage = new BinarySerializer();
        #endregion

        #region public methods
        /// <summary>
        /// Load information from binary serializer
        /// </summary>
        /// <param name="path">The whole path to serializer with name</param>
        /// <returns>List of books</returns>
        List<Book> IRepository.Read(string path) => storage.Deserialize(path);

        /// <summary>
        /// Save information to binary serializer
        /// </summary>
        /// <param name="path">The whole path to serializer with name</param>
        /// <param name="listBooks">List of books</param>
        void IRepository.Write(string path, IEnumerable<Book> listBooks) => storage.Serialize(path, listBooks);
        #endregion
    }
}
