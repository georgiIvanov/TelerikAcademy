using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        BinaryTree<int, string> tree = new BinaryTree<int, string>(10, "root!");
        tree.AddValue(1, "left");
        tree.AddValue(3, "left2");
        tree.AddValue(-5, "left2");
        tree.AddValue(4, "left3");
        tree.AddValue(12, "right");
        tree.AddValue(20, "right2");
        tree.AddValue(22, "right2");
        tree.AddValue(19, "right2");
        tree.AddValue(30, "right3");
        //tree.DeleteByKey(-5);
        //tree.DeleteByKey(3);
        //tree.DeleteByKey(12);
        //Console.WriteLine(tree.ToString());

        foreach (TreeNode<int, string> item in tree)
        {
            Console.WriteLine(item.Value);
        }

        BinaryTree<int, string> tree2 = new BinaryTree<int, string>(10, "root!");
        tree2.AddValue(1, "left");
        tree2.AddValue(3, "left2");
        tree2.AddValue(-5, "left2");
        tree2.AddValue(4, "left3");
        tree2.AddValue(12, "right");
        tree2.AddValue(20, "right2");
        tree2.AddValue(22, "right2");
        tree2.AddValue(19, "right2");
        tree2.AddValue(30, "right3");
        
        if (tree.Equals(tree2)) //if(tree == tree2)
        {
            Console.WriteLine("\ntrees are equal");
        }
        else
        {
            Console.WriteLine("\ntrees are not equal :/");
        }

        Console.WriteLine(tree.GetHashCode());
        Console.WriteLine(tree2.GetHashCode());

        //cloned tree, shows there is no change in tree2
        BinaryTree<int, string> clonedTree = (BinaryTree<int, string>)tree2.Clone();
        Console.WriteLine(clonedTree.ToString());
        clonedTree.SetNodeValue(30, "bla-bla");
        Console.WriteLine(clonedTree.ToString());
        Console.WriteLine(tree2.ToString());
    }
}

/// <summary>
/// Binary search tree with Key-Value pair
/// </summary>
/// <typeparam name="K">key</typeparam>
/// <typeparam name="V">value</typeparam>
class BinaryTree<K, V> : IEnumerable<V>, ICloneable where K : IComparable
{
    TreeNode<K, V> root;
    uint count;
    public BinaryTree(K key, V value)
    {
        root = new TreeNode<K, V>(key, value);
        count = 0;
    }

    public void AddValue(K key, V value)
    {
        root.AddChild(new TreeNode<K, V>(key, value));
        count++;
    }
    public void DeleteByKey(K key)
    {
        root.DeleteElement(key, ref count);
    }
    public V GetNodeValue(K key)
    {
        return root.GetValue(key);
    }
    public void SetNodeValue(K key, V value)
    {
        root.GetNode(key).Value = value;
    }

    public object Clone()
    {
        BinaryTree<K, V> clonedRoot = new BinaryTree<K, V>(this.root.Key, this.root.Value);

        foreach (TreeNode<K, V> item in this)
        {
            TreeNode<K, V> newNode = new TreeNode<K,V>(item.Key, item.Value);
            clonedRoot.AddValue(newNode.Key, newNode.Value);
        }

        return clonedRoot;
    }
    public override bool Equals(object obj)
    {
        BinaryTree<K, V> tr = (BinaryTree<K, V>)obj;
        foreach (TreeNode<K, V> item in this)
        {
            if (!tr.GetNodeValue(item.Key).Equals(item.Value))
            {
                return false;
            }
        }

        return true;
    }
    public override int GetHashCode()
    {
        int hash = 17;
        unchecked
        {
            foreach (TreeNode<K, V> item in this)
            {
                hash *= (item.Key.GetHashCode() + item.Value.GetHashCode()) * 97;
            }
        }
        return hash;
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(root.Value.ToString());
        PrintDFS(root, string.Empty, sb);
        return sb.ToString();
    }
    private void PrintDFS(TreeNode<K, V> root, string spaces, StringBuilder sb)
    {
        if (root.GetLeftNode != null)
        {
            PrintDFS(root.GetLeftNode, spaces + "\t", sb);
        }

        if (root.GetRightNode != null)
        {
            PrintDFS(root.GetRightNode, spaces + "\t", sb);
        }
        if (spaces != string.Empty)
        {
            sb.AppendFormat("{0}{1}\n", spaces, root.Value.ToString());
        }
    }

    public static bool operator ==(BinaryTree<K, V> a, BinaryTree<K, V> b)
    {
        foreach (TreeNode<K, V> item in a)
        {
            if (!b.GetNodeValue(item.Key).Equals(item.Value))
            {
                return false;
            }
        }

        return true;
    }
    public static bool operator !=(BinaryTree<K, V> a, BinaryTree<K, V> b)
    {
        foreach (TreeNode<K, V> item in a)
        {
            if (!b.GetNodeValue(item.Key).Equals(item.Value))
            {
                return true;
            }
        }

        return false;
    }

    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return (IEnumerator)GetEnumerator();
    }
    IEnumerator<V> IEnumerable<V>.GetEnumerator()
    {
        return (IEnumerator<V>)GetEnumerator();
    }
    public TreeNodeEnum<K, V> GetEnumerator()
    {
        return new TreeNodeEnum<K, V>(root, count);
    }
}
