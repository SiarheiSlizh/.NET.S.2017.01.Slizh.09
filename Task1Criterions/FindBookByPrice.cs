using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace Task1Criterions
{
    public class FindBookByPrice : IFind
    {
        bool IFind.Find(object obj, Book book)
        {
            decimal price = (decimal)obj;
            if (price == book.Price)
                return true;
            else return false;
        }
    }
}
