using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _03.CreateDirectoryTree
{
    public class Folder
    {
        string name;
        List<File> files;
        List<Folder> folders;

        public Folder(string path)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            this.Name = dirInfo.Name;

            CreateRecursivelyFilesAndFolders(dirInfo);
        }

        
        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (value == null || value == "")
                {
                    throw new ArgumentException("Folder name cannot be null or empty");
                }
                this.name = value;
            }
        }

        public List<File> Files
        {
            get
            {
                return this.files;
            }
            private set
            {
                this.files = value;
            }
        }

        public List<Folder> Folders
        {
            get
            {
                return this.folders;
            }
            private set
            {
                this.folders = value;
            }
        }

        public long GetFilesSize()
        {
            long size = 0;

            foreach (var file in files)
            {
                size += file.SizeInBytes;
            }

            foreach (var folder in folders)
            {
                size += folder.GetFilesSize();
            }

            return size;
        }

        

        public Folder FindFolder(string name)
        {

            foreach (var folder in folders)
            {
                if (folder.name == name)
                {
                    return folder;
                }
            }

            foreach (var folder in folders)
            {
                Folder foundFolder = FindFolder(name);
                if (foundFolder != null)
                {
                    return foundFolder;
                }
            }

            throw new ArgumentException("No such folder");
        }

        private void CreateRecursivelyFilesAndFolders(DirectoryInfo dirInfo)
        {
            FileInfo[] files;
            try
            {
                files = dirInfo.GetFiles();
            }
            catch (UnauthorizedAccessException)
            {
                this.files = new List<File>();
                this.folders = new List<Folder>();
                return;
            }

            this.files = new List<File>();
            foreach (var file in files)
            {
                this.files.Add(new File(file.Name, file.Length));
            }

            DirectoryInfo[] dirs = dirInfo.GetDirectories();
            folders = new List<Folder>();
            foreach (var dir in dirs)
            {
                this.folders.Add(new Folder(dir.FullName));
            }
        }

    }
}
