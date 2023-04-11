using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagerDB
{
    /// <summary>
    /// List with OnListModified event
    /// </summary>
    public class ListPlus<T> : List<T>
    {
        public event EventHandler OnListModified;

        public new void Clear()
        {
            base.Clear();

            OnListModified?.Invoke(this, EventArgs.Empty);
        }

        public new void Remove(T item)
        {
            base.Remove(item);

            OnListModified?.Invoke(this, EventArgs.Empty);
        }

        public void RemoveRange(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                base.Remove(item);
            }

            OnListModified?.Invoke(this, EventArgs.Empty);
        }

        public new void RemoveAt(int index)
        {
            base.RemoveAt(index);

            OnListModified?.Invoke(this, EventArgs.Empty);
        }

        public new void RemoveRange(int index, int count)
        {
            base.RemoveRange(index, count);

            OnListModified?.Invoke(this, EventArgs.Empty);
        }

        public new void RemoveAll(Predicate<T> match)
        {
            base.RemoveAll(match);

            OnListModified?.Invoke(this, EventArgs.Empty);
        }

        public new void Add(T item)
        {
            base.Add(item);

            OnListModified?.Invoke(this, EventArgs.Empty);
        }

        public new void AddRange(IEnumerable<T> collection)
        {
            base.AddRange(collection);

            OnListModified?.Invoke(this, EventArgs.Empty);
        }

        public new void Insert(int index, T item)
        {
            base.Insert(index, item);

            OnListModified?.Invoke(this, EventArgs.Empty);
        }

        public new void InsertRange(int index, IEnumerable<T> collection)
        {
            base.InsertRange(index, collection);

            OnListModified?.Invoke(this, EventArgs.Empty);
        }
    }
}
