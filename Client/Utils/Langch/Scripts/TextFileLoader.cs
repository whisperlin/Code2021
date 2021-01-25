#if ART_PROJECT
#define TABLE_NOT_IN_BUNDLE
#endif


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
    public LoadTextHandle LoadText(string path, bool onDisk = true)
    {
        LoadTextHandle handle = new LoadTextHandle();
        if (onDisk)
        {
            StartCoroutine(__loadText("", path, handle, true));
        }
        else
        {
            string bundleName = BundleMap.GetBundleName(path);
            StartCoroutine(__loadText(bundleName, path, handle, false));
        }
        
        return handle;
    }

    IEnumerator __loadText(string bundlePath, string path, LoadTextHandle h,bool onDisk)
    {

        if (onDisk)
        {
            string txt = System.IO.File.ReadAllText(Application.persistentDataPath + "/" + path);
            yield return null;
            h.isFinish = true;
            h.text = txt;
        }
        else
        {
            string rq = "";

            LAssetBundleHandle _handle = LAssetBundleManager.Instance().LoadAsset(path, bundlePath);
            while (_handle.state != AssetBundleState.FINISH)
                yield return null;
            if (!_handle.isFalse)
            {
                TextAsset t = (TextAsset)_handle.obj;
                if (null != t)
                {
                    rq = t.text;
                }
            }

            h.isFinish = true;
            h.text = rq;
        }
 


    }
    IEnumerator __loadText(string bundlePath, string path, loadTextCallBack fun)
    {
#if TABLE_NOT_IN_BUNDLE
        string txt = System.IO.File.ReadAllText(rootPath+path);
        yield return null;
        fun(true, txt);
#else
        string rq = "";
        bool rs = false;
        LAssetBundleHandle _handle = LAssetBundleManager.Instance().LoadAsset(path, bundlePath);
        while (_handle.state != AssetBundleState.FINISH)
            yield return null;
        if (!_handle.isFalse)
        {
            TextAsset t = (TextAsset)_handle.obj;
            if (null != t)
            {
                rq = t.text;
            }
        }
        fun(rs, rq);
#endif


    }
}
