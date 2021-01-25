using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LCHMap<K, T>
{
    public Dictionary<K, T> dict = new Dictionary<K, T>();
    public List<T> list = new List<T>();

    public void Set(K k,T t)
    {
        dict[k] = t;
        list.Remove(t);
        list.Add(t);
    }

     

    public bool TryGetValue(K k ,out T t)
    {
        return dict.TryGetValue(k, out t);
    }

     
}
