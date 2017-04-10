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

            bls.ListBooks.Add(new Book("Pygmi", "Palanik", 1996, 200, "Doubleday"));
            bls.ListBooks.Add(new Book("It", "King", 1990, 400, "Viking Press"));
            bls.ListBooks.Add(new Book("1984", "Orwell", 1999, 200, "Harvill Secker"));
            bls.ListBooks.Add(new Book("Green Mile", "King", 1999, 500, "Viking Press"));

            Console.WriteLine("*****SAVE*****");
            IRepository repos = new IRepositoryAdapterTxt(bls);
            repos.Save(Environment.CurrentDirectory + "BookListStorage.txt");

            Console.WriteLine("*****SORT BY NAME*****");
            bls.SortBooksByTag(new SortByNameOfBook());
            foreach (var item in bls.ListBooks)
                Console.WriteLine(item.ToString());

            Console.WriteLine("*****FIND BY PRICE*****");
            List<Book> f = bls.FindBookByTag(200m, new FindBookByPrice());
            foreach (var item in f)
                Console.WriteLine(item.ToString());

            Console.WriteLine("*****OPEN*****");
            BookListService bls1 = new BookListService();
            repos = new IRepositoryAdapterTxt(bls1);
            repos.Load(Environment.CurrentDirectory + "BookListStorage.txt");

            foreach (var item in bls1.ListBooks)
                Console.WriteLine(item.ToString());
        }
    }
}