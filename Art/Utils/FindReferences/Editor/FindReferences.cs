using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class FindReferences
{

    [MenuItem("TA/工具/按文件夹查找引用")]
    static private void Find()
    {

        Dictionary<string, string> relactions = new Dictionary<string, string>();
        string path0 = EditorUtility.OpenFolderPanel("Select Fole", "", "");
        if (path0.Length == 0)
            return;
        path0 = @"Assets" + path0.Substring(Application.dataPath.Length);
        List<string> withoutExtensions0 = new List<string>() { ".prefab", ".unity", ".mat", ".asset",".png",".tga" };
        List<string> withoutExtensions = new List<string>() { ".prefab", ".unity", ".mat", ".asset" };
        string[] fs = Directory.GetFiles(path0, "*.*", SearchOption.AllDirectories).Where(s => withoutExtensions0.Contains(Path.GetExtension(s).ToLower())).ToArray();
        for (int n = 0; n < fs.Length; n++)
        {
            string path = fs[n];
            string guid = AssetDatabase.AssetPathToGUID(path);

            EditorUtility.DisplayProgressBar(
                    "查找引用",
                    path,
                    (float)n / fs.Length);


            
            string[] files = Directory.GetFiles(Application.dataPath, "*.*", SearchOption.AllDirectories)
                .Where(s => withoutExtensions.Contains(Path.GetExtension(s).ToLower())).ToArray();
            for (int i = 0; i < files.Length; i++)
            {
                string file = files[i];
                if (relactions.ContainsKey(file))
                    continue;
                if (File.ReadAllText(file).IndexOf(guid) > 0)
                {

                    relactions[file] = path0;
                }
            }

        }

        foreach (var file in relactions)
        {
            Debug.Log(file.Key + " 引用 " + file.Value);
        }
        Debug.Log("匹配结束");
        EditorUtility.ClearProgressBar();
    }

    [MenuItem("TA/工具/单个查找引用")]
    static private void Find0()
    {
        Dictionary<string, string> relactions = new Dictionary<string, string>();
        float c = 0;
        foreach (GameObject g in Selection.gameObjects)
        {

            string path = AssetDatabase.GetAssetPath(g);
            string guid = AssetDatabase.AssetPathToGUID(path);

            EditorUtility.DisplayProgressBar(
                    "查找引用",
                    path,
                    (float)c / Selection.gameObjects.Length);
            c++;

            List<string> withoutExtensions = new List<string>() { ".prefab", ".unity", ".mat", ".asset" };
            string[] files = Directory.GetFiles(Application.dataPath, "*.*", SearchOption.AllDirectories)
                .Where(s => withoutExtensions.Contains(Path.GetExtension(s).ToLower())).ToArray();
            for (int i = 0; i < files.Length; i++)
            {
                string file = files[i];
                if (relactions.ContainsKey(file))
                    continue;
                if (File.ReadAllText(file).IndexOf(guid) > 0)
                {

                    relactions[file] = path;
                }
            }
        }
        foreach (var file in relactions)
        {
            Debug.Log(file.Key + " 引用 " + file.Value);
        }
        Debug.Log("匹配结束");
        EditorUtility.ClearProgressBar();

    }

    /*[MenuItem("TA/工具/查找引用", true)]
    static private bool VFind()
    {

        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        return (!string.IsNullOrEmpty(path));
    }*/

    static private string GetRelativeAssetsPath(string path)
    {
        return "Assets" + Path.GetFullPath(path).Replace(Path.GetFullPath(Application.dataPath), "").Replace('\\', '/');
    }
}