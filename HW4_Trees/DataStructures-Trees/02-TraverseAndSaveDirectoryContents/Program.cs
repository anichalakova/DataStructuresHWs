using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DataStructures_Trees;

namespace _02_TraverseAndSaveDirectoryContents
{
    class Program
    {
        static void Main()
        {
            var rootDirectory = Directory.CreateDirectory("D:\\Install");
            var folderTree = new Folder(rootDirectory.Name);
            Console.WriteLine(string.Format("Folder size is: {0}", TraverseDirectory(rootDirectory, folderTree)));
            ;
        }

        private static long TraverseDirectory(DirectoryInfo rootDirectory, Folder currentFolder)
        {
            try
            {
                var files = rootDirectory.GetFiles();
                var childDirectories = rootDirectory.GetDirectories();
                long size = 0;

                foreach (var file in files)
                {
                    currentFolder.files.Add(new File(file.Name, file.Length));
                    size += file.Length;
                }

                foreach (var directory in childDirectories)
                {
                    currentFolder.childFolders.Add(new Folder(directory.Name));
                    TraverseDirectory(directory, currentFolder);
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
