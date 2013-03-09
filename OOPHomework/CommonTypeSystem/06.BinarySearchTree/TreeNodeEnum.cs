using System;
using System.Collections;
class TreeNodeEnum<K, V> : IEnumerator where K : IComparable
{
    int position;
    TreeNode<K, V>[] nodeArr;

    public TreeNodeEnum(TreeNode<K, V> root, uint count)
    {
        position = 0;
        nodeArr = new TreeNode<K, V>[count];
        LoadDFS(root);
        position = -1;
    }

    private void LoadDFS(TreeNode<K, V> root)
    {
        if (root.GetLeftNode != null)
        {
            LoadDFS(root.GetLeftNode);
        }

        if (root.GetRightNode != null)
        {
            LoadDFS(root.GetRightNode);
        }
        if (position < nodeArr.Length)
        {
            nodeArr[position] = root;
            position++;
        }
    }

    public bool MoveNext()
    {
        position++;
        return (position < nodeArr.Length);
    }

    public void Reset()
    {
        position = -1;
    }

    public object Current
    {
        get
        {
            try
            {
                return nodeArr[position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
