using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem04_Free_Content;
using Problem04_Free_Content.Enumerators;

namespace Problem04_Free_Content
{
    public class CatalogEntry : IComparable, IContent
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public Int64 Size { get; set; }
        public Content Type { get; set; }
        private string url;

        public string URL
        {
            get
            {
                return this.url;
            }
            set
            {
                this.url = value;
                this.TextRepresentation = this.ToString();
            }
        }

        

        public string TextRepresentation { get; set; }

        public CatalogEntry(Content type, string[] commandParams)
        {
            this.Type = type;
            this.Title = commandParams[(int)ContentParameters.Title];
            this.Author = commandParams[(int)ContentParameters.Author];
            this.Size = Int64.Parse(commandParams[(int)ContentParameters.Size]);
            this.URL = commandParams[(int)ContentParameters.Url];
        }

        public int CompareTo(object obj)
        {
            if (null == obj)
                return 1;

            CatalogEntry otherContent = obj as CatalogEntry;
            if (otherContent != null)
            {
                int comparisonResul = this.TextRepresentation.CompareTo(otherContent.TextRepresentation);

                return comparisonResul;
            }

            throw new ArgumentException("Object is not a Content");
        }

        public override string ToString()
        {
            string output = String.Format("{0}: {1}; {2}; {3}; {4}", this.Type.ToString(), this.Title, this.Author, this.Size, this.URL);

            return output;
        }
    }
}
