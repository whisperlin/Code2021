using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineUtil : MonoBehaviour
{

    public static CoroutineUtil _instance = null;
    public static Coroutine RunCoroutine(IEnumerator routine)
    {
        if (null == _instance)
        {
            GameObject g = new GameObject("CoroutineUtil");
            GameObject.DontDestroyOnLoad(g);
            _instance = g.AddComponent<CoroutineUtil>();
        }
        return _instance.StartCoroutine(routine);
    }

     
}
