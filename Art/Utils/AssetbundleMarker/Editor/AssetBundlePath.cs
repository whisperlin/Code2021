using UnityEngine;
using UnityEditor;

public class AssetBundlePath : EditorWindow
{

 
    string path1="";
 
    [MenuItem("工具/Assetbundle/显示全路径 _F9", false, 351)]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        AssetBundlePath window = (AssetBundlePath)EditorWindow.GetWindow(typeof(AssetBundlePath));
        window.Show();
    }

    void OnGUI()
    {
        path1 = "";
        foreach (Object obj in Selection.objects)
        {
            path1 += AssetDatabase.GetAssetPath(obj)+"\n";
            
        }
 
        EditorGUILayout.TextArea(path1.ToLower(), GUILayout.Height(200));

         
    }
}
 