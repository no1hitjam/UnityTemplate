using System;
using System.Collections.Generic;


public class JQueuePair<T>
{
    private T current;
    private T last;

    private Action<T> Do;
    private Action<T> Undo;

    public JQueuePair(Action<T> Do, Action<T> Undo, T last)
    {
        this.Do = Do;
        this.Undo = Undo;
        this.current = last;
        this.last = last;
    }

    public void Add(T item)
    {
        if (item.Equals(current)) {
            return;
        }
        Undo(last);
        Do(item);

        last = current;
        current = item;
    }
}

