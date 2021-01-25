#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

[CustomEditor(typeof(PolygonMesh2D)), CanEditMultipleObjects]
public class PolygonMesh2DEditor : Editor
{
    
    protected virtual void OnSceneGUI()
    {

        PolygonMesh2D o = (PolygonMesh2D)target;

        if (null == o.meshFilter)
        {
            o.FillData();
 

        }
       
        if (null == o.meshRenderer.sharedMaterial)
        {
            o.meshRenderer.sharedMaterial = AssetDatabase.LoadAssetAtPath<Material>("Assets\\Common\\Polygon2D.mat");
            //o.meshRenderer.sharedMaterial = new Material(Shader.Find("Unlit/PolygonEditor"));
        }
        if (o.editring)
        {
            Tools.current = Tool.None;
            o.meshCollider = o.gameObject.GetComponent<MeshCollider>();


            var transform = o.transform;

            if (o.path.Length > 0)
            {
                EditorGUI.BeginChangeCheck();

                for (int i = 0; i < o.path.Length; i++)
                {

                    int controlID = GUIUtility.GetControlID(FocusType.Passive);

                    var _p = o.path[i];
                    Vector3 p = transform.localToWorldMatrix.MultiplyPoint(new Vector3(_p.x, 0f, _p.y));

                    p = Handles.PositionHandle(p, Quaternion.identity);
                    p = transform.worldToLocalMatrix.MultiplyPoint(p);
                    var _type = Event.current.GetTypeForControl(controlID);
                    o.path[i] = new Vector2(p.x, p.z);



                }

                if (EditorGUI.EndChangeCheck())
                {
                    o.meshCollider.sharedMesh = Triangulator.BuildMesh(o.path);
                    o.meshFilter.mesh = Triangulator.BuildMesh(o.path);
                }
                else
                {
                    Vector3[] wps = new Vector3[o.path.Length + 1];
                    for (int i = 0; i < o.path.Length; i++)
                    {
                        var _p = o.path[i];
                        wps[i] = transform.localToWorldMatrix.MultiplyPoint(new Vector3(_p.x, 0f, _p.y));
                    }
                    wps[wps.Length - 1] = wps[0];
                    float ds = float.MaxValue;

                    int pickIndex = -1;
                    for (int i = 1; i < wps.Length; i++)
                    {

                        float d = HandleUtility.DistanceToLine(wps[i - 1], wps[i]);


                        if (d < 10f && d < ds)
                        {
                            pickIndex = i;
                            ds = d;
                        }

                    }
                    for (int i = 1; i < wps.Length; i++)
                    {
                        if (pickIndex == i)
                        {
                            Handles.color = Color.white;
                        }
                        else if (o.lastSelectLine == i)
                        {
                            Handles.color = Color.white;

                        }
                        else
                        {
                            Handles.color = Color.gray;
                        }
                        Handles.DrawLine(wps[i - 1], wps[i]);

                    }


                    if (Event.current.type == EventType.MouseDown)
                    {
                        o.lastSelectLine = pickIndex;


                    }
                }
            }

        }
         
        else
        {
            if (Tools.current == Tool.None)
            {
                Tools.current = Tool.Move;
            }
        }
         
        

    }
    private void OnDisable()
    {
        PolygonMesh2D o = (PolygonMesh2D)target;
        //o.editring = false;
        if (o.editring)
        {
            Selection.activeGameObject = o.gameObject;
        }
        
        serializedObject.ApplyModifiedProperties();
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        serializedObject.UpdateIfRequiredOrScript();
        PolygonMesh2D o = (PolygonMesh2D)target;
        Color baseColor = GUI.color;
        if (o.editring)
        {
            if (o.lastSelectLine > -1)
            {
                if (GUILayout.Button("添加顶点"))
                {
                    List<Vector2> paths = new List<Vector2>();
                    foreach (Vector2 p in o.path)
                    {
                        paths.Add(p);
                    }
                    if (o.lastSelectLine == o.path.Length)
                    {
                        paths.Add((o.path[o.lastSelectLine - 1] + o.path[0]) * 0.5f);
                    }
                    else
                    {
                        paths.Insert(o.lastSelectLine, (o.path[o.lastSelectLine - 1] + o.path[o.lastSelectLine]) * 0.5f);
                    }


                    o.path = paths.ToArray();
                    o.lastSelectLine = -1;
                }
                if (GUILayout.Button("删除顶点"))
                {
                    List<Vector2> paths = new List<Vector2>();
                    foreach (Vector2 p in o.path)
                    {
                        paths.Add(p);
                    }
                    if (o.lastSelectLine == o.path.Length)
                    {
                        paths.RemoveAt(0);
                    }
                    else
                    {
                        paths.RemoveAt(o.lastSelectLine);

                    }


                    o.path = paths.ToArray();
                    o.lastSelectLine = -1;
                    
                }
            }
            GUI.color = Color.green;
            if (GUILayout.Button("退出编辑"))
            {
                o.editring = !o.editring;

            }
            GUI.color = baseColor;
        }
        else
        {

            if (null == o.meshCollider.sharedMesh)
            {
                o.FillData();
            }
            GUI.color = Color.red;
            if (GUILayout.Button("编辑顶点"))
            {
                o.editring = !o.editring;
            }
            GUI.color = baseColor;
        }
        if (PolygonMesh2D.showAllMesh)
        {
            if (GUILayout.Button("关闭其他网格显示"))
            {
                PolygonMesh2D.showAllMesh = false;
            }
        }
        else
        {
            if (GUILayout.Button("开启其他网格显示"))
            {
                PolygonMesh2D.showAllMesh = true;
            }
        }
        o.meshCollider.sharedMesh = Triangulator.BuildMesh(o.path);
        o.meshFilter.mesh = Triangulator.BuildMesh(o.path);
        
        serializedObject.ApplyModifiedProperties();

    }
}

#endif
