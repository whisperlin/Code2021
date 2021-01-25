using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LanguageGUI : EditorWindow
{
    [MenuItem("工具/程序/多语言id设置")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        LanguageGUI window = (LanguageGUI)EditorWindow.GetWindow(typeof(LanguageGUI));
        window.Show();
    }

    void OnGUI()
    {
        try
        {
            Language.minId = int.Parse(System.IO.File.ReadAllText("languageId.ids"));
        }
        catch (System.Exception e)
        {
        }
        
        Language.minId = EditorGUILayout.IntField("多语言min id", Language.minId);
        System.IO.File.WriteAllText("languageId.ids",Language.minId.ToString()); 
        //Language.minId = 
    }
}
