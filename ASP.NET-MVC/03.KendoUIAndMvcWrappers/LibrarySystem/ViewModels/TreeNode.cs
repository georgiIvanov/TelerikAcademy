using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibrarySystem.ViewModels
{
    public class TreeNode
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public IEnumerable<TreeNode> Items { get; set; }
        public bool HasChildren { get; set; }
    }
}