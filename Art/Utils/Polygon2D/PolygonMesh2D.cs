using UnityEngine;
using System.Linq;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif
 
[RequireComponent(typeof(MeshCollider))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
/// <summary>
/// Builds a Mesh for a gameObject using the PolygonCollider2D's path</summary>
public class PolygonMesh2D : MonoBehaviour
{

#if UNITY_EDITOR
    [System.NonSerialized]
    public bool editring = false;
    public int lastSelectLine = -1;
    public static bool showAllMesh = false;
#endif
    public MeshFilter meshFilter;
    public MeshRenderer meshRenderer;
    public MeshCollider meshCollider = null;
    public Vector2[] path = new Vector2[] { new Vector2(-1, -1),new Vector2(-1, 1f),new Vector2(1,1),new Vector2(1, -1) };


    public void FillData()
    {
        if(null == meshCollider)
            meshCollider = GetComponent<MeshCollider>();
        if (null == meshFilter)
            meshFilter = GetComponent<MeshFilter>();
        if (null == meshRenderer)
        {
            meshRenderer = GetComponent<MeshRenderer>();
            meshRenderer.receiveShadows = false;
            meshRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        }
            
         
        meshFilter.sharedMesh = meshCollider.sharedMesh = Triangulator.BuildMesh(path);
        if (Application.isPlaying)
        {
            meshRenderer.enabled = false;

        }
    }
    private void Start()
    {
        FillData();
    }
#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        if (PolygonMesh2D.showAllMesh && !editring)
        {
 
            Vector3[] wps = new Vector3[ path.Length + 1];
            for (int i = 0; i <  path.Length; i++)
            {
                var _p =  path[i];
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
                Handles.color = Color.gray;
                Handles.DrawLine(wps[i - 1], wps[i]);

            }
        }
    }
#endif


}

public class Triangulator
{

    ///<summary>
    ///(Re)builds the Mesh using the path of the PolygonCollider2D</summary>
    public static Mesh BuildMesh(Vector2[] path)
    {
 
        Mesh msh = new Mesh();
        msh.vertices = path.Select(v => new Vector3(v.x, 0, v.y)).ToArray();
        msh.triangles = new Triangulator(path).Triangulate();
        msh.RecalculateNormals();
        msh.RecalculateBounds();
 

        //recalculate UV
        Bounds bounds = msh.bounds;

        msh.uv = path.Select(v => new Vector2(v.x / bounds.size.x, v.y / bounds.size.y)).ToArray();
        return msh;
    }
    private List<Vector2> mPoints = new List<Vector2>();

    public Triangulator(Vector2[] points)
    {
        mPoints = new List<Vector2>(points);
    }

    public int[] Triangulate()
    {
        List<int> indices = new List<int>();

        int n = mPoints.Count;
        if (n < 3) return indices.ToArray();

        int[] V = new int[n];
        if (Area() > 0)
        {
            for (int v = 0; v < n; v++)
                V[v] = v;
        }
        else
        {
            for (int v = 0; v < n; v++)
                V[v] = (n - 1) - v;
        }

        int nv = n;
        int count = 2 * nv;
        for (int m = 0, v = nv - 1; nv > 2;)
        {
            if ((count--) <= 0)
                return indices.ToArray();

            int u = v;
            if (nv <= u)
                u = 0;
            v = u + 1;
            if (nv <= v)
                v = 0;
            int w = v + 1;
            if (nv <= w)
                w = 0;

            if (Snip(u, v, w, nv, V))
            {
                int a, b, c, s, t;
                a = V[u];
                b = V[v];
                c = V[w];
                indices.Add(a);
                indices.Add(b);
                indices.Add(c);
                m++;
                for (s = v, t = v + 1; t < nv; s++, t++)
                    V[s] = V[t];
                nv--;
                count = 2 * nv;
            }
        }

        indices.Reverse();
        return indices.ToArray();
    }

    private float Area()
    {
        int n = mPoints.Count;
        float A = 0.0f;
        for (int p = n - 1, q = 0; q < n; p = q++)
        {
            Vector2 pval = mPoints[p];
            Vector2 qval = mPoints[q];
            A += pval.x * qval.y - qval.x * pval.y;
        }
        return (A * 0.5f);
    }

    private bool Snip(int u, int v, int w, int n, int[] V)
    {
        int p;
        Vector2 A = mPoints[V[u]];
        Vector2 B = mPoints[V[v]];
        Vector2 C = mPoints[V[w]];
        if (Mathf.Epsilon > (((B.x - A.x) * (C.y - A.y)) - ((B.y - A.y) * (C.x - A.x))))
            return false;
        for (p = 0; p < n; p++)
        {
            if ((p == u) || (p == v) || (p == w))
                continue;
            Vector2 P = mPoints[V[p]];
            if (InsideTriangle(A, B, C, P))
                return false;
        }
        return true;
    }

    private bool InsideTriangle(Vector2 A, Vector2 B, Vector2 C, Vector2 P)
    {
        float ax, ay, bx, by, cx, cy, apx, apy, bpx, bpy, cpx, cpy;
        float cCROSSap, bCROSScp, aCROSSbp;

        ax = C.x - B.x; ay = C.y - B.y;
        bx = A.x - C.x; by = A.y - C.y;
        cx = B.x - A.x; cy = B.y - A.y;
        apx = P.x - A.x; apy = P.y - A.y;
        bpx = P.x - B.x; bpy = P.y - B.y;
        cpx = P.x - C.x; cpy = P.y - C.y;

        aCROSSbp = ax * bpy - ay * bpx;
        cCROSSap = cx * apy - cy * apx;
        bCROSScp = bx * cpy - by * cpx;

        return ((aCROSSbp >= 0.0f) && (bCROSScp >= 0.0f) && (cCROSSap >= 0.0f));
    }
}
 