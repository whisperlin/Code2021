 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CallBackData
{
    public CallBackData(int _id, string _path, LoadedCallback _callback)
    {
        id = _id;
        path = _path;
        callback = _callback;
    }
    public string path;
    public int id = -1;
    public LoadedCallback callback;
}

public class LoadHande
{
    public bool isFinish = false;
    public UnityEngine.Object obj;
    public List<CallBackData> callbacks = new List<CallBackData>();
}
public delegate void LoadedCallback(int id, string path);
/// <summary>
/// 容器池，管理场景资源和战斗资源.
/// </summary>
public class GameObjectPools  : MonoBehaviour
{
    Dictionary<string, UnityEngine.Object> objects = new Dictionary<string, Object>();
    Dictionary<string, Stack<GameObject>> instances = new Dictionary<string, Stack<GameObject>>();
    Dictionary<GameObject, string> instancesInformation = new Dictionary<GameObject, string>();
    private static GameObjectPools _instance;
    public static GameObjectPools Instance()
    {
        if (null == _instance)
        {
            GameObject g = new GameObject("GameObjectPools");
            _instance = g.AddComponent<GameObjectPools>();
        }
        return _instance;
    }


    public  void AddObject(string path, UnityEngine.Object _object)
    {
        objects[path] = _object;
    }
    public  bool HasObject(string path)
    {
        return objects.ContainsKey(path);
    }
    Dictionary<string, LoadHande> loadingStack = new Dictionary<string, LoadHande>();


    public LoadHande LoadObject(int id, string path, LoadedCallback callBack)
    {
        string bundleName = BundleMap.GetBundleName(path);
        LoadHande handle = new LoadHande();
        if (HasObject(path))
        {
            handle.isFinish = true;
            handle.obj = objects[path];
            callBack(id,path);
            return handle;
        }
        if (loadingStack.ContainsKey(path))
        {
            handle = loadingStack[path];
            handle.callbacks.Add(new CallBackData(id, path, callBack));
            return handle;
        }
        handle.callbacks.Add(new CallBackData(id,path,callBack));
        loadingStack[path] = handle;
        StartCoroutine(LoadObjectSC(bundleName, path, handle));
        return handle;

    }

    public LoadHande LoadObject(string path )
    {
        string bundleName = BundleMap.GetBundleName(path); 
        LoadHande handle = new LoadHande();
        if (HasObject(path))
        {
            handle.isFinish = true;
            handle.obj = objects[path];
            return handle;
        }
            
        if (loadingStack.ContainsKey(path))
            return loadingStack[path];
        
        loadingStack[path] = handle;
        StartCoroutine(LoadObjectSC(bundleName,path, handle));
        return handle;
     
    }

    private IEnumerator LoadObjectSC(string bundleName, string path, LoadHande handle)
    {


        LAssetBundleHandle _handle = LAssetBundleManager.Instance().LoadAsset(path, bundleName);
        while (_handle.state != AssetBundleState.FINISH)
            yield return null;
        if (_handle.isFalse)
        {
            Debug.LogError("找不到" + path);
            GameObject g = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            objects[path] = g;
            handle.obj = g;
            //GameObject g = (GameObject)GameObject.Instantiate(handle2.obj);
        }
        else
        {
            objects[path] = _handle.obj;
            handle.obj = _handle.obj;
        }

         
        foreach (var _c in handle.callbacks)
        {
            _c.callback(_c.id, _c.path);
        }
        handle.isFinish = true;
    }

    public  UnityEngine.Object GetObject(string path)
    {
        UnityEngine.Object obj = null;
        objects.TryGetValue(path, out obj);
        return obj;
    }

    Stack<GameObject> GetStack(string path)
    {
        Stack<GameObject> _stack = null;
        if (instances.TryGetValue(path,out _stack))
        {
            return _stack;
        }
        _stack = new Stack<GameObject>();
        instances[path] = _stack;
        return _stack;
    }
    public UnityEngine.GameObject CreateObjectAutoRelease(string path,float lifeTime)
    {
        GameObject g = CreateObject(path);
        if (null == g)
        {
            Debug.LogError("创建资源失败"+path);
            return null;
        }
        GameObjectPoolAutoRelease  c = g.AddComponent<GameObjectPoolAutoRelease>();

        c.lifeTime = lifeTime;
        return g;
    }
    public  UnityEngine.GameObject CreateObject(string path )
    {
        
        if (null != path && objects.ContainsKey(path))
        {
            Stack<GameObject> _stack = GetStack(path);
            GameObject g = null;
            if (_stack.Count > 0)
            {
                g = _stack.Pop();
                g.SetActive(true);

            }
            if (g == null)
            {
                var obj = objects[path];
                if (obj == null)
                {
                    Debug.LogError("对象为空" + path);
                    g = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                }
                else
                {
                    g = (GameObject)GameObject.Instantiate(obj);
                }
                instancesInformation[g] = path;
            }
            return g;
        }
        
        return null;
    }
    public  void  ReleaseInstance(  GameObject g)
    {
        if (null == g)
            return;
        if (instancesInformation.ContainsKey(g))
        {
            string path = instancesInformation[g];
            if (objects.ContainsKey(path))
            {
                Stack<GameObject> _stack = GetStack(path);
                g.SetActive(false);
                g.transform.parent = null;
                _stack.Push(g);
            }
        }
        else
        {
            GameObject.Destroy(g);
        }
    }

    public  void Clear()
    {
        try
        {
            foreach (UnityEngine.GameObject _obj in instancesInformation.Keys)
            {
                GameObject.Destroy(_obj);
            }
            
            foreach (UnityEngine.Object _obj in objects.Values)
            {
                GameObject.Destroy(_obj);
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError(e.ToString());
        }
        instancesInformation.Clear();
        instances.Clear();
        objects.Clear();
        loadingStack.Clear();
        ;
    }
    private void OnDestroy()
    {
        Debug.LogError("切换场景删除容器池");
    }
}
