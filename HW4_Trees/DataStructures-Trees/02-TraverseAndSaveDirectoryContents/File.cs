namespace _02_TraverseAndSaveDirectoryContents
{
    class File
    {
        private string name;
        private long size;

        public File(string name, long size = 0)
        {
            this.Name = name;
            this.Size = size;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public long Size {
            get { return this.size; }
            set { this.size = value; }
        }
    }
}
