using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// Adaptable class which is used for loading/uploading list of books from/to binary serializer.
    /// </summary>
    public class BinarySerializer
    {
        #region public methods
        /// <summary>
        /// Save information to binary serializer
        /// </summary>
        /// <param name="path">The whole path to serializer with name</param>
        /// <param name="listBooks">List of books</param>
        public void Serialize(string path, IEnumerable<Book> listBooks)
        {
            if (ReferenceEquals(listBooks, null))
                throw new ArgumentNullException(nameof(listBooks));

            if (listBooks.Count() == 0)
                return;

            if (!path.EndsWith(".bin"))
                throw new FormatException(nameof(path));

            BinaryFormatter formatter = new BinaryFormatter();
            try {
                using (Stream s = File.Create(path))
                {
                    formatter.Serialize(s, listBooks);
                }
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException("File is not found", ex);
            }

            catch (IOException ex)
            {
                throw new IOException("Serialize error", ex);
            }
        }

        /// <summary>
        /// Load information from binary serializer
        /// </summary>
        /// <param name="path">The whole path to serializer with name</param>
        /// <returns>List of books</returns>
        public List<Book> Deserialize(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException(nameof(path));

            if (!path.EndsWith(".bin"))
                throw new FormatException(nameof(path));

            BinaryFormatter formatter = new BinaryFormatter();
            try {
                using (Stream s = File.OpenRead(path))
                {
                    List<Book> deserializeBooks = (List<Book>)formatter.Deserialize(s);
                    return deserializeBooks;
                }
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException("File is not found", ex);
            }

            catch (IOException ex)
            {
                throw new IOException("Deserialize error", ex);
            }
        }
        #endregion
    }
}
