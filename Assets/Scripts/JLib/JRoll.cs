using System;
using System.Collections.Generic;


public class JRoll<T> : JList<T>
{
    private int offset;

    public JRoll() : base()
    {
        offset = 0;
    }

    public JRoll(int count, Func<int, T> constructor) : this()
    {
        JLib.For(count, (int i) => {
            list.Add(constructor(i));
        });
    }

    public int Offset
    {
        get { return offset; }
        set { offset = JLib.Mod(value, Count); }
    }

    public T IndexWithoutOffsetOf(int index)
    {
        return list[index];
    }

    public override T this[int index]
    {
        get
        {
            return ((IList<T>)list)[JLib.Mod(index + offset, Count)];
        }

        set
        {
            ((IList<T>)list)[JLib.Mod(index + offset, Count)] = value;
        }
    }


    public override int IndexOf(T item)
    {
        return JLib.Mod(((IList<T>)list).IndexOf(item) - offset, Count);
    }

    public override void Insert(int index, T item)
    {
        ((IList<T>)list).Insert(JLib.Mod(index + offset, Count), item);
    }

    public override void RemoveAt(int index)
    {
        ((IList<T>)list).RemoveAt(JLib.Mod(index + offset, Count));
    }
}

