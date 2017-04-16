using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// Interface is used to set criterion for searching
    /// </summary>
    public interface IFind
    {
        /// <summary>
        /// Method defines the criterion
        /// </summary>
        /// <param name="book">book</param>
        /// <returns>true in case finding the book else false</returns>
        bool Find(Book book);
    }
}
