using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// Adaptable class.
    /// </summary>
    public class AdapteeRepositoryTxt
    {
        #region public methods
        /// <summary>
        /// Save books to binary file.
        /// </summary>
        /// <param name="path">The whole path to file with name.</param>
        /// <param name="service">Container for books.</param>
        public void SaveToFile(string path, BookListService service)
        {
            if (ReferenceEquals(service, null))
                throw new ArgumentNullException(nameof(service));

            if (service.ListBooks.Count == 0)
                return;

            try {
                using (BinaryWriter file = new BinaryWriter(
                    File.Open(path, FileMode.OpenOrCreate, FileAccess.Write), Encoding.UTF8))
                {
                    foreach (var item in service.ListBooks)
                    {
                        file.Write(item.Name);
                        file.Write(item.Auther);
                        file.Write(item.Year);
                        file.Write(item.Price);
                        file.Write(item.Publisher);
                    }
                }
            }

            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException("File is not found", ex);
            }

            catch (IOException ex)
            {
                throw new IOException("File error", ex);
            }
        }

        /// <summary>
        /// Load books from binary file.
        /// </summary>
        /// <param name="path">The whole path to file with name.</param>
        /// <param name="service">Container for books.</param>
        public void LoadFromFile(string path, BookListService service)
        {
            if (ReferenceEquals(service, null))
                throw new ArgumentNullException(nameof(service));

            try
            {
                using (BinaryReader file = new BinaryReader(
                    File.Open(path, FileMode.Open, FileAccess.Read), Encoding.UTF8))
                {
                    while (file.PeekChar() > -1)
                    {
                        string name = file.ReadString();
                        string auther = file.ReadString();
                        int year = file.ReadInt32();
                        decimal price = file.ReadDecimal();
                        string publisher = file.ReadString();
                        service.AddBook(new Book(name, auther, year, price, publisher));
                    }
                }
            }

            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException("File is not found", ex);
            }

            catch (IOException ex)
            {
                throw new IOException("File error", ex);
            }
        }
        #endregion
    }
}