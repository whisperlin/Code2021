using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveIn : MonoBehaviour
{
    public float dir = 3;
    public float time = 0.2f;
    Vector3 beginPositin;
    Vector3 endPositin;
    float curTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        beginPositin = Vector3.right * dir;
        transform.localPosition = beginPositin;
    }

 
    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        float t = curTime / time;
        if (t < 1)
        {
            transform.localPosition = Vector3.Lerp(beginPositin, Vector3.zero, t);
        }
        else
        {
            transform.localPosition = Vector3.zero;
            this.enabled = false;
            GameObject.Destroy(this);
        }
        
    }
}
