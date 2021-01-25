using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public sealed  class LEditorGUILayout 
{
    public static Vector2 TimeLine(Vector2 scrollPos,int width = 200,int height=100)
    {

        scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Width(width), GUILayout.Height(height));

        GUILayout.Space(50);
        
        GUILayout.Label("",GUILayout.Width(1000), GUILayout.Height(100));
        //EditorGUILayout.Space()
        //GUILayout.Label("asdfasdffffffffffffffffffffffffffffffffffffffffffffff");

        EditorGUILayout.EndScrollView();


        Rect scrollArea = GUILayoutUtility.GetLastRect();
        if ((Event.current.type == EventType.MouseDown) && (Event.current.button == 0) && scrollArea.Contains(Event.current.mousePosition))
        {
            Debug.LogError(Event.current.mousePosition);
        }

        return scrollPos;
    }
}
