using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGameObjectPools : MonoBehaviour
{
    Dictionary<GameObject, Stack<GameObject>> gameObjects = new Dictionary<GameObject, Stack<GameObject>>();
    Dictionary<GameObject, GameObject> usingObjects = new Dictionary<GameObject,   GameObject >();

    public GameObject Create(GameObject baseGameObject)
    {
        Stack<GameObject> st ;
        if (!gameObjects.TryGetValue(baseGameObject, out st))
        {
            gameObjects[baseGameObject] = st = new Stack<GameObject>();
        }
        if (st.Count > 0)
        {
            GameObject g = st.Pop();
            g.SetActive(true);
            return g;
        }
        else
        {
            GameObject g = GameObject.Instantiate(baseGameObject);
            usingObjects[g]  = baseGameObject;
            Common.SetParentSafe(g.transform, baseGameObject.transform.parent);
            g.transform.SetAsLastSibling();
            g.SetActive(true);
            return g;
        }
    }
    public void Release(GameObject g)
    {
        GameObject baseObj;
        if (usingObjects.TryGetValue(g, out baseObj))
        {
            gameObjects[baseObj].Push(g);
            g.SetActive(false);
        }
    }
}
