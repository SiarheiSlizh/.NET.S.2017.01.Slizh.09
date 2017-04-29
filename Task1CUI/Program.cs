using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Task1;
using Task1Criterions;
using NLog;
using System.Xml.Linq;

namespace Task1CUI
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Book> listBooks = new List<Book>();
            listBooks.Add(new Book("Pygmi", "Palanik", 1996, 200, "Doubleday"));
            listBooks.Add(new Book("It", "King", 1990, 400, "Viking Press"));
            listBooks.Add(new Book("1984", "Orwell", 1999, 200, "Harvill Secker"));
            listBooks.Add(new Book("Green Mile", "King", 1999, 500, "Viking Press"));

            Task1.ILogger logger = new NlogAdapter(LogManager.GetCurrentClassLogger());
            BookListService bls = new BookListService(listBooks, logger);

            Console.WriteLine("*****SAVE TO BINARY FILE*****");
            IRepository repos = new AdapterTxt();
            bls.Upload(repos, Environment.CurrentDirectory + "BookListStorage.txt");

            Console.WriteLine("*****SORT BY NAME*****");
            bls.SortBooksByTag(new SortByNameOfBook());
            foreach (var item in listBooks)
                Console.WriteLine(item.ToString());

            Console.WriteLine("*****FIND BY PRICE*****");
            List<Book> f = bls.FindBookByTag(new FindBookByPrice(200));
            foreach (var item in f)
                Console.WriteLine(item.ToString());

            Console.WriteLine("*****OPEN FROM BINARY FILE*****");
            List<Book> listBooksDL = bls.Download(repos, Environment.CurrentDirectory + "BookListStorage.txt");

            foreach (var item in listBooksDL)
                Console.WriteLine(item.ToString());

            Console.WriteLine("*****SAVE TO XML FILE*****");
            repos = new AdapterXML();
            bls.Upload(repos, Environment.CurrentDirectory + "BookListStorage.xml");

            Console.WriteLine("*****OPEN FROM XML FILE*****");
            List<Book> listBooksXml = bls.Download(repos, Environment.CurrentDirectory + "BookListStorage.xml");

            foreach (var item in listBooksXml)
                Console.WriteLine(item.ToString());

            Console.WriteLine("*****SERIALIZE BOOKS TO FILE*****");
            repos = new AdapterSerializer();
            bls.Upload(repos, Environment.CurrentDirectory + "BookListStorage.bin");

            Console.WriteLine("*****OPEN DESERIALIZE BOOKS FROM FILE*****");
            List<Book> listBooksDS = bls.Download(repos, Environment.CurrentDirectory + "BookListStorage.bin");

            foreach (var item in listBooksDS)
                Console.WriteLine(item.ToString());
        }       
    }
}