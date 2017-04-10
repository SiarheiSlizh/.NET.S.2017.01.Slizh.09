using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class IRepositoryAdapterTxt : IRepository
    {
        private BookListService bls;
        private readonly AdapteeRepositoryTxt storage = new AdapteeRepositoryTxt();

        public IRepositoryAdapterTxt(BookListService service)
        {
            bls = service;
        }

        public void Save(string path)
        {
            storage.SaveToFile(path, bls);
        }
    }
}
