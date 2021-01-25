#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;
using Newtonsoft.Json;

[CustomEditor(typeof(TextLanguageCtrl)), CanEditMultipleObjects]

public class TextLanguageCtrlGUI : Editor
{
 
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        TextLanguageCtrl c = (TextLanguageCtrl)target;
        /*if (GUILayout.Button("刷新"))
        {
            Language.Init("中文", null);
            c.SetDirty();
        }*/

#if ART_PROJECT
        
        c.tempStr = EditorGUILayout.TextField("中文", c.tempStr);
        if (GUILayout.Button("自动填入"))
        {
            if (c.tempStr == null||c.tempStr =="")
            {
                return;
            }
      
            if (Language.HasValue(c.tempStr,ref c.id))
            {
                c.SetDirty();

            }
            else
            {
                EditorUtility.DisplayDialog("添加字符", c.tempStr, "确定");
                int id = Language.AddToMap(c.tempStr);
                Language.SaveMap(@"Assets\Language\cn.txt");
                
                Language.Init("中文", null);
                c.id = id;
                c.SetDirty(); ;
                serializedObject.ApplyModifiedProperties();
            }

        }
#endif



    }
}
#endif
