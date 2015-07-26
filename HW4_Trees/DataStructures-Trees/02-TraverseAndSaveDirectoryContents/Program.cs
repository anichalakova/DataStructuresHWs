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
            
            Console.WriteLine(string.Format("Folder {0} has size: {1} bytes", rootFolder.name, TraverseDirectory(rootFolder)));
            ;
        }

        private static long TraverseDirectory(Folder currentFolder)
        {
            try
            {
                var currentDirectory = new DirectoryInfo(currentFolder.name);
                var files = currentDirectory.GetFiles();
                var childDirectories = currentDirectory.GetDirectories();
                long size = 0;

                foreach (var file in files)
                {
                    currentFolder.files.Add(new File(file.FullName, file.Length));
                    size += file.Length;
                }

                foreach (var directory in childDirectories)
                {
                    currentFolder.childFolders.Add(new Folder(directory.FullName));
                }

                foreach (var childFolder in currentFolder.childFolders)
                {
                    size += TraverseDirectory(childFolder);
                }
                return size;
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("You don't have permition to access this files/directories");
                throw;
            }
            
        }
    }
}
