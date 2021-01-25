using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthbarManager : MonoBehaviour
{
    public HealthBar bar;
    public Camera cam;
    static HealthbarManager mgr = null;
    public static HealthbarManager instance
    {
        get {
            if(null == mgr)
            {

                var obj = Resources.Load(@"HealthBarSystem",typeof(GameObject));
                GameObject o = GameObject.Instantiate(obj) as GameObject;
                mgr = o.GetComponent<HealthbarManager>();
                mgr.cam = Camera.main;
                if(mgr.cam==null)
                {
                    Camera[]  cams  = GameObject.FindObjectsOfType<Camera>();
                    foreach (Camera c in cams)
                    {
                        if (c.gameObject.activeSelf && ((c.cullingMask & 1) == 1 || c.cullingMask == -1))
                        {
                            mgr.cam = c;
                        }
                    }
                    
                }
            }
            return mgr;
        }
    }
    Stack<HealthBar> bars = new Stack<HealthBar>();
    public HealthBar Create()
    {
        if (bars.Count == 0)
        {
            HealthBar b = GameObject.Instantiate(bar);
            b.transform.parent = this.transform;
            b.gameObject.transform.localScale = Vector3.one;
            return b;
        }
        else
        {
            HealthBar b = bars.Pop();
            
            b.gameObject.SetActive(true);
            return b;
        }
    }
    public void Release( ref HealthBar b)
    {
        b.gameObject.SetActive(false);
        bars.Push(b);
        b = null;
    }
}
