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
        private string name;

        public FindBookByName(string name)
        {
            this.name = name;
        }

        bool IFind.Find(Book book)
        {
            if (name == book.Name)
                return true;
            else return false;
        }
    }
}
