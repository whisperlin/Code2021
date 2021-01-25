
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetBundleLoaderData
{
    
 
    public Dictionary<string, UnityEngine.Object> objects = new Dictionary<string, UnityEngine.Object>();
    
}
public class SceneObjectLoader : MonoBehaviour
{
    static  SceneObjectLoader  _instance = null;
    public float Progress { get => ( float)curCount/totalCount; }
 
    float totalCount = 0;
    int curCount = 0;
    
    public float getProcess()
    {
        return ((float)curCount) / totalCount;
    }
    public static SceneObjectLoader Instance()
    {
        if (null == _instance)
        {
            GameObject g = new GameObject("AssetBundleLoader");
            _instance = g.AddComponent<SceneObjectLoader>();
            GameObject.DontDestroyOnLoad(g);
        }
        return _instance;
    }
    //Dictionary<string, AssetBundleLoaderData> bundleNames = new Dictionary<string, AssetBundleLoaderData>();
    List<LAssetBundleHandle> loadingHandles = new List<LAssetBundleHandle>();
    public void AddBundle( string path)
    {
        string bundlePath = BundleMap.GetBundleName(path);

        if (null == bundlePath)
        {
            Debug.LogError("找不到bundleName "+path);
            bundlePath = "";
        }

        LAssetBundleHandle _handle = LAssetBundleManager.Instance().LoadAsset(path, bundlePath);
        totalCount++;
        loadingHandles.Add(_handle);
        
    }


    public bool IsFinish
    {
        get
        {
            totalCount = loadingHandles.Count;
            curCount = 0;
            for (int i = 0; i < loadingHandles.Count; i++)
            {
                var h = loadingHandles[i];
                if (h.state == AssetBundleState.FINISH)
                {
                    curCount++;
                }

            }
            return totalCount == curCount;
        }
    }

    public Dictionary<string, UnityEngine.Object> GetObjectsAndClear()
    {

 
        Dictionary<string, UnityEngine.Object> rt = new Dictionary<string, UnityEngine.Object>();
        for (int i = 0; i < loadingHandles.Count; i++)
        {
            var h = loadingHandles[i];
            if (h.state == AssetBundleState.FINISH)
            {
                string path = h.path;
                rt[path] = h.obj;
            }
        }
        
        
        curCount = 0;
        totalCount = 0;
        loadingHandles.Clear();
        return rt;
    }

    public void AddToGameObjectPools()
    {
        //压缩包内容放入容器池
        Dictionary<string, UnityEngine.Object> objs = GetObjectsAndClear();
        foreach (var kv in objs)
        {
            GameObjectPools.Instance().AddObject(kv.Key, kv.Value);

        }
    }
}
