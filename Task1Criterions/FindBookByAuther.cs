using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace Task1Criterions
{
    public class FindBookByAuther:IFind
    {
        private string auther;

        public FindBookByAuther(string auther)
        {
            this.auther = auther;
        }

        bool IFind.Find(Book book)
        {
            if (auther == book.Auther)
                return true;
            else return false;
        }
    }
}
