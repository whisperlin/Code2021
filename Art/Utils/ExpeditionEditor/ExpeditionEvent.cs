using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExpeditionEvent : MonoBehaviour
{
    
    public enum Type
    {
        [Header("入口")]
        Begin,
        [Header("交叉路口")]
        Cross,
        //[Header("NPC")]
        //NPC,
    }
    [Label("事件类型")]
    public Type eventType = Type.Begin;


    public ScriptableObject data;
    void Start()
    {
        
    }
    void OnDrawGizmos()
    {
        switch (eventType)
        {
            case Type.Begin:
                {
                    Gizmos.color = Color.blue;
                    Gizmos.DrawSphere(transform.position, 0.3f);
                }
                break;
            case Type.Cross:
                {
                    Gizmos.color = Color.green;
                    Gizmos.DrawCube(transform.position,Vector3.one*0.6f);
                }
                break;
        }
        // Draw a yellow sphere at the transform's position
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
