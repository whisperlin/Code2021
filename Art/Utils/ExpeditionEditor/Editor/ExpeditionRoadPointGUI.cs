using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[CustomEditor(typeof(ExpeditionRoadPoint))]
public class ExpeditionRoadPointGUI : Editor
{

    static void AddCtrlPoint(List<ExpeditioCtrlPoint> list,int index)
    {
        var _i0 = list[index - 1];
        var _i1 = list[index];
        Vector3 p = Vector3.Lerp(_i0.pos, _i1.pos, 0.5f);
        Vector3 f = ExpeditionRoadPoint.GetMidVector3H(_i0.forward, _i1.forward, 0.5f);
        list.Insert(index, new ExpeditioCtrlPoint(p,f));
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }

     

}
