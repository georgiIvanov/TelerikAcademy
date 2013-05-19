using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace Problem04_Free_Content
{
    public interface ICatalog
    {
        void Add(IContent content);

        IEnumerable<IContent> GetListContent(string title, int numberOfContentElementsToList);

        int UpdateContent(string oldUrl, string newUrl);
    }
}
