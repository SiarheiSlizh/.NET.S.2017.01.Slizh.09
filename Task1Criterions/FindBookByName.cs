using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace Task1Criterions
{
    public class FindBookByName : IFind
    {
        bool IFind.Find(object obj, Book book)
        {
            string str = (string)obj;
            if (str == book.Name)
                return true;
            else return false;
        }
    }
}
