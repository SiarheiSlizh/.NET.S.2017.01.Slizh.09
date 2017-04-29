using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Task1
{
    /// <summary>
    /// Adaptable class which is used for loading/uploading list of books from/to XML file.
    /// </summary>
    public class XMLRepository
    {
        #region public methods
        /// <summary>
        /// Save information to XML file
        /// </summary>
        /// <param name="path">The whole path to XML file with name</param>
        /// <param name="listBooks">List of books</param>
        public void SaveToXml (string path, IEnumerable<Book> listBooks)
        {
            if (ReferenceEquals(listBooks, null))
                throw new ArgumentNullException(nameof(listBooks));

            if (listBooks.Count() == 0)
                return;

            if (!path.EndsWith(".xml"))
                throw new FormatException(nameof(path));

            XmlTextWriter docXmlW = new XmlTextWriter(path, Encoding.UTF8);
            docXmlW.WriteStartDocument();
            docXmlW.WriteStartElement("Books");
            docXmlW.WriteEndElement();
            docXmlW.Close();
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            foreach (var book in listBooks)
            {
                XmlElement element = doc.CreateElement("Book");
                doc.DocumentElement.AppendChild(element);
                XmlElement name = doc.CreateElement("Name");
                XmlElement auther = doc.CreateElement("Auther");
                XmlElement year = doc.CreateElement("Year");
                XmlElement price = doc.CreateElement("Price");
                XmlElement publisher = doc.CreateElement("Publisher");

                name.InnerText = book.Name;
                auther.InnerText = book.Auther;
                year.InnerText = book.Year.ToString();
                price.InnerText = book.Price.ToString();
                publisher.InnerText = book.Publisher;

                element.AppendChild(name);
                element.AppendChild(auther);
                element.AppendChild(year);
                element.AppendChild(price);
                element.AppendChild(publisher);
            }

            doc.Save(path);
        }

        /// <summary>
        /// Load information from XML file
        /// </summary>
        /// <param name="path">The whole path to XML file with name</param>
        /// <returns>List of books</returns>
        public List<Book> LoadFromXml(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException(nameof(path));

            if (!path.EndsWith(".xml"))
                throw new FormatException(nameof(path));

            List<Book> books = new List<Book>();
            XmlDocument doc = null;

            try {
                doc = new XmlDocument();
                doc.Load(path);
            }
            catch (XmlException ex)
            {
                throw new XmlException(ex.Message);
            }

            XmlNodeList nodes = doc.DocumentElement.ChildNodes;
            foreach (XmlElement book in nodes)
            {
                books.Add(new Book(
                    book.ChildNodes[0].InnerText,
                    book.ChildNodes[1].InnerText,
                    int.Parse(book.ChildNodes[2].InnerText),
                    decimal.Parse(book.ChildNodes[3].InnerText),
                    book.ChildNodes[4].InnerText ));
            }

            return books;
        }
        #endregion
    }
}
