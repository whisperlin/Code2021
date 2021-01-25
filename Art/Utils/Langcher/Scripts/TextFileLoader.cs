#if ART_PROJECT
#define TABLE_NOT_IN_BUNDLE
#endif

using AssetBundles;
using System.Collections;
using System.Collections.Generic;
#if TABLE_NOT_IN_BUNDLE
using System.IO;
#endif

using UnityEngine;

public class LoadTextHandle
{
    public bool isFinish = false;
    public string text;
}
public class TextFileLoader : MonoBehaviour
{

#if ART_PROJECT
    
    const string rootPath = "";
 
#else
    #if TABLE_NOT_IN_BUNDLE
        const string rootPath = "TempText/";
    #endif
#endif

    static TextFileLoader _loader;
    public static TextFileLoader Instance()
    {
        if(null == _loader)
        {
            GameObject g = new GameObject();
            g.hideFlags = HideFlags.HideAndDontSave;
            _loader = g.AddComponent<TextFileLoader>();
        }
        return _loader;
    }
    public delegate void loadTextCallBack(bool scuess, string txt);
    public void LoadText(string bundleName, string path, loadTextCallBack fun)
    {
        StartCoroutine(__loadText(bundleName, path, fun));
     
    }
    public LoadTextHandle LoadText(string bundleName, string path )
    {
        LoadTextHandle handle = new LoadTextHandle();
        StartCoroutine(__loadText(bundleName, path, handle));
        return handle;
    }

    IEnumerator __loadText(string bundleName, string path, LoadTextHandle h)
    {
#if TABLE_NOT_IN_BUNDLE
        string txt = System.IO.File.ReadAllText(rootPath + path);
        yield return null;
        h.isFinish = true;
        h.text = txt;
#else
        string rq = "";
        AssetBundleAsync bundle = ManagerContainer.assetBundleManager.GetBundleAsync(bundleName);
        yield return bundle;

        if (bundle.AssetBundle != null)
        {
            AssetBundleRequest request = bundle.AssetBundle.LoadAssetAsync(path);
            yield return request;
            TextAsset t = (TextAsset)request.asset;
            if (null != t)
            {
                rq = t.text;
                rs = true;
            }
        }
        ManagerContainer.assetBundleManager.UnloadBundle(bundle.AssetBundle);
        h.isFinish = true;
        h.text = rq;
   
#endif


    }
    IEnumerator __loadText(string bundleName, string path, loadTextCallBack fun)
    {
#if TABLE_NOT_IN_BUNDLE
        string txt = System.IO.File.ReadAllText(rootPath+path);
        yield return null;
        fun(true, txt);
#else
        string rq = "";
        bool rs = false;
        AssetBundleAsync bundle = ManagerContainer.assetBundleManager.GetBundleAsync(bundleName);
        yield return bundle;

        if (bundle.AssetBundle != null)
        {
            AssetBundleRequest request = bundle.AssetBundle.LoadAssetAsync(path);
            yield return request;
            TextAsset t = (TextAsset)request.asset;
            if (null != t)
            {
                rq = t.text;
                rs = true;
            }
        }
        ManagerContainer.assetBundleManager.UnloadBundle(bundle.AssetBundle);
        fun(rs, rq);
#endif


    }
}
