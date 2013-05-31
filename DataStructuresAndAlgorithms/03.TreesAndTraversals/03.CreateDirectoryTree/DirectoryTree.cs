using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _03.CreateDirectoryTree
{
    public class DirectoryTree
    {
        string rootPath;
        Folder rootFolder;

        public DirectoryTree(string rootPath)
        {
            this.RootPath = rootPath;
            var root = Directory.GetParent(rootPath);
            
            rootFolder = new Folder(rootPath);
        }

        public string RootPath
        {
            get
            {
                return this.rootPath;
            }
            private set
            {
                if (value == null || value == "")
                {
                    throw new ArgumentException("Root path cannot be null or empty");
                }
                this.rootPath = value;
            }
        }

        public Folder RootFolder
        {
            get
            {
                return this.rootFolder;
            }
        }

        public double CalculateSizeOfTree()
        {
            long sizeInBytes = rootFolder.GetFilesSize();
            double sizeInMB = sizeInBytes / 1048576;
            return sizeInMB;
        }

        public double CalculateSizeOfFolder(string folderName)
        {
            Folder foundFolder = rootFolder.FindFolder(folderName);

            long sizeInBytes = GetFilesSize(foundFolder);
            double sizeInMB = sizeInBytes / 1048576;

            return sizeInMB;
        }

        public Folder FindFolder(string folderName)
        {
            return rootFolder.FindFolder(folderName);
        }

        private long GetFilesSize(Folder folder)
        {
            long size = 0;

            foreach (var file in folder.Files)
            {
                size += file.SizeInBytes;
            }

            foreach (var subFolder in folder.Folders)
            {
                size += subFolder.GetFilesSize();
            }

            return size;
        }
    }
}
