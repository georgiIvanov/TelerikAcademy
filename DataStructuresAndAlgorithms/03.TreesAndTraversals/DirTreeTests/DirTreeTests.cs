using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _03.CreateDirectoryTree;
using System.IO;
using System.Collections.Generic;

namespace DirTreeTests
{
    [TestClass]
    public class DirTreeTests
    {
        [TestMethod]
        public void CreateTree()
        {
            DirectoryInfo dir = Directory.GetParent("..\\..\\TestDirectory");
            DirectoryTree dirTree = new DirectoryTree(dir.FullName + "\\TestDirectory");
            Assert.IsNotNull(dirTree);
        }

        [TestMethod]
        public void CorrectRootFolder()
        {
            DirectoryInfo dir = Directory.GetParent("..\\..\\TestDirectory");
            DirectoryTree dirTree = new DirectoryTree(dir.FullName + "\\TestDirectory");
            Folder folder = dirTree.RootFolder;
            Assert.AreEqual("TestDirectory", folder.Name);
        }

        [TestMethod]
        public void RootFilesFound()
        {
            DirectoryInfo dir = Directory.GetParent("..\\..\\TestDirectory");
            DirectoryTree dirTree = new DirectoryTree(dir.FullName + "\\TestDirectory");
            Folder folder = dirTree.RootFolder;
            Assert.AreEqual(3, folder.Files.Count);
        }

        [TestMethod]
        public void RootFoldersFound()
        {
            DirectoryInfo dir = Directory.GetParent("..\\..\\TestDirectory");
            DirectoryTree dirTree = new DirectoryTree(dir.FullName + "\\TestDirectory");
            Folder folder = dirTree.RootFolder;

            List<Folder> folders = folder.Folders;
            Assert.AreEqual(4, folders.Count);

            for (int i = 0; i < folders.Count; i++)
            {
                Assert.AreEqual((i + 1).ToString(), folders[i].Name);
            }
        }

        [TestMethod]
        public void RootSize()
        {
            DirectoryInfo dir = Directory.GetParent("..\\..\\TestDirectory");
            DirectoryTree dirTree = new DirectoryTree(dir.FullName + "\\TestDirectory");
            double size = dirTree.CalculateSizeOfTree();
            Assert.AreEqual(5, (int)size);
        }

        [TestMethod]
        public void FolderSize()
        {
            DirectoryInfo dir = Directory.GetParent("..\\..\\TestDirectory");
            DirectoryTree dirTree = new DirectoryTree(dir.FullName + "\\TestDirectory");
            double size = dirTree.CalculateSizeOfFolder("4");
            Assert.IsTrue(size >= 2d && size < 2.1d);
        }

        [TestMethod]
        public void SearchedFolderFound()
        {
            DirectoryInfo dir = Directory.GetParent("..\\..\\TestDirectory");
            DirectoryTree dirTree = new DirectoryTree(dir.FullName + "\\TestDirectory");
            Folder folder = dirTree.FindFolder("1");

            Assert.AreEqual("1", folder.Name);

            Assert.AreEqual(1, folder.Files.Count);

            Assert.AreEqual(2, folder.Folders.Count);
        }

        
    }
}
