using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingHomework;

namespace SortingAndSearchingTests
{
    [TestClass]
    public class SortingTests
    {
        [TestMethod]
        public void SelectionSort()
        {
            var collection = new SortableCollection<int>(new[] { 5, 1, 2, 4, 0, 6, 9, 8, 7 });

            collection.Sort(new SelectionSorter<int>());

            for (int i = 0; i < collection.Items.Count - 1; i++)
            {
                Assert.IsTrue(collection.Items[i] < collection.Items[i + 1]);
            }
        }

        [TestMethod]
        public void SelectionSortReverseSorted()
        {
            var collection = new SortableCollection<int>(new[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 });

            collection.Sort(new SelectionSorter<int>());

            for (int i = 0; i < collection.Items.Count - 1; i++)
            {
                Assert.IsTrue(collection.Items[i] < collection.Items[i + 1]);
            }
        }


        [TestMethod]
        public void QuickSort()
        {
            var collection = new SortableCollection<int>(new[] { 5, 1, 2, 4, 0, 6, 9, 8, 7 });

            collection.Sort(new Quicksorter<int>());

            for (int i = 0; i < collection.Items.Count - 1; i++)
            {
                Assert.IsTrue(collection.Items[i] < collection.Items[i + 1]);
            }
        }

        [TestMethod]
        public void QuickSortReverseSorted()
        {
            var collection = new SortableCollection<int>(new[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 });

            collection.Sort(new Quicksorter<int>());

            for (int i = 0; i < collection.Items.Count - 1; i++)
            {
                Assert.IsTrue(collection.Items[i] < collection.Items[i + 1]);
            }
        }

        [TestMethod]
        public void MergeSort()
        {
            var collection = new SortableCollection<int>(new[] { 5, 1, 2, 4, 0, 6, 9, 8, 7 });

            collection.Sort(new MergeSorter<int>());

            for (int i = 0; i < collection.Items.Count - 1; i++)
            {
                Assert.IsTrue(collection.Items[i] < collection.Items[i + 1]);
            }
        }

        [TestMethod]
        public void MergeSortReverseSorted()
        {
            var collection = new SortableCollection<int>(new[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 });

            collection.Sort(new MergeSorter<int>());

            for (int i = 0; i < collection.Items.Count - 1; i++)
            {
                Assert.IsTrue(collection.Items[i] < collection.Items[i + 1]);
            }
        }

    }
}
