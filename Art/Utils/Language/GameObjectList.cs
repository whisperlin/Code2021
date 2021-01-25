using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectList : MonoBehaviour
{
    public GameObject[] gameobjects;

    public Dictionary<string, GameObject> gameObjectDictionary = new Dictionary<string, GameObject>();


    public void Start()
    {
        FillDictionary();
    }
    bool isFill = false;
    private void FillDictionary()
    {
        if (isFill)
        {
            return;
        }
        isFill = true;
        foreach (GameObject g in gameobjects)
        {
            if (null != g)
            {
                gameObjectDictionary[g.name] = g;
            }
        }
    }
}
