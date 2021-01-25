 

using UnityEngine;
using UnityEditor;

public class GridToolWindow : EditorWindow
{

    Vector2Int size = new Vector2Int(5, 10);
    float cellWrite = 1;
    GameObject ck;
    // Add menu named "My Window" to the Window menu
    [MenuItem("工具/排版/格子排列工具")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        GridToolWindow window = (GridToolWindow)EditorWindow.GetWindow(typeof(GridToolWindow));
        window.Show();
    }

    void OnGUI()
    {
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);
        size = EditorGUILayout.Vector2IntField("格子大小：", size);
        cellWrite = EditorGUILayout.FloatField("格子宽度:", cellWrite);
        ck = (GameObject)EditorGUILayout.ObjectField("参考对象", ck, typeof(GameObject), false);

        if (GUILayout.Button("生成"))
        {
            GameObject g = new GameObject("root");

            GameObject cells = new GameObject("cells");
            cells.transform.parent = g.transform;
            GridInformation information = g.AddComponent<GridInformation>();
            information.cellWidth = cellWrite;
            information.size = size;
            information.cloneGamObject = ck;
            information.Resize();

        }
    }

}
 
