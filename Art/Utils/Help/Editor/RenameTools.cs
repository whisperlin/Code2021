using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class RenameTools :EditorWindow
{
    string myString = "item{0}";

    [MenuItem("TA/工具/从预制上查找替换Stand _F4")]
    static void ReplayStanderd()
    {

        bool isFound = false;
        foreach (GameObject g in Selection.gameObjects)
        {
            string path = AssetDatabase.GetAssetPath(g);
            Renderer [] rs = g.GetComponentsInChildren<Renderer>();
            foreach (Renderer r in rs)
            {
                
                try
                {

                    if (null != r)
                    {
                        foreach (var m in r.sharedMaterials)
                        {
                            if (m.shader.name == "Standard")
                            {
                                Debug.LogError(r.gameObject.name);
                                isFound = true;
                            }
                            
                        }
                    }

                }
                catch (System.Exception e)
                {
                    Debug.LogError(e);
                }
            }
        }
        if (!isFound)
        {
            Debug.Log("没找到standard");
        }
    }
    // Add menu named "My Window" to the Window menu
    [MenuItem("工具/UI/批量重命名")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        RenameTools window = (RenameTools)EditorWindow.GetWindow(typeof(RenameTools));
        window.Show();
    }

    void OnGUI()
    {
        
        GUILayout.Label("必须同一父节点");
        myString = EditorGUILayout.TextField("Text Field", myString);
        if (GUILayout.Button("重命名"))
        {
            if (myString.Length > 0)
            {
                if (Selection.gameObjects.Length > 0)
                {
                    Transform parent = Selection.gameObjects[0].transform.parent;
                    List<GameObject> gs = new List<GameObject>();
                    for (int i = 0; i < parent.childCount; i++)
                    {
                        GameObject g1 = parent.GetChild(i).gameObject;
                        for (int j = 0; j < Selection.gameObjects.Length; j++)
                        {
                            GameObject g = Selection.gameObjects[j];
                            if (g == g1)
                            {
                                gs.Add(g1);
                            }
                        }
                    }

                    for (int i = 0; i < gs.Count; i++)
                    {
                        GameObject g = gs[i];
                        g.name = string.Format(myString, i);
                    }
                }
                
            }
        }
    }
}
