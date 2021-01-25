using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BeginScrollViewExample : EditorWindow
{
    Vector2 scrollPos;
 

    [MenuItem("TA/Timeline")]
    static void Init()
    {
        BeginScrollViewExample window = (BeginScrollViewExample)EditorWindow.GetWindow(typeof(BeginScrollViewExample), true, "My Empty Window");
        window.Show();
    }

    void OnGUI()
    {

   
        scrollPos = LEditorGUILayout.TimeLine(scrollPos,200,100);
       
         
        if (GUILayout.Button("Add More Text", GUILayout.Width(100), GUILayout.Height(30)))
        {
 
            scrollPos.x += 10f;
        }
        //EditorGUILayout.EndHorizontal();

        
 
    }
}