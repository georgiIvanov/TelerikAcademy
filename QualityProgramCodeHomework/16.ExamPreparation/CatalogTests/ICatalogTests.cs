using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problem04_Free_Content;
using Problem04_Free_Content.Enumerators;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CatalogTests
{
    [TestClass]
    public class ICatalogTests
    {
        [TestMethod]
        public void AddOne()
        {
            Catalog catalog = new Catalog();
            string[] entryParams = { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" };
            CatalogEntry entry = new CatalogEntry(Content.Book, entryParams);
            catalog.Add(entry);
            IEnumerable<IContent> searchResult = catalog.GetListContent("Intro C#", 1);

            int actualCount = searchResult.Count();

            Assert.AreEqual(1, actualCount);
        }

        [TestMethod]
        public void AddTwoSameEntries()
        {
            Catalog catalog = new Catalog();
            string[] entryParams = { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" };
            CatalogEntry entry = new CatalogEntry(Content.Book, entryParams);
            catalog.Add(entry);
            catalog.Add(entry);

            IEnumerable<IContent> searchResult = catalog.GetListContent("Intro C#", 30);

            int actualCount = searchResult.Count();

            Assert.AreEqual(2, actualCount);
        }

        [TestMethod]
        public void AddMultipleEntries()
        {
            Catalog catalog = new Catalog();

            string[] entryParams = { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" };
            CatalogEntry entry = new CatalogEntry(Content.Book, entryParams);
            catalog.Add(entry);

            AddSomeEntries(catalog, ref entryParams, ref entry);

            bool searchIsAccurate = true;
            IEnumerable<IContent> searchResult = catalog.GetListContent("One", 3);
            if (searchResult.Count() != 2)
            {
                searchIsAccurate = false;
            }

            searchResult = catalog.GetListContent("Angel Of Death", 3);
            if (searchResult.Count() != 1)
            {
                searchIsAccurate = false;
            }

            searchResult = catalog.GetListContent("EazFuscator.NET", 1);
            if (searchResult.Count() != 1)
            {
                searchIsAccurate = false;
            }

            searchResult = catalog.GetListContent("Intro C#", 40);
            if (searchResult.Count() != 1)
            {
                searchIsAccurate = false;
            }

            Assert.AreEqual(true, searchIsAccurate);
        }

        [TestMethod]
        public void SearchForLessEntries()
        {
            Catalog catalog = new Catalog();

            string[] entryParams = { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" };
            CatalogEntry entry = new CatalogEntry(Content.Book, entryParams);
            catalog.Add(entry);

            AddSomeEntries(catalog, ref entryParams, ref entry);

            catalog.Add(entry);
            catalog.Add(entry);
            catalog.Add(entry);
            catalog.Add(entry);
            catalog.Add(entry);
            catalog.Add(entry);
            catalog.Add(entry);
            catalog.Add(entry);
            catalog.Add(entry);

            bool searchIsAccurate = false;
            IEnumerable<IContent> searchResult = catalog.GetListContent("One", 5);
            IEnumerable<IContent> all = catalog.GetListContent("One", 30);

            if (searchResult.Count() == 5 && all.Count() == 11)
            {
                searchIsAccurate = true;
            }


            Assert.AreEqual(true, searchIsAccurate);
        }

        [TestMethod]
        public void SearchForMoreEntries()
        {
            Catalog catalog = new Catalog();

            string[] entryParams = { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" };
            CatalogEntry entry = new CatalogEntry(Content.Book, entryParams);
            catalog.Add(entry);

            AddSomeEntries(catalog, ref entryParams, ref entry);

            catalog.Add(entry);
            catalog.Add(entry);
            catalog.Add(entry);
            catalog.Add(entry);
            catalog.Add(entry);
            catalog.Add(entry);
            catalog.Add(entry);
            catalog.Add(entry);
            catalog.Add(entry);

            bool searchIsAccurate = false;
            IEnumerable<IContent> searchResult = catalog.GetListContent("One", 300);

            if (searchResult.Count() == 11)
            {
                searchIsAccurate = true;
            }


            Assert.AreEqual(true, searchIsAccurate);
        }

        private static void AddSomeEntries(Catalog catalog, ref string[] entryParams, ref CatalogEntry entry)
        {
            entryParams = new string[] { "One", "James Wong (2001)", "969763002", "http://www.imdb.com/title/tt0267804/" };
            entry = new CatalogEntry(Content.Movie, entryParams);
            catalog.Add(entry);

            entryParams = new string[] { "Angel Of Death", "Slayer", "365763002", "http://lalala.com" };
            entry = new CatalogEntry(Content.Song, entryParams);
            catalog.Add(entry);

            entryParams = new string[] { "EazFuscator.NET", "Kharkiv", "362268542", "http://lolerskates.com" };
            entry = new CatalogEntry(Content.Application, entryParams);
            catalog.Add(entry);

            entryParams = new string[] { "One", "James Wong (2001)", "969763002", "http://www.imdb.com/title/tt0267804/" };
            entry = new CatalogEntry(Content.Movie, entryParams);
            catalog.Add(entry);

            entryParams = new string[] { "One", "James Wong (2001)", "969763002", "http://www.imdb.com/title/tt0267804/" };
            entry = new CatalogEntry(Content.Movie, entryParams);
        }

        [TestMethod]
        public void UpdateOne()
        {
            Catalog catalog = new Catalog();
            string[] entryParams = { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" };
            CatalogEntry entry = new CatalogEntry(Content.Book, entryParams);
            catalog.Add(entry);
            AddSomeEntries(catalog, ref entryParams, ref entry);

            int updated = catalog.UpdateContent("http://www.introprogramming.info", "http://www.introprogramming.info/en/");
            Assert.AreEqual(1, updated);
        }

        [TestMethod]
        public void UpdateWithNoMatches()
        {
            Catalog catalog = new Catalog();
            string[] entryParams = { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" };
            CatalogEntry entry = new CatalogEntry(Content.Book, entryParams);
            catalog.Add(entry);
            AddSomeEntries(catalog, ref entryParams, ref entry);

            int updated = catalog.UpdateContent("http://www.lalala.info", "http://www.introprogramming.info/en/");
            Assert.AreEqual(0, updated);
        }

        [TestMethod]
        public void DoubleUpdateAnEntry()
        {
            Catalog catalog = new Catalog();
            string[] entryParams = { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" };
            CatalogEntry entry = new CatalogEntry(Content.Book, entryParams);
            catalog.Add(entry);

            int updated = catalog.UpdateContent("http://www.introprogramming.info", "http://www.introprogramming.info/en/");
            Assert.AreEqual(1, updated);

            updated = catalog.UpdateContent("http://www.introprogramming.info", "http://www.introprogramming.info/en/");
            Assert.AreEqual(0, updated);
        }
    }
}
