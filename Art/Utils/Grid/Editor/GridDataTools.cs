using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class GridDataTools : EditorWindow
{
    
    Vector2Int size = new Vector2Int(5, 10);
    bool drawing = false;
    
    

    //[MenuItem("工具/排版/场景格子排列工具")]
    public static void Init()
    {
        // Get existing open window or if none, make a new one:
        GridDataTools window = (GridDataTools)EditorWindow.GetWindow(typeof(GridDataTools));
        window.Show();
    }
     
    void OnGUI()
    {

        if (Selection.activeGameObject.GetComponent<GridData>() == null)
        {
            GridData grid = GameObject.FindObjectOfType<GridData>();
            if (grid == null)
            {
                if (GUILayout.Button("创建"))
                {
                    GameObject g = new GameObject("GridData");
                    g.AddComponent<GridData>();
                }
                 
            }
            else
            {
                if (GUILayout.Button("选择"))
                {
                    Selection.activeGameObject = grid.gameObject;
                }
            }
            
        }
        else
        {
            OnEditorGUI();
        }
        
    }

    static void TopView()
    {
        SceneView.lastActiveSceneView.rotation = Quaternion.Euler(90f, 0f, 0f);
        SceneView.lastActiveSceneView.orthographic = true; // or false
    }
    void OnEditorGUI()
    {
        /*float y = SceneView.lastActiveSceneView.camera.transform.position.y - 0.5f;
        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.red;
        Handles.Label(new Vector3(0, y, 0), "Text", style);
        Handles.color = Color.green;
        Handles.DrawLine(new Vector3(0, y, 0), new Vector3(10f, y, 0));*/
        if (drawing)
        {
            GUI.backgroundColor = Color.green;
            if (GUILayout.Button("刷格子中..."))
            {
 
                drawing = false;
            }
        }
        else
        {
            GUI.backgroundColor = Color.grey;
            if (GUILayout.Button("关闭中"))
            {
                drawing = true;
            }
        }
         
    }
    private void OnSceneGUI(SceneView sceneView)
    {
        GridData data = Selection.activeGameObject.GetComponent<GridData>();
        if (data != null)
        {
            TopView();
            float y = SceneView.lastActiveSceneView.camera.transform.position.y - 0.5f;
            GUIStyle style = new GUIStyle();
            style.normal.textColor = Color.red;
            Handles.Label(new Vector3(0, y, 0), "Text", style);
            Handles.color = Color.green;
            Handles.DrawLine(new Vector3(0, y, 0), new Vector3(10f, y, 0));

            float orthographicSize = SceneView.lastActiveSceneView.camera.orthographicSize;
            float width = SceneView.lastActiveSceneView.camera.pixelWidth;
            float height = SceneView.lastActiveSceneView.camera.pixelHeight;
            if (width > height)
            {
                height = orthographicSize;
                width = orthographicSize * width / height;
            }
            else
            {
                width = orthographicSize;
                height = orthographicSize * height / width;
            }
            //Vector3 p1 = SceneView.lastActiveSceneView.camera.ScreenToViewportPoint(Vector3.zero);
            //Vector3 p2 = SceneView.lastActiveSceneView.camera.ScreenToViewportPoint(new Vector3(Screen.width,Screen.height));

            //Handles.DrawLine(p1+ Vector3.down, p2+ Vector3.down);


        }
        //TopView();

         
    }
    void OnFocus()
    {
#if UNITY_2019_1_OR_NEWER
        SceneView.duringSceneGui -= OnSceneGUI;
        SceneView.duringSceneGui += OnSceneGUI;
#else
        SceneView.onSceneGUIDelegate -= OnSceneGUI;
        SceneView.onSceneGUIDelegate += OnSceneGUI;
#endif
        Repaint();
    }
    void OnDestroy()
    {
#if UNITY_2019_1_OR_NEWER
        SceneView.duringSceneGui -= OnSceneGUI;
#else
        SceneView.onSceneGUIDelegate -= OnSceneGUI;
#endif

    }
    
}