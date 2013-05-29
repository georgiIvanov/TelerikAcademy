using System;
using System.Text;
using System.Threading.Tasks;

namespace _11.LinkedList
{
    class LinkedListProgram
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>(0);

            ListItem<int> listItem = list.FirstItem;
            
            for (int i = 1; i < 11; i++)
			{
                ListItem<int> nextItem = new ListItem<int>(i);
                listItem.NextItem = nextItem;
                listItem = nextItem;
			}
        }
    }
}