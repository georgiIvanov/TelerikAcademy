using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _06.XmlInTreeView
{
    public partial class TreeViewPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.TreeView NewTree = new TreeView();

            NewTree.ID = "BookTreeView";
            NewTree.DataSourceID = "BookXmlDataSource";

            
            TreeNodeBinding RootBinding = new TreeNodeBinding();
            RootBinding.DataMember = "Book";
            RootBinding.TextField = "Title";

            TreeNodeBinding ParentBinding = new TreeNodeBinding();
            ParentBinding.DataMember = "Chapter";
            ParentBinding.TextField = "Heading";

            TreeNodeBinding LeafBinding = new TreeNodeBinding();
            LeafBinding.DataMember = "Section";
            LeafBinding.TextField = "Heading";

            NewTree.DataBindings.Add(RootBinding);
            NewTree.DataBindings.Add(ParentBinding);
            NewTree.DataBindings.Add(LeafBinding);

            ControlPlaceHolder.Controls.Add(NewTree);
        }
    }
}