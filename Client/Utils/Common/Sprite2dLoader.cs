
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite2dLoaderData
{

     
    public Dictionary<string, Sprite[]> objects = new Dictionary<string, Sprite[]>();
    internal string bundlePath;
    public List<LAssetBundleHandle> handles = new List<LAssetBundleHandle>();
 
}
public class Sprite2dLoader : MonoBehaviour
{
    static Sprite2dLoader _instance = null;
    public float Progress { get => (float)curCount / totalCount; }

    int totalCount = 0;
    int curCount = 0;
    public bool IsFinish
    {
        get => totalCount == curCount;
    }
    public float getProcess()
    {
        return ((float)curCount) / totalCount;
    }
    public static Sprite2dLoader Instance()
    {
        if (null == _instance)
        {
            GameObject g = new GameObject("AssetBundleLoader");
            _instance = g.AddComponent<Sprite2dLoader>();
            GameObject.DontDestroyOnLoad(g);
        }
        return _instance;
    }
    Dictionary<string, Sprite2dLoaderData> bundleNames = new Dictionary<string, Sprite2dLoaderData>();

    public void AddBundle(string path)
    {
        string bundlePath = BundleMap.GetBundleName(path);

        if (null == bundlePath)
        {
            Debug.LogError("找不到bundleName " + path);
            bundlePath = "";
        }

        Sprite2dLoaderData data;
        if (!bundleNames.TryGetValue(bundlePath, out data))
        {
            data = new Sprite2dLoaderData();
            data.bundlePath = bundlePath;
            bundleNames[bundlePath] = data;
        }
        if (!data.objects.ContainsKey(path))
        {
            data.objects[path] = null;
            totalCount++;
        }
 
    }
    public void StartLoad()
    {
        StartCoroutine(StartLoadCoroutine());
    }

    public IEnumerator StartLoadCoroutine()
    {
        curCount = 0;
        foreach (string bundleName in bundleNames.Keys)
        {
            Sprite2dLoaderData _data = bundleNames[bundleName];

            //handles
            foreach (var kv in _data.objects)
            {
                _data.handles.Add( LAssetBundleManager.Instance().LoadSprite(kv.Key, _data.bundlePath));
            }
            

           

        }
        foreach (string bundleName in bundleNames.Keys)
        {
            Sprite2dLoaderData _data = bundleNames[bundleName];
            foreach (var handle in _data.handles)
            {
                while (handle.state != AssetBundleState.FINISH)
                {
                    yield return null;
                }
            }
        }
        foreach (string bundleName in bundleNames.Keys)
        {
            Sprite2dLoaderData _data = bundleNames[bundleName];
            foreach (var handle in _data.handles)
            {
                if (null != handle.sprites)
                {
                    _data.objects[handle.path] = handle.sprites;

                }
                else
                {
                    _data.objects[handle.path] = new Sprite[0] ;
                    Debug.LogError("load false");
                }
                 
            }
            
        }
        curCount = totalCount;



    }

    public Dictionary<string, Sprite[]> GetObjectsAndClear()
    {
        Dictionary<string, Sprite[]> rt = new Dictionary<string, Sprite[]>();
        foreach (var _data in bundleNames.Values)
        {
            foreach (var kv2 in _data.objects)
            {
                
                string path = kv2.Key;
                int id0 = path.LastIndexOf('/');
                if (id0 > -1)
                    path = path.Substring(id0+1);
                int id2 = path.LastIndexOf('.');
                if (id2 > -1)
                    path = path.Substring(0, id2);
                rt[path] = kv2.Value;
            }
        }
        curCount = 0;
        totalCount = 0;
        bundleNames.Clear();
        return rt;
    }





}

 