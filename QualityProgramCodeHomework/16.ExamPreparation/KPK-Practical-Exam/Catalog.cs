using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;
using Problem04_Free_Content;
using Problem04_Free_Content.Enumerators;

namespace Problem04_Free_Content
{
    public class Catalog : ICatalog
    {
        private MultiDictionary<string, IContent> url;
        private OrderedMultiDictionary<string, IContent> title;

        /// <summary>
        /// Creates a catalog in wich content can be inserted and searched.
        /// </summary>
        public Catalog()
        {
            bool allowDuplicateValues = true;
            this.title = new OrderedMultiDictionary<string, IContent>(allowDuplicateValues);
            this.url = new MultiDictionary<string, IContent>(allowDuplicateValues);
        }

        /// <summary>
        /// Adds a content entry in catalog.
        /// </summary>
        /// <param name="content">Catalog entry.</param>
        public void Add(IContent content)
        {
            this.title.Add(content.Title, content);
            this.url.Add(content.URL, content);
        }


        /// <summary>
        /// Returns a collection of entries with matching title.
        /// </summary>
        /// <param name="title">Title of searched content.</param>
        /// <param name="numberOfContentElementsToList">Number of matching entries to be returned.</param>
        /// <returns></returns>
        public IEnumerable<IContent> GetListContent(string title, int numberOfContentElementsToList)
        {
            IEnumerable<IContent> contentToList = from c in this.title[title] select c;

            return contentToList.Take(numberOfContentElementsToList);
        }

        /// <summary>
        /// Updates a content entry.
        /// </summary>
        /// <param name="old">Url to be replaced.</param>
        /// <param name="newUrl">New url.</param>
        /// <returns></returns>
        public int UpdateContent(string old, string newUrl)
        {
            int theElements = 0;

            List<IContent> contentToList = this.url[old].ToList();


            foreach (CatalogEntry content in contentToList)
            {
                this.title.Remove(content.Title, content);
                theElements++;
            }
            this.url.Remove(old);

            foreach (IContent content in contentToList)
            {
                content.URL = newUrl;
                this.title.Add(content.Title, content);
                this.url.Add(content.URL, content);
            }

            return theElements;
        }
    }
}
