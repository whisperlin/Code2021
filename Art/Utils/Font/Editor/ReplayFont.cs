using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
public class ReplayFont : EditorWindow
{
    
    private Font fontFile;
    string path = "Assets/Art/UI";
    int fontSize = 36;
    Color broderColor = Color.gray;

    // Add menu named "My Window" to the Window menu
    [MenuItem("工具/文字/批量替换字体")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        ReplayFont window = (ReplayFont)EditorWindow.GetWindow(typeof(ReplayFont));
        window.Show();
    }

    void OnGUI()
    {
        fontFile = (Font)EditorGUILayout.ObjectField("bmFont文件", fontFile, typeof(Font), false);
        GUILayout.BeginHorizontal();
        path = GUILayout.TextField( path);
        if (GUILayout.Button(".."))
        {
            path = EditorUtility.OpenFolderPanel("打开UI文件夹", path, "Assets/Art/UI" );
        }
        GUILayout.EndHorizontal();
        if(GUILayout.Button("替换"))
        {
            string[] files =  System.IO.Directory.GetFiles(path, "*.prefab",System.IO.SearchOption.AllDirectories);
            foreach (string file in files)
            {
                GameObject obj = AssetDatabase.LoadAssetAtPath(file, typeof(GameObject)) as GameObject;
                Debug.Log("obj的名字" + obj.name);
                //Transform tra = obj.transform.FindChild("Label"); 
                Text[] texts = obj.transform.GetComponentsInChildren<Text>(true);
                foreach (Text t in texts)
                {
                    t.font = fontFile;
                }
                EditorUtility.SetDirty(obj);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
        }

        broderColor = EditorGUILayout.ColorField("描边色", broderColor);
        if (GUILayout.Button("批量添加修改字体阴影"))
        {
            string[] files = System.IO.Directory.GetFiles(path, "*.prefab", System.IO.SearchOption.AllDirectories);
            foreach (string file in files)
            {
                GameObject obj = AssetDatabase.LoadAssetAtPath(file, typeof(GameObject)) as GameObject;
                Debug.Log("obj的名字" + obj.name);
                //Transform tra = obj.transform.FindChild("Label"); 
                Text[] texts = obj.transform.GetComponentsInChildren<Text>(true);
                foreach (Text t in texts)
                {
                    Shadow sd = t.gameObject.GetComponent<Shadow>();
                    if (sd == null)
                        sd = t.gameObject.AddComponent<Shadow>();
                    sd.effectColor = broderColor;
                }
                EditorUtility.SetDirty(obj);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
        }
        if (GUILayout.Button("批量添加修改字体描边"))
        {
            string[] files = System.IO.Directory.GetFiles(path, "*.prefab", System.IO.SearchOption.AllDirectories);
            foreach (string file in files)
            {
                GameObject obj = AssetDatabase.LoadAssetAtPath(file, typeof(GameObject)) as GameObject;
                Debug.Log("obj的名字" + obj.name);
                //Transform tra = obj.transform.FindChild("Label"); 
                Text[] texts = obj.transform.GetComponentsInChildren<Text>(true);
                foreach (Text t in texts)
                {
                    Outline sd = t.gameObject.GetComponent<Outline>();
                    if (sd == null)
                        sd = t.gameObject.AddComponent<Outline>();
                    sd.effectColor = broderColor;
                }
                EditorUtility.SetDirty(obj);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
        }
        fontSize = EditorGUILayout.IntSlider("字体大小",fontSize,10,50);
        if (GUILayout.Button("批量修改字体大小"))
        {
            string[] files = System.IO.Directory.GetFiles(path, "*.prefab", System.IO.SearchOption.AllDirectories);
            foreach (string file in files)
            {
                GameObject obj = AssetDatabase.LoadAssetAtPath(file, typeof(GameObject)) as GameObject;
                Debug.Log("obj的名字" + obj.name);
                //Transform tra = obj.transform.FindChild("Label"); 
                Text[] texts = obj.transform.GetComponentsInChildren<Text>(true);
                foreach (Text t in texts)
                {
                    t.fontSize = fontSize;
                    t.verticalOverflow = VerticalWrapMode.Overflow;
                }
                EditorUtility.SetDirty(obj);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
        }
    }
}
 