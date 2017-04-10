using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// interface provides the possibility to load and save information from and to file
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Save information to file
        /// </summary>
        /// <param name="path">The whole path to file with name</param>
        void Save(string path);

        /// <summary>
        /// Load information from file
        /// </summary>
        /// <param name="path">The whole path to file with name</param>
        void Load(string path);
    }
}
