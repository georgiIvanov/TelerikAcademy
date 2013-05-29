using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.LinkedList
{
    class ListItem<T>
    {
        T value;
        ListItem<T> nextItem;

        public ListItem()
        {

        }

        public ListItem(T value)
        {
            this.value = value;
        }

        public T Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        public ListItem<T> NextItem
        {
            get
            {
                return this.nextItem;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Next item cannot be set null.");
                }
                this.nextItem = value;
            }
        }
    }
}
