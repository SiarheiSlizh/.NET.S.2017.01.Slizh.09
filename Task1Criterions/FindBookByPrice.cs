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
        private decimal price;

        public FindBookByPrice(decimal price)
        {
            this.price = price;
        }

        bool IFind.Find(Book book)
        {
            if (price == book.Price)
                return true;
            else return false;
        }
    }
}
