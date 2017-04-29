using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// Contains information about books.
    /// </summary>
    [Serializable]
    public class Book:IComparable, IComparable<Book>, IEquatable<Book>, IFormattable
    {
        #region Properties
        /// <summary>
        /// Name of book.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Author of book.
        /// </summary>
        public string Auther { get; }

        /// <summary>
        /// The year of publishing of book.
        /// </summary>
        public int Year { get; }

        /// <summary>
        /// The price of book.
        /// </summary>
        public decimal Price { get; private set; }

        /// <summary>
        /// The publisher of book.
        /// </summary>
        public string Publisher { get; }
        #endregion

        #region Constructor
        /// <summary>
        /// Create book with main information.
        /// </summary>
        /// <param name="name">The name of book.</param>
        /// <param name="auther">The auther of book</param>
        /// <param name="year">The year of publishing of book.</param>
        /// <param name="price">The price of book</param>
        /// <param name="publisher">The publisher of book</param>
        public Book (string name, string auther, int year, decimal price, string publisher)
        {
            Name = name;
            Auther = auther;
            Year = year;
            Price = price;
            Publisher = publisher;
        }
        #endregion

        #region object's override and formattable
        /// <summary>
        /// String represent of book.
        /// </summary>
        /// <returns>String represent of book.</returns>
        public override string ToString() => ToString("G", CultureInfo.CurrentCulture);

        /// <summary>
        /// String represent of book.
        /// </summary>
        /// <param name="format">format</param>
        /// <returns>String represent of book.</returns>
        public string ToString(string format) => this.ToString(format, CultureInfo.CurrentCulture);

        /// <summary>
        /// String represent of book.
        /// </summary>
        /// <param name="format">format</param>
        /// <param name="formatProvider">culture info</param>
        /// <returns>String represent of book.</returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (String.IsNullOrEmpty(format))
                format = "G";

            if (ReferenceEquals(formatProvider, null))
                formatProvider = CultureInfo.CurrentCulture;

            switch (format.ToUpperInvariant())
            {
                case "G":
                    return string.Format($"{Name}, {Auther}, {Year}y, {Price}$");
                case "NA":
                    return string.Format($"{Name}, {Auther}");
                case "NP":
                    return string.Format($"{Name}, {Price}$");
                default:
                    throw new ArgumentException(string.Format($"{format} doesn't exist for string."), format);
            }
        }

        /// <summary>
        /// Compare informations between two books.
        /// </summary>
        /// <param name="obj">other book</param>
        /// <returns>true in case of equality else false</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;

            if (this.GetType() != obj.GetType())
                return false;

            return Equals((Book)obj);
        }

        /// <summary>
        /// Compare informations between two books.
        /// </summary>
        /// <param name="other">other book</param>
        /// <returns>true in case of equality else false</returns>
        bool IEquatable<Book>.Equals (Book other)
        {
            if (ReferenceEquals(other, null))
                return false;

            if (this.GetHashCode() != other.GetHashCode())
                return false;

            if (string.Compare(this.Name, other.Name) != 0 ||
                string.Compare(this.Auther, other.Auther) != 0 ||
                string.Compare(this.Publisher, other.Publisher) != 0 ||
                this.Price != other.Price ||
                this.Year != other.Year
                )
                return false;
            else
                return true;
        }

        /// <summary>
        /// find hash of book
        /// </summary>
        /// <returns>hash type of int</returns>
        public override int GetHashCode()
        {
            int hash = Name.GetHashCode();
            hash += Auther.GetHashCode();
            hash += Year.GetHashCode();
            hash += Publisher.GetHashCode();
            return hash;
        }
        #endregion

        #region Comparable
        /// <summary>
        /// Compare books in order by name ascending.
        /// </summary>
        /// <param name="obj">other book</param>
        /// <returns></returns>
        int IComparable.CompareTo(object obj)
        {
            if (ReferenceEquals(obj, null) || !(obj is IComparable<Book>))
                throw new ArgumentNullException(nameof(obj));

            return ((IComparable<Book>)this).CompareTo((Book)obj);
        }

        /// <summary>
        /// Compare books in order by name ascending.
        /// </summary>
        /// <param name="book">other book</param>
        /// <returns></returns>
        int IComparable<Book>.CompareTo(Book other)
        {
            if (this.Equals(other))
                return 0;

            if (string.Compare(this.Name, other.Name) >= 0)
                return 1;
            else return -1;
        }
        #endregion

        #region Overload method
        /// <summary>
        /// Compare two books
        /// </summary>
        /// <param name="bookFirst">first</param>
        /// <param name="bookSec">second</param>
        /// <returns>true in case equality of books</returns>
        public static bool operator == (Book bookFirst, Book bookSec) => bookFirst.Equals(bookSec);

        /// <summary>
        /// Compare two books
        /// </summary>
        /// <param name="bookFirst">first</param>
        /// <param name="bookSec">second</param>
        /// <returns>false in case equality of books</returns>
        public static bool operator != (Book bookFirst, Book bookSec) => !bookFirst.Equals(bookSec);
        #endregion
    }
}