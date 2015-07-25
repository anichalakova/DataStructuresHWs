using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_TraverseAndSaveDirectoryContents
{
    class File
    {
        private string name;
        private long size;

        public File(string name, long size = 0)
        {
            this.name = name;
            this.size = size;
        }
    }
}
