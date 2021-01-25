using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestory : MonoBehaviour {

    public float destoryTime = 2f;
    void Start()
    {
        GameObject.Destroy(gameObject, destoryTime);
    }
    
     

}
