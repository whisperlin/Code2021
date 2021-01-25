using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;



 
[CustomEditor(typeof(SceneGridInformation))]
public class SceneGridInformationGUI : Editor
{
    public override void OnInspectorGUI()
    {
        SceneGridInformation gi = (SceneGridInformation)target;
        GUILayout.Label("场景格子");
        base.OnInspectorGUI();
        
        if (GUILayout.Button("重定义大小"))
        {
            gi.Resize();
        }

        if (GUILayout.Button("隐藏展示模型"))
        {
            gi.HideAllChild();
        }

        if (GUILayout.Button("显示展示模型"))
        {
            gi.ShowAllChild();
        }

        
    }
}
#endif

