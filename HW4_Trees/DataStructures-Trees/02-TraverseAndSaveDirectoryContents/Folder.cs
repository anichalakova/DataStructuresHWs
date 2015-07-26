using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_TraverseAndSaveDirectoryContents
{
    class Folder
    {
        private string name;
        private List<File> files;
        private List<Folder> childFolders;

        public Folder(string name)
        {
            this.Name = name;
            this.Files = new List<File>();
            this.ChildFolders = new List<Folder>();
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public List<File> Files
        {
            get { return this.files; }
            set { this.files = value; }
        }

        public List<Folder> ChildFolders
        {
            get { return this.childFolders; }
            set { this.childFolders = value; }
        }
    }
}
