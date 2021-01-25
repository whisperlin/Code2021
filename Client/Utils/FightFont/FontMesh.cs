using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class FontMesh : MonoBehaviour {

    public Transform cam;
    public MeshRenderer mr;
    public MeshFilter mf;
    Material mat;
    [Label("文字存在时间")]
    public float destoryTime = 2f;
    
    float curTime = 0f;
    //public MaterialPropertyBlock block;
    [Range(0f,1f)]
    public float alpha = 1f;
    [System.NonSerialized]
    public SimplePool<FontMesh> pools;
    public float curValue = 1;
    Mesh mesh;

    Color [] colors;
    public void ResetFont()
    {
        curTime = 0;
    }
    private void OnEnable()
    {
        curTime = 0f;
    }
    private void OnDestroy()
    {
        GameObject.Destroy(mesh);
    }
    // Use this for initialization
    void Start () {
        if (null == cam)
        {
            if (null != Camera.main)
            {
                cam = Camera.main.transform;
            }
            else
            {
                cam = GameObject.FindObjectOfType<Camera>().transform;
            }
            
        }
        
        mat = mr.sharedMaterial;
       
        if(null != mesh)
            mf.mesh = mesh; 
        
        curTime = 0f;
    }

   
     

    // Update is called once per frame
    void Update () {
        
 
        Color c = new Color(alpha, alpha, alpha, alpha);
#if UNITY_EDITOR
        if (null == mesh)
        {
            mesh = GetComponentInChildren<MeshFilter>().sharedMesh;
            colors = new Color[mesh.vertexCount];
        }
        
#endif
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = c;  
        }
        mesh.colors = colors;

        if(null != cam)
            transform.forward = -cam.forward;
#if UNITY_EDITOR
        if (!Application.isPlaying)
            return;
#endif
        curTime += Time.deltaTime;
        if (curTime > destoryTime)
        {
            if (pools == null)
            {
                GameObject.Destroy(gameObject);
            }
            else
            {
                curTime = 0f;
                gameObject.SetActive(false);
                pools.Release(this);
            }
        }
        
    }

    public  void SetValue(int value, Dictionary<int, FontItem> fonts)
    {
        curValue = value;
        if (null == mesh)
        {
            mesh = new Mesh();
            mesh.MarkDynamic();
        }
            
        buildFont(mesh, value, fonts,ref colors);
    }
    static List<int> temp = new List<int>();
    static void buildFont(Mesh m, int value, Dictionary<int, FontItem> fonts,ref Color[] colors)
    {
        float _width = 0f;
        float fontHeight = 65f;
        temp.Clear();
        int v;
        int w;
        while (value > 0)
        {
            w = value % 10;
            v = 48 + w;
            value = value / 10;
           
            FontItem f;
            if (fonts.TryGetValue(v, out f))
            {
                temp.Add(v);
                _width += f.width;
                fontHeight = f.height;
            }
            else
            {
                Debug.LogError("文件");
            }
            //var f = fonts[v];
           
        }
        m.Clear();
        _width = -_width * 0.5f;
        int c = temp.Count;
        Vector3[] vertices = new Vector3[c * 4];
        if(colors==null ||colors.Length != c*4)
            colors = new Color[c * 4];
        Vector2[] uv = new Vector2[c * 4];

        int[] triangles = new int[c * 6];
        float dw = 0.5f;
        for (int i = 0; i < c; i++)
        {
            v = temp[i];
            var f = fonts[v];
            dw = f.width * 0.5f;
            vertices[i * 4 + 0] = new Vector3(-dw + _width, 0f, 0f);
            vertices[i * 4 + 1] = new Vector3(dw + _width, 0f, 0f);
            vertices[i * 4 + 2] = new Vector3(-dw + _width, fontHeight, 0f);
            vertices[i * 4 + 3] = new Vector3(dw + _width, fontHeight, 0f);
 
            uv[i * 4 + 0] = new Vector2(1, 0);
            uv[i * 4 + 1] = new Vector2(0, 0);
            uv[i * 4 + 2] = new Vector2(1, 1);
            uv[i * 4 + 3] = new Vector2(0, 1);

            uv[i * 4 + 0] = new Vector2(f.uv1.x, 1f - f.uv1.y);
            uv[i * 4 + 1] = new Vector2(f.uv0.x, 1f - f.uv1.y);
            uv[i * 4 + 2] = new Vector2(f.uv1.x, 1f - f.uv0.y);
            uv[i * 4 + 3] = new Vector2(f.uv0.x, 1f - f.uv0.y);
             

            triangles[i * 6 + 0] = i * 4 + 0;
            triangles[i * 6 + 1] = i * 4 + 2;
            triangles[i * 6 + 2] = i * 4 + 1;
            triangles[i * 6 + 3] = i * 4 + 1;
            triangles[i * 6 + 4] = i * 4 + 2;
            triangles[i * 6 + 5] = i * 4 + 3;
            _width += f.width;
        }
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = Color.white;
        }
        m.vertices = vertices;
        m.colors = colors;
        m.uv = uv;
        m.triangles = triangles;
        m.RecalculateNormals();
    }
}
