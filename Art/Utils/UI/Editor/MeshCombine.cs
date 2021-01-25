
#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MeshCombine 
{
    [MenuItem("工具/网格/网格合并")]
    public static void meshCombine()
    {
        GameObject [] gs = Selection.gameObjects;
        if (gs.Length == 1)
        {
            GameObject g = gs[0];
            MeshRenderer[] meshRenderers = g.GetComponentsInChildren<MeshRenderer>();
            MeshFilter[] meshFilters = g.GetComponentsInChildren<MeshFilter>();
            CombineInstance[] combines = new CombineInstance[meshRenderers.Length];
            for (int i = 0; i < meshFilters.Length; i++)
            {
                combines[i].mesh = meshFilters[i].sharedMesh;
                combines[i].transform = meshFilters[i].transform.localToWorldMatrix;
            }
            Mesh mesh = new Mesh();
            mesh.CombineMeshes(combines, true);
            string path = EditorUtility.SaveFilePanelInProject("网格", "mesh", "mesh", "输入保存路径");
            if (path.Length > 0)
            {
                AssetDatabase.CreateAsset(mesh, path);
                AssetDatabase.ImportAsset(path);
            }
        }
    }
}
#endif