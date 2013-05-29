using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.CreateDynamicQueue
{
    class QueueItem<T>
    {
        T value;
        QueueItem<T> previousItem;

        public QueueItem()
        {
        }

        public QueueItem(T value)
        {
            this.Value = value;
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

        public QueueItem<T> PreviousItem
        {
            get
            {
                return this.previousItem;
            }
            set
            {
                this.previousItem = value;
            }
        }
    }
}
