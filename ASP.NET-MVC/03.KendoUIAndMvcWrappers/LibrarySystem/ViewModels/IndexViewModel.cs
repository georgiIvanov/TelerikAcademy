using Kendo.Mvc.UI;
using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibrarySystem.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<TreeViewItemModel> TreeViewItems { get; set; }
        public IEnumerable<BookViewModel> Books { get; set; }
    }
}