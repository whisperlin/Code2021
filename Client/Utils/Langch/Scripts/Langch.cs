using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Langch : MonoBehaviour
{

    public static void HideWaitingInit()
    {
        GameObject g = GameObject.Find("LancherCanvas");
        if(g!=null)
            GameObject.DestroyImmediate(g,true);
    }
     
}
