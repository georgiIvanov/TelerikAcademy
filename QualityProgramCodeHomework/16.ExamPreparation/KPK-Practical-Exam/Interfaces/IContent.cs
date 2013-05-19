using System;
using Problem04_Free_Content.Enumerators;

namespace Problem04_Free_Content
{
    public interface IContent : IComparable
    {
        string Title { get; set; }

        string Author { get; set; }

        Int64 Size { get; set; }

        string URL { get; set; }

        Content Type { get; set; }

        string TextRepresentation { get; set; }
    }
}
