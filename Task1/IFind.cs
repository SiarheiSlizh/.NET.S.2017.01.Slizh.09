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
        /// <param name="obj">one of arguments</param>
        /// <param name="book">book</param>
        /// <returns></returns>
        bool Find(object obj, Book book);
    }
}
