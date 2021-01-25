using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum AssetBundleState
{

    LOADING_DEPENDS,
    LOADING_OBJ,
    FINISH,
    LOADING_SCENE,
    LOADING_SPRITE2d,
}
public enum AssetBundleType
{
    OBJ,
    SCENE,
    SPRITE2D,
}
public class LAssetBundleHandle
{
    public AssetBundleState state = AssetBundleState.LOADING_DEPENDS;
    public UnityEngine.Object obj;
    public Sprite[] sprites = null;
    public List<LAssetBundle> dps = new List<LAssetBundle>();
    public LAssetBundle mainBundle;
    public string path;
    private AssetBundleRequest assetLoadRequest = null;
    public bool isFalse = false;
    //public bool isScene = false;
    internal AssetBundleType handleType = AssetBundleType.OBJ;
    private AsyncOperation sceneAsync = null;
    public bool isDependsFinish()
    {
        foreach (var b in dps)
        {
            if (!b.isFinish())
                return false;
        }
        return true;
    }
    public void LoadingObject()
    {
        if (null == mainBundle.handler.assetBundle)
        {
            isFalse = true;
            state = AssetBundleState.FINISH;
            ReleaseAssetbunle();
            Debug.LogError("assetbundle 加载失败" + path);
        }
        else
        {
            assetLoadRequest = mainBundle.handler.assetBundle.LoadAssetAsync(path);
        }

    }
    public bool isObjectFinish()
    {
        return (assetLoadRequest != null && assetLoadRequest.isDone);
    }
    public bool isSceneFinish()
    {
        return (sceneAsync != null && sceneAsync.progress >= 1f);
    }
    public void FillObjAndReleaseAssetbunle()
    {
        if (null != assetLoadRequest)
        {
            obj = assetLoadRequest.asset;
            isFalse = obj == null;
            ReleaseAssetbunle();
        }

    }

    public void loadingScene()
    {

        if (null == mainBundle.handler.assetBundle)
        {
            isFalse = true;
            state = AssetBundleState.FINISH;
            ReleaseAssetbunle();
            Debug.LogError("场景 加载失败" + path);
        }
        else
        {
            //assetLoadRequest = mainBundle.handler.assetBundle.LoadAssetAsync(path);
            sceneAsync = SceneManager.LoadSceneAsync(path);//不需要带后缀//这里Test是我的场景名字
            if (null == sceneAsync)
            {
                isFalse = true;
                state = AssetBundleState.FINISH;
                ReleaseAssetbunle();
                Debug.LogError("加载场景失败" + path);
                return;
            }
            //sceneAsync.allowSceneActivation = false;
        }




    }
    public void ReleaseAssetbunle()
    {
        foreach (var ab in dps)
        {
            ab.count--;
        }
    }
    public void ActiveSceneAndReleaseAssetbunle()
    {
        if (null != sceneAsync)
        {
            //sceneAsync.allowSceneActivation = true;
            ReleaseAssetbunle();
        }
    }



    public void LoadingSprite2d()
    {
        if (null == mainBundle.handler.assetBundle)
        {
            isFalse = true;
            state = AssetBundleState.FINISH;
            ReleaseAssetbunle();
            Debug.LogError("assetbundle 加载失败" + path);
        }
        else
        {
            assetLoadRequest = mainBundle.handler.assetBundle.LoadAssetWithSubAssetsAsync<Sprite>(path);
        }
    }

    public void FillSprite2DAndReleaseAssetbunle()
    {
        if (null != assetLoadRequest)
        {

            UnityEngine.Object[] loadedAsset = assetLoadRequest.allAssets as UnityEngine.Object[];
            sprites = new Sprite[loadedAsset.Length];
            for (int i = 0; i < sprites.Length; i++)
                sprites[i] = (Sprite)loadedAsset[i];

            ReleaseAssetbunle();
        }

    }
}

public class LAssetBundle
{
    public int count = 0;
    public AssetBundleCreateRequest handler;
    public string path;
    public int frameTime = 3;

    public void LoasAsset(string path)
    {
        this.path = path;
        handler = AssetBundle.LoadFromFileAsync(path);
        //Debug.LogWarning("加载 "+path);
    }
    public bool isFinish()
    {
        return null != handler && handler.isDone;
    }

    public void Release()
    {
        if (isFinish())
        {
            if (null != handler && null != handler.assetBundle)
            {
                handler.assetBundle.Unload(false);
                //Debug.LogWarning("释放 " + path);
            }

        }
    }
}
public class LAssetBundleManager : MonoBehaviour
{
    public static string ROOT = Application.persistentDataPath + "/";
    public static string platform_mark = "Android";
    public static string bundleRoot;

    public Dictionary<string, string[]> relationships = new Dictionary<string, string[]>();
    bool Inited = false;
    public void Init()
    {
        if (Inited)
            return;

        LoadDependenciesRelationship();
        Inited = true;
    }
    void LoadDependenciesRelationship()
    {
        if (!(ROOT.EndsWith("/") || ROOT.EndsWith("\\")))
        {
            ROOT = ROOT += "/";
        }
        bundleRoot = ROOT;// + platform_mark + "/";

        string _manpath = bundleRoot + platform_mark;
        AssetBundle _manAB = AssetBundle.LoadFromFile(_manpath);
        AssetBundleManifest manifest = _manAB.LoadAsset<AssetBundleManifest>("AssetBundleManifest");

        foreach (string name in manifest.GetAllAssetBundles())
        {
            List<string> dependencies = new List<string>();
            string[] depends = manifest.GetAllDependencies(name);
            foreach (string dep in depends)
            {
                dependencies.Add(bundleRoot + dep);
            }
            string bundleName = bundleRoot + name;
            relationships[bundleName] = dependencies.ToArray();
        }
    }
    public void PrintDependencies()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var kv in relationships)
        {
            sb.Append(kv.Key);
            sb.Append("\n");
            foreach (string name in kv.Value)
            {
                sb.Append("\t");
                sb.Append(name);
                sb.Append("\n");
            }
        }
        Debug.Log(sb.ToString());
    }
    static LAssetBundleManager _ist = null;
    public static LAssetBundleManager Instance()
    {
        if (null == _ist)
        {
            GameObject g = new GameObject("AssetBundleManager");
            _ist = g.AddComponent<LAssetBundleManager>();
            _ist.Init();
            GameObject.DontDestroyOnLoad(g);
        }
        return _ist;
    }
    Dictionary<string, LAssetBundleHandle> loadingHandle = new Dictionary<string, LAssetBundleHandle>();
    Dictionary<string, LAssetBundle> loadingAssetBundle = new Dictionary<string, LAssetBundle>();
    //Dictionary<string,>
    LAssetBundle LoadBundle(string name)
    {
        LAssetBundle ab = null;
        if (!loadingAssetBundle.TryGetValue(name, out ab))
        {
            ab = new LAssetBundle();
            ab.LoasAsset(name);
            loadingAssetBundle[name] = ab;
        }
        ab.count++;
        return ab;

    }
    public LAssetBundleHandle LoadScene(string sceneName, string _path)
    {

        LAssetBundleHandle handle = LoadAssetFun(sceneName, _path, AssetBundleType.SCENE);
        handle.handleType = AssetBundleType.SCENE;

        return handle;
    }

    public LAssetBundleHandle LoadAsset(string objPath, string _path)
    {
        LAssetBundleHandle handle = LoadAssetFun(objPath, _path, AssetBundleType.OBJ);
        return handle;
    }

    public LAssetBundleHandle LoadSprite(string objPath, string _path)
    {
        LAssetBundleHandle handle = LoadAssetFun(objPath, _path, AssetBundleType.SPRITE2D);
        return handle;
    }
    LAssetBundleHandle LoadAssetFun(string objPath, string _path, AssetBundleType _type)
    {
        //Debug.LogError("for "+ objPath + " " + _type);
        _path = bundleRoot + _path;
        LAssetBundleHandle handle = null;
        if (loadingHandle.TryGetValue(objPath, out handle))
        {
            return handle;
        }
        handle = new LAssetBundleHandle();
        handle.handleType = _type;
        handle.state = AssetBundleState.LOADING_DEPENDS;
        handle.path = objPath;
        loadingHandle[objPath] = handle;
        string[] dps = null;

        if (relationships.TryGetValue(_path, out dps))
        {
            foreach (string n in dps)
            {
                handle.dps.Add(LoadBundle(n));
            }
        }
        var db = LoadBundle(_path);
        handle.mainBundle = db;
        handle.dps.Add(db);
        return handle;
    }


    HashSet<string> deleteTable = new HashSet<string>();
    HashSet<string> deleteHandleTable = new HashSet<string>();
    void DeleteAssetBundle()
    {
        foreach (var kv in loadingAssetBundle)
        {
            LAssetBundle ab = kv.Value;
            if (ab.count == 0)
            {
                if (ab.frameTime == 0)
                {
                    deleteTable.Add(kv.Key);
                }
                else
                {
                    ab.frameTime--;
                }

            }
            else
            {
                ab.frameTime++;
            }
        }
        foreach (var key in deleteTable)
        {
            var ab = loadingAssetBundle[key];
            ab.Release();
            loadingAssetBundle.Remove(key);
        }
        deleteTable.Clear();
    }
    private void LateUpdate()
    {
        bool clearAllHandle = false;


        foreach (var kv in loadingHandle)
        {
            LAssetBundleHandle handle = kv.Value;
            switch (handle.state)
            {
                case AssetBundleState.LOADING_DEPENDS:
                    {
                        //依赖项是否已经完全加载.
                        if (handle.isDependsFinish())
                        {
                            if (handle.handleType == AssetBundleType.SCENE)
                            {
                                handle.loadingScene();
                                if (handle.state == AssetBundleState.FINISH)
                                    return;
                                handle.state = AssetBundleState.LOADING_SCENE;
                            }
                            else if (handle.handleType == AssetBundleType.OBJ)
                            {
                                handle.LoadingObject();
                                if (handle.state == AssetBundleState.FINISH)
                                    return;
                                handle.state = AssetBundleState.LOADING_OBJ;
                            }
                            else
                            {
                                handle.LoadingSprite2d();
                                if (handle.state == AssetBundleState.FINISH)
                                    return;
                                handle.state = AssetBundleState.LOADING_SPRITE2d;
                            }

                        }
                    }
                    break;
                case AssetBundleState.LOADING_SCENE:
                    {
                        if (handle.isSceneFinish())
                        {
                            handle.ActiveSceneAndReleaseAssetbunle();
                            handle.state = AssetBundleState.FINISH;
                            clearAllHandle = true;

                        }
                    }
                    break;
                case AssetBundleState.LOADING_OBJ:
                    {
                        //依赖项是否已经完全加载.
                        if (handle.isObjectFinish())
                        {
                            handle.FillObjAndReleaseAssetbunle();
                            handle.state = AssetBundleState.FINISH;


                        }
                    }
                    break;

                case AssetBundleState.LOADING_SPRITE2d:
                    {
                        //依赖项是否已经完全加载.
                        if (handle.isObjectFinish())
                        {
                            handle.FillSprite2DAndReleaseAssetbunle();
                            handle.state = AssetBundleState.FINISH;


                        }
                    }
                    break;
                case AssetBundleState.FINISH:
                    {
                        if (handle.handleType == AssetBundleType.SCENE)
                        {
                            deleteHandleTable.Add(kv.Key);
                        }

                    }
                    break;
            }

        }
        if (clearAllHandle)
            ClearAllHandle();
        foreach (var key in deleteHandleTable)
        {
            loadingHandle.Remove(key);
        }
        deleteHandleTable.Clear();
        DeleteAssetBundle();

    }

    private void ClearAllHandle()
    {
        deleteHandleTable.Clear();
        foreach (var kv in loadingHandle)
        {
            LAssetBundleHandle handle = kv.Value;
            if (handle.handleType != AssetBundleType.SCENE)
            {
                handle.isFalse = true;
                handle.state = AssetBundleState.FINISH;
                deleteHandleTable.Add(kv.Key);
            }

        }
        foreach (var key in deleteHandleTable)
        {
            loadingHandle.Remove(key);
        }
        deleteHandleTable.Clear();
    }
}
