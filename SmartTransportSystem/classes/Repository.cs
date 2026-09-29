using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTransportSystem.classes
{
    using System;
    using System.Collections.Generic;

    namespace SmartTransportSystem.classes
    {
        public class Repository<T>
        {
            private List<T> items = new List<T>();

            public void Add(T item)
            {
                if (item != null)
                {
                    items.Add(item);
                }
            }

            public bool Remove(T item)
            {
                return items.Remove(item);
            }

            public List<T> GetAll()
            {
                return items;
            }

            public T Find(Predicate<T> match)
            {
                return items.Find(match);
            }

            public List<T> FindAll(Predicate<T> match)
            {
                return items.FindAll(match);
            }

            public int Count => items.Count;
        }
    }
}
