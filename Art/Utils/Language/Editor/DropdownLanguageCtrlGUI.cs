#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;
using Newtonsoft.Json;

[CustomEditor(typeof(DropdownLanguageCtrl)), CanEditMultipleObjects]

public class DropdownLanguageCtrlGUI : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        DropdownLanguageCtrl c = (DropdownLanguageCtrl)target;
        if (GUILayout.Button("刷新"))
        {
            Language.Init("中文", null);
            c.SetDirty();
        }

#if ART_PROJECT

        c.tempStr = EditorGUILayout.TextField("中文", c.tempStr);
        if (GUILayout.Button("自动填入"))
        {
            Language.Init("中文", null);
            if (c.tempStr == null || c.tempStr == "")
            {
                return;
            }

            for (int i = 0; i < c.ids.Length; i++)
            {
                if (Language.GetValue(c.ids[i]) == c.tempStr)
                {
                    c.SetDirty();
                    return;
                }
            }
            int newId = 0;
            if (Language.HasValue(c.tempStr, ref newId))
            {
                List<int> ls = new List<int>();
                foreach (var _id in c.ids)
                {
                    ls.Add(_id);
                }
                ls.Add(newId);
                c.ids = ls.ToArray();
                c.SetDirty();

            }
            else
            {
                EditorUtility.DisplayDialog("添加字符", c.tempStr, "确定");
                int id = Language.AddToMap(c.tempStr);
                Language.SaveMap(@"Assets\Language\cn.txt");
                Language.Init("中文", null);
                List<int> ls = new List<int>();
                foreach (var _id in c.ids)
                {
                    ls.Add(_id);
                }
                ls.Add(id);
                c.ids = ls.ToArray();
                c.SetDirty();
            }

        }
#endif
    }



}
#endif