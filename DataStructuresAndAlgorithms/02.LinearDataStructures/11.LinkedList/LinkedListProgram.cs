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
            ListItem<int> nextItem;
            
            for (int i = 1; i < 11; i++)
			{
                nextItem = new ListItem<int>(i);
                listItem.NextItem = nextItem;
                listItem = nextItem;
			}

            nextItem = list.FirstItem;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(nextItem.Value);
                nextItem = nextItem.NextItem;
            }
        }
    }
}