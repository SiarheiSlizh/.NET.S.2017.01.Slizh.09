using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class AdapteeRepositoryTxt
    {
        public void SaveToFile(string path, BookListService service)
        {
            if (service.ListBooks.Count == 0)
                return;

            using (BinaryWriter file = new BinaryWriter(
                File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite), Encoding.UTF8))
            {
                file.Seek(0, SeekOrigin.End);
                foreach (var item in service.ListBooks)
                    file.Write(item.ToString() + "\n");
            }
        }
    }
}
