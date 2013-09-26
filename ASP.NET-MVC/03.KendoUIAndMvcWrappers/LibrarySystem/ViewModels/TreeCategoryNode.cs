using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibrarySystem.ViewModels
{
    public class TreeCategoryNode
    {
        public string Name { get; set; }
        public IEnumerable<BookNode> Items { get; set; }
        public bool HasChildren { get; set; }
    }
}