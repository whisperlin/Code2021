using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class MapAlign  
{
    [MenuItem("工具/对其/整格对齐 _F8")]
    static void Start()
    {
        foreach (GameObject g in Selection.gameObjects)
        {
            Vector3 p = g.transform.position;
            if(p.x>0f)
                p.x = (int)(p.x+0.5f);
            else
                p.x = (int)(p.x - 0.5f);
            if(p.z>0f)
                p.z = (int)(p.z+0.5f);
            else
                p.z = (int)(p.z - 0.5f);
            g.transform.position = p;
        }
    }

     
}
