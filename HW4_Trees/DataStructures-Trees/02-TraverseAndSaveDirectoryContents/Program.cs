using System;
using System.IO;

namespace _02_TraverseAndSaveDirectoryContents
{
    class Program
    {
        static void Main()
        {
            // Choose a valid directory on your computer that you have authorized access to:
            var rootDirectory = new DirectoryInfo("D:\\Install");
            var rootFolder = new Folder(rootDirectory.FullName);
            TraverseDirectory(rootFolder);
            Console.WriteLine(string.Format(
                "Folder {0} has size: {1} bytes", 
                rootFolder.Name, 
                CalculateSize(rootFolder)));
        }

        private static Folder TraverseDirectory(Folder currentFolder)
        {
            try
            {
                var currentDirectory = new DirectoryInfo(currentFolder.Name);
                var files = currentDirectory.GetFiles();
                var childDirectories = currentDirectory.GetDirectories();

                foreach (var file in files)
                {
                    currentFolder.Files.Add(new File(file.FullName, file.Length));
                }

                foreach (var directory in childDirectories)
                {
                    currentFolder.ChildFolders.Add(new Folder(directory.FullName));
                }

                foreach (var childFolder in currentFolder.ChildFolders)
                {
                    TraverseDirectory(childFolder);
                }
                return currentFolder;
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("You don't have permition to access these files/directories");
                throw;
            }
        }

        private static long CalculateSize(Folder currentFolder)
        {
            long size = 0;

            foreach (var file in currentFolder.Files)
            {
                size += file.Size;
            }

            foreach (var childFolder in currentFolder.ChildFolders)
            {
                size += CalculateSize(childFolder);
            }
            return size;
        }
    }
}
