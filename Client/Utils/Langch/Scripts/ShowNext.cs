using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowNext : MonoBehaviour
{

    public GameObject next;
    public float delayTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Next", delayTime);
    }

    // Update is called once per frame
    void Next()
    {
        next.SetActive(true);
        gameObject.SetActive(false);
        
    }
}
