using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class ReplayMat 
{

    [MenuItem("TA/工具/批量去掉Standard")]
    static void Start()
    {
        string[]  files = System.IO.Directory.GetFiles("Assets", "*.mat", System.IO.SearchOption.AllDirectories);
        Shader newShader = Shader.Find(@"Mobile/Diffuse");
        foreach (string f in files)
        {
            Material mat = AssetDatabase.LoadAssetAtPath<Material>(f);
            if (mat.shader == null || mat.shader.name.Contains("Error")|| mat.shader.name.Contains("Standard"))
            {
                mat.shader = newShader;
                AssetDatabase.SaveAssets();
            }
            
        }
        Debug.LogError(files[0]);
    }
     
}
