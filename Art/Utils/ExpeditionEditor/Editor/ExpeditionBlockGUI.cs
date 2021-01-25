using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[CustomEditor(typeof(ExpeditionRoadPoint))]
public class ExpeditionBlockGUI : Editor
{
    [MenuItem("工具/美术/场景检查")]
    static void Menu()
    {
        Dictionary<int,string> blockIds = new Dictionary<int, string>();
        ExpeditionBlock[] blocks = GameObject.FindObjectsOfType<ExpeditionBlock>();
        foreach (var b in blocks)
        {
            if (blockIds.ContainsKey(b.id))
            {
                EditorUtility.DisplayDialog("区域id重复", "区域id重复 [" +b.id.ToString()+"] "+ b.gameObject.name + " <=> " + blockIds[b.id],"确定");
            }
            blockIds.Add(b.id,b.gameObject.name);
        }
    }

     
}
