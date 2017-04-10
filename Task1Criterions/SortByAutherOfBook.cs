using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace Task1Criterions
{
    public class SortByAutherOfBook : IComparer<Book>
    {
        int IComparer<Book>.Compare(Book firstBook, Book secondBook)
        {
            if (string.Compare(firstBook.Auther, secondBook.Auther) >= 0)
                return 1;
            else return -1;
        }
    }
}
