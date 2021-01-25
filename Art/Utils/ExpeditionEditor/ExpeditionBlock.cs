using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ExpeditionBlock : MonoBehaviour
{
    [Label("区域id")]
    public int id = 1;
    [Label("地块")]
    public Transform ground;
    [Label("地面物")]
    public Transform trees;

    [Label("地面事件")]
    public Transform events;
    [Label("地面碰撞区域")]
    public BoxNavMeshArea area;

#if ART_PROJECT


    private void Update()
    {
        if (ground == null)
        {
            ground = new GameObject("Ground").transform;
            ground.parent = transform;
            ground.transform.localPosition = Vector3.zero;
            ground.transform.localScale = Vector3.one;
            ground.transform.localRotation = Quaternion.identity;
        }

        

        if (trees == null)
        {
            trees = new GameObject("Tree").transform;
            trees.parent = transform ;
            trees.transform.localPosition = Vector3.zero;
            trees.transform.localScale = Vector3.one;
            trees.transform.localRotation = Quaternion.identity;
        }
        if (null == events)
        {
            events = new GameObject("Events").transform;
            events.parent = transform;
            events.transform.localPosition = Vector3.zero;
            events.transform.localScale = Vector3.one;
            events.transform.localRotation = Quaternion.identity;
        }
        if (null == area)
        {
            GameObject g = new GameObject("Collider");
            area = g.AddComponent<BoxNavMeshArea>();
            g.transform.parent = transform;
            g.transform.localPosition = Vector3.zero;
            g.transform.localRotation = Quaternion.identity;
            g.transform.localScale = Vector3.one;
        }

    }

#endif

}
