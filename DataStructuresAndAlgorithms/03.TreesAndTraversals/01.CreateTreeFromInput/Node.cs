using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.CreateTreeFromInput
{
    class Node
    {
        int value;
        bool hasParent;
        List<Node> children;

        public Node(int value)
        {
            this.Value = value;
            this.hasParent = true;
        }

        public Node(int value, Node child)
            : this(value)
        {
            this.AddChild(child);
            this.hasParent = false;
        }

        public void AddChild(Node child)
        {
            if (this.children == null)
            {
                this.children = new List<Node>();
            }
            this.children.Add(child);
            
        }

        public int Value
        {
            get
            {
                return this.value;
            }
            private set
            {
                this.value = value;
            }
        }

        public List<Node> GetChildren
        {
            get
            {
                if (this.children == null)
                {
                    return new List<Node>();
                }
                return this.children;
            }
        }

        public bool HasParent
        {
            get
            {
                return this.hasParent;
            }
            set
            {
                this.hasParent = value;
            }
        }
    }
}
