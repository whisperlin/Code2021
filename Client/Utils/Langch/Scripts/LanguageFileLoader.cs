 


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageFileLoader : MonoBehaviour
{
 
    static LanguageFileLoader _loader;
    public static LanguageFileLoader Instance()
    {
        if(null == _loader)
        {
            GameObject g = new GameObject();
            g.hideFlags = HideFlags.HideAndDontSave;
            _loader = g.AddComponent<LanguageFileLoader>();
        }
        return _loader;
    }
    public delegate void loadTextCallBack(bool scuess, string txt);
    public void LoadTextCallBack( string path, loadTextCallBack fun)
    {
       
        StartCoroutine(__loadText( path, fun));
     
    }
    public LoadTextHandle LoadText(  string path )
    {
 
        LoadTextHandle handle = new LoadTextHandle();
        StartCoroutine(__loadText( path, handle));
        return handle;
    }

    IEnumerator __loadText(  string path, LoadTextHandle h)
    {
        string bundlePath = BundleMap.GetBundleName(path);

        string rq = "";
        /*AssetBundleAsync bundle = ManagerContainer.assetBundleManager.GetBundleAsync(bundleName);
        yield return bundle;

        if (bundle.AssetBundle != null)
        {
            AssetBundleRequest request = bundle.AssetBundle.LoadAssetAsync(path);
            yield return request;
            TextAsset t = (TextAsset)request.asset;
            if (null != t)
            {
                rq = t.text;
            }
        }
        ManagerContainer.assetBundleManager.UnloadBundle(bundle.AssetBundle);
        */

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
    IEnumerator __loadText(  string path, loadTextCallBack fun)
    {
 
        string rq = "";
        bool rs = false;
        string bundlePath = BundleMap.GetBundleName(path);
         

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
        if (null != fun)
            fun(rs, rq);
    }
}
