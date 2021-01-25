#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;
using Newtonsoft.Json;

[CustomEditor(typeof(Grid)), CanEditMultipleObjects]

public class GridGUI : Editor
{

    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();
        base.OnInspectorGUI();
        Grid c = (Grid)target;
        c.Count = EditorGUILayout.IntField("格子数", c.Count);
#if ART_PROJECT
        if (c.editorItem)
        {
            GUI.color = Color.green;
            if (GUILayout.Button("编辑子项模式开启中..."))
            {
                c.editorItem = false;
            }
        }
        else
        {
            GUI.color = Color.grey;
            if (GUILayout.Button("开启编辑子项模式"))
            {
                c.editorItem = true;
            }
        }

#endif
        if (EditorGUI.EndChangeCheck())
        {
            c.Resize(c.Count);
        }






    }
}
#endif

 