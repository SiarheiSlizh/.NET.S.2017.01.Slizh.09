﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace Task1Criterions
{
    public class SortByNameOfBook : IComparer<Book>
    {
        int IComparer<Book>.Compare(Book firstBook, Book secondBook)
        {
            if (string.Compare(firstBook.Name, secondBook.Name) >= 0)
                return 1;
            else return -1;
        }
    }
}
