using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;
using Task1Criterions;

namespace Task1CUI
{
    class Program
    {
        static void Main(string[] args)
        {
            BookListService bls = new BookListService();
            
            for (int i=0; i<3; i++)
            {
                Book book = new Book();
                book.Name = Console.ReadLine();
                book.Auther = Console.ReadLine();
                book.Price = decimal.Parse(Console.ReadLine());
                book.Year = int.Parse(Console.ReadLine());
                book.Publisher = Console.ReadLine();
                bls.ListBooks.Add(book);
            }
            bls.SortBooksByTag(new SortByNameOfBook());
            foreach (var item in bls.ListBooks)
            {
                Console.WriteLine(item.ToString());
            }

            List<Book> f = bls.FindBookByTag(12m, new FindBookByPrice());
            foreach (var item in f)
            {
                Console.WriteLine(item.ToString());
            }

            IRepository repos = new IRepositoryAdapterTxt(bls);
            repos.Save(Environment.CurrentDirectory + "BookListStorage.txt");
        }
    }
}
