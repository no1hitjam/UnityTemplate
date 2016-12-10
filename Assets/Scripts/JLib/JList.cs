using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JList<T> : ICollection<T>, IEnumerable<T>, IList<T>
{
    protected List<T> list;

    public JList ()
    {
        list = new List<T>();
    }

    public JList (int count, Func<int,T> constructor) : this()
    {
        JLib.For(count, (int i) => {
            list.Add(constructor(i));
        });
    }
    
    public virtual T this[int index]
    {
        get
        {
            if (index < 0 || index > Count) {
                Debug.LogError("JList: index out of range");
                Debug.Break();
                return default(T);
            }

            return ((IList<T>)list)[index];
        }

        set
        {
            ((IList<T>)list)[index] = value;
        }
    }

    public int Count
    {
        get
        {
            return ((IList<T>)list).Count;
        }
    }

    public bool IsReadOnly
    {
        get
        {
            return ((IList<T>)list).IsReadOnly;
        }
    }

    public void Add(T item)
    {
        ((IList<T>)list).Add(item);
    }

    public void Add(params T[] items)
    {
        foreach (var item in items) {
            list.Add(item);
        }
    }

    public void Clear()
    {
        ((IList<T>)list).Clear();
    }

    public bool Contains(T item)
    {
        return ((IList<T>)list).Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        ((IList<T>)list).CopyTo(array, arrayIndex);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return ((IList<T>)list).GetEnumerator();
    }

    public virtual int IndexOf(T item)
    {
        return ((IList<T>)list).IndexOf(item);
    }

    public virtual void Insert(int index, T item)
    {
        ((IList<T>)list).Insert(index, item);
    }

    public bool Remove(T item)
    {
        return ((IList<T>)list).Remove(item);
    }

    public virtual void RemoveAt(int index)
    {
        ((IList<T>)list).RemoveAt(index);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((ICollection<T>)list).GetEnumerator();
    }
    
}
