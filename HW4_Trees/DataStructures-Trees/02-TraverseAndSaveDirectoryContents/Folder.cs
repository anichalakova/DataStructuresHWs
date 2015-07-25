using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_TraverseAndSaveDirectoryContents
{
    class Folder
    {
        internal string name;
        internal List<File> files;
        internal List<Folder> childFolders;

        public Folder(string name)
        {
            this.name = name;
            this.files = new List<File>();
            this.childFolders = new List<Folder>();
        }
    }
}
