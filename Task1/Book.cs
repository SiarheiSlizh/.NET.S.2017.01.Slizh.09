using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Book:IComparable, IFormattable
    {
        public string Name { get; set; }
        public string Auther { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Publisher { get; set; }

        public override string ToString() => ToString("G", CultureInfo.CurrentCulture);

        public string ToString(string format) => this.ToString(format, CultureInfo.CurrentCulture);

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

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;

            if (this.GetType() != obj.GetType())
                return false;

            return Equals((Book)obj);
        }

        public bool Equals (Book other)
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

        public override int GetHashCode()
        {
            int hash = Name.GetHashCode();
            hash += Auther.GetHashCode();
            hash += Year.GetHashCode();
            hash += Price.GetHashCode();
            hash += Publisher.GetHashCode();
            return hash;
        }

        int IComparable.CompareTo(object obj)
        {
            if (ReferenceEquals(obj, null))
                throw new ArgumentNullException(nameof(obj));

            return this.CommpareTo((Book)obj); 
        }

        public int CommpareTo(Book book)
        {
            if (this.Equals(book))
                return 0;

            if (string.Compare(this.Name, book.Name) >= 0)
                return 1;
            else return -1;
        }

        public static bool operator == (Book bookFirst, Book bookSec) => bookFirst.Equals(bookSec);
        public static bool operator != (Book bookFirst, Book bookSec) => !bookFirst.Equals(bookSec);
    }
}