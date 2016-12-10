using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JDic<TKey, TValue> : ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IDictionary<TKey, TValue>
{
    private Dictionary<TKey, TValue> dic;
    private TValue defaultValue;
    private bool hasDefaultValue;

    public JDic()
    {
        hasDefaultValue = false;
    }

    public JDic(TValue defaultValue)
    {
        this.defaultValue = defaultValue;
        hasDefaultValue = true;
    }

    public JList<KeyValuePair<TKey, TValue>> ToList()
    {
        var list = new JList<KeyValuePair<TKey, TValue>>();
        foreach (var entry in dic) {
            list.Add(entry);
        }
        return list;
    }

    public TValue this[TKey key]
    {
        get
        {
            if (!ContainsKey(key)) {
                if (hasDefaultValue) {
                    return defaultValue;
                } else {
                    Debug.LogError("JDic: key [" + key.ToString() + "] does not exist in " + ToString());
                    Debug.Break();
                    return default(TValue);
                }
            }
            return ((IDictionary<TKey, TValue>)dic)[key];
        }

        set
        {
            ((IDictionary<TKey, TValue>)dic)[key] = value;
        }
    }

    public int Count
    {
        get
        {
            return ((IDictionary<TKey, TValue>)dic).Count;
        }
    }

    public bool IsReadOnly
    {
        get
        {
            return ((IDictionary<TKey, TValue>)dic).IsReadOnly;
        }
    }

    public ICollection<TKey> Keys
    {
        get
        {
            return ((IDictionary<TKey, TValue>)dic).Keys;
        }
    }

    public ICollection<TValue> Values
    {
        get
        {
            return ((IDictionary<TKey, TValue>)dic).Values;
        }
    }

    public void Add(KeyValuePair<TKey, TValue> item)
    {
        ((IDictionary<TKey, TValue>)dic).Add(item);
    }

    public void Add(TKey key, TValue value)
    {
        ((IDictionary<TKey, TValue>)dic).Add(key, value);
    }

    public void Add(TKey key)
    {
        if (!hasDefaultValue) {
            Debug.LogError("JDic: No default value");
            Debug.Break();
            return;
        }

        ((IDictionary<TKey, TValue>)dic).Add(key, defaultValue);
    }

    public void Clear()
    {
        ((IDictionary<TKey, TValue>)dic).Clear();
    }

    public bool Contains(KeyValuePair<TKey, TValue> item)
    {
        return ((IDictionary<TKey, TValue>)dic).Contains(item);
    }

    public bool ContainsKey(TKey key)
    {
        return ((IDictionary<TKey, TValue>)dic).ContainsKey(key);
    }

    public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
    {
        ((IDictionary<TKey, TValue>)dic).CopyTo(array, arrayIndex);
    }

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        return ((IDictionary<TKey, TValue>)dic).GetEnumerator();
    }

    public bool Remove(KeyValuePair<TKey, TValue> item)
    {
        return ((IDictionary<TKey, TValue>)dic).Remove(item);
    }

    public bool Remove(TKey key)
    {
        return ((IDictionary<TKey, TValue>)dic).Remove(key);
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        return ((IDictionary<TKey, TValue>)dic).TryGetValue(key, out value);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IDictionary<TKey, TValue>)dic).GetEnumerator();
    }
}
