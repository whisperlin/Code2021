using UnityEngine;
using System.Collections;
using UnityEditor;

// Creates a custom Label on the inspector for all the scripts named ScriptName
// Make sure you have a ScriptName script in your
// project, else this will not work.
[CustomEditor(typeof(GridInformation))]
public class GridInformationGUI : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("重定义大小"))
        {
            GridInformation gi = (GridInformation)target;
            gi.Resize();
        }
        if (GUILayout.Button("更换模型"))
        {
            GridInformation gi = (GridInformation)target;
            gi.Resize();
        }

        if (GUILayout.Button("隐藏展示模型"))
        {
            GridInformation gi = (GridInformation)target;
            gi.HideAllChild();
        }

        if (GUILayout.Button("显示展示模型"))
        {
            GridInformation gi = (GridInformation)target;
            gi.ShowAllChild();
        }

        if (GUILayout.Button("显示战斗模型"))
        {
            GridInformation gi = (GridInformation)target;
            gi.ShowExampleType();
        }
    }
}

 