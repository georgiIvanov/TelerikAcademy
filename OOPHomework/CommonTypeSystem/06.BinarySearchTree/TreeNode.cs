using System;

class TreeNode<K, V> where K : IComparable
{
    K key;
    V value;
    TreeNode<K, V> leftChild;
    TreeNode<K, V> rightChild;

    public TreeNode(K key, V value)
    {
        this.key = key;
        this.value = value;
        leftChild = null;
        rightChild = null;
    }

    public V Value
    {
        get { return this.value; }
        set { this.value = value; }
    }
    public K Key
    {
        get { return this.key; }
        set { this.key = value; }
    }
    public TreeNode<K, V> GetLeftNode
    {
        get { return leftChild; }
    }
    public TreeNode<K, V> GetRightNode
    {
        get { return rightChild; }
    }

    public void AddChild(TreeNode<K, V> childNode)
    {
        if (this.key.CompareTo(childNode.key) < 0)
        {
            if (rightChild != null) rightChild.AddChild(childNode);
            else rightChild = new TreeNode<K, V>(childNode.key, childNode.value);
        }
        else if (this.key.CompareTo(childNode.key) > 0)
        {
            if (leftChild != null) leftChild.AddChild(childNode);
            else leftChild = new TreeNode<K, V>(childNode.key, childNode.value);
        }
        else
            this.value = childNode.value;
    }

    public V GetValue(K key)
    {
        if (this.key.CompareTo(key) == 0)
        {
            return value;
        }
        else if (this.key.CompareTo(key) < 0)
        {
            if (rightChild != null)
            {
                return rightChild.GetValue(key);
            }
            else
                return default(V);
        }
        else// if (this.key.CompareTo(key) < 0)
        {
            if (leftChild != null)
            {
                return leftChild.GetValue(key);
            }
            else
                return default(V);
        }
    }

    public TreeNode<K, V> GetNode(K key)
    {
        if (this.key.CompareTo(key) == 0)
        {
            return this;
        }
        else if (this.key.CompareTo(key) < 0)
        {
            if (rightChild != null)
            {
                return rightChild.GetNode(key);
            }
            else
                return null;
        }
        else// if (this.key.CompareTo(key) < 0)
        {
            if (leftChild != null)
            {
                return leftChild.GetNode(key);
            }
            else
                return null;
        }
    }

    public bool DeleteElement(K key, ref uint treeCount)
    {
        if (this.key.CompareTo(key) == 0)
        {
            treeCount--;
            return true;
        }
        else if (this.key.CompareTo(key) < 0)
        {
            if (rightChild != null)
            {
                if (rightChild.DeleteElement(key, ref treeCount))
                {
                    this.rightChild = ReorderAfterDeletion(this.rightChild);
                }
            }
        }
        else
        {
            if (leftChild != null)
            {
                if (leftChild.DeleteElement(key, ref treeCount))
                {
                    this.leftChild = ReorderAfterDeletion(this.leftChild);
                }
            }
        }
        return false;
    }
    TreeNode<K, V> ReorderAfterDeletion(TreeNode<K, V> a)
    {
        if (a.leftChild != null)
        {
            if (a.rightChild != null)
            {
                TreeNode<K, V> temp = a.rightChild;
                a = a.leftChild;
                a.rightChild = temp;
            }
            else
                a = a.leftChild;
        }
        else if (a.rightChild != null)
        {
            if (a.leftChild != null)
            {
                TreeNode<K, V> temp = a.leftChild;
                a = a.rightChild;
                a.leftChild = temp;
            }
            else
                a = a.rightChild;
        }
        else
        {
            a = null;
        }
        return a;
    }
}