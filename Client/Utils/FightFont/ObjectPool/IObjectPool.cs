using System.Collections;
using System.Collections.Generic;

public interface IPoolObject
{
    void ResetValue();
}

public class LCHPool
{
    Dictionary<System.Type, Stack> dictionary = new Dictionary<System.Type, Stack>();

    Stack GetList(System.Type t)
    {
        Stack list;
        if (!dictionary.TryGetValue(t, out list))
        {
            list = new Stack();
            dictionary[t] = list;
        }
        return list;
    }
    public T CreateObject<T>() where T : IPoolObject  ,new()
    {
        System.Type t = typeof(T);
        Stack l = GetList(t);
        T o;
        if (l.Count == 0)
        {
            o = new T();
            o.ResetValue();
            return o;
        }
        o = (T)l.Pop();
        o.ResetValue();
        return o;
    }
    public void DestoryObject<T>(T obj)
    {
        System.Type t = typeof(T);
        Stack l = GetList(t);
        l.Push(obj);
    }

    public void Clear<T>(T obj)
    {
        System.Type t = typeof(T);
        Stack l = GetList(t);
        l.Clear();
    }
}
 