using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ExpeditioCtrlPoint
{
    public ExpeditioCtrlPoint()
    {
    }
    public ExpeditioCtrlPoint(Vector3 _pos, Vector3 _forward)
    {
        this.pos = _pos;
        this.forward = _forward;
    }
    public Vector3 pos;
    public Vector3 forward;
 
}
[System.Serializable]
public class ConnectionExpeditionRoadPoint
{
    

    public List<ExpeditioCtrlPoint> mCtrlPotints = new List<ExpeditioCtrlPoint>();
    public ExpeditionRoadPoint next;
   
    //public List<ExpeditionFinaPoint> wayPoint = new List<ExpeditionFinaPoint>();
}
public class ExpeditionRoadPoint : MonoBehaviour
{
#if ART_PROJECT
    public static ConnectionExpeditionRoadPoint editingPath = null;
#endif
    public enum Type
    {
        [Header("入口")]
        Begin,
        [Header("交叉路口")]
        Cross,
    }

    [Label("事件类型")]
    public Type eventType = Type.Begin;

    //static Transform cmp;

    public static Vector3 GetMidVector3H(Vector3 d0, Vector3 d1,float t)
    {
        d0.y = 0;
        d0.Normalize();
        d1.y = 0;
        d1.Normalize();
        return Vector3.Lerp(d0, d1, t).normalized;
    }

   
    //public List<ConnectionExpeditionRoadPoint> connecteds = new List<ConnectionExpeditionRoadPoint>();
    void Start()
    {
        
    }

    void OnDrawGizmos()
    {
        switch (eventType)
        {
            case Type.Begin:
                {
                    Gizmos.color = new Color(0f, 0f, 1f, 0.75F);
                    Gizmos.DrawSphere(transform.position, 0.3f);
                    



                }
                break;
            case Type.Cross:
                {
                    Gizmos.color = new Color(0f, 1f, 0f, 0.75F);
                    Gizmos.DrawCube(transform.position, Vector3.one * 0.6f);
                }
                break;
        }


        
    }
     
    private void OnDrawGizmosSelected()
    {
        /*var w2l = transform.worldToLocalMatrix;
        var l2w = transform.localToWorldMatrix;
        foreach (var c in connecteds)
        {
            if (null != c && c == ExpeditionRoadPoint.editingPath)
            {
                 
            }
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
