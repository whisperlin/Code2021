using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectEX : MonoBehaviour
{
    public enum State
    {
        NotLoad,Loading,Loaded,
    }
    public delegate void LoadedFunction(GameObjectEX g);
    public LoadedFunction loadFinishCallBack = null;
    public int userDataInt = 0;
    public static GameObjectEX Create()
    {
        GameObject g = new GameObject("GameObjectEX");
        GameObjectEX gex = g.AddComponent<GameObjectEX>();
        return gex;
    }
    Animator animator = null;
    GameObject model = null;
    string animName = null;
    string modelPath = null;
    State state = State.NotLoad;

    public State GetState()
    {
        return state;
    }
    public void LoadModel(string path)
    {
        if (modelPath == path)
        {
            LoadFinish();
            return;
        }
 
        state = State.Loading;
        modelPath = path;
        GameObjectPools.Instance().LoadObject(0, path, LoadedCallback);
    }
    private void OnDestroy()
    {
        ReleaseModel();
    }
    public void ReleaseModel()
    {
        if (null != model)
        {
            GameObjectPools.Instance().ReleaseInstance(model);
        }
        modelPath = null;
        model = null;
    }
    void LoadFinish()
    {
        if (null != animName)
            Play(animName);
        state = State.Loaded;
        if (null != loadFinishCallBack)
            loadFinishCallBack(this);
    }
    void LoadedCallback(int id, string path)
    {
        ReleaseModel();
        model = GameObjectPools.Instance().CreateObject(path);
        modelPath = path;
        if (null == model)
        {
            if (null != loadFinishCallBack)
                loadFinishCallBack(this);
            return;
        }
            
        if(gameObject.layer !=0 )
            Common.SetLayer(gameObject.layer, model.transform);
        model.transform.parent = transform;
        model.transform.localPosition = Vector3.zero;
        model.transform.localRotation = Quaternion.identity;
        model.transform.localScale = Vector3.one;
        animator = model.GetComponentInChildren<Animator>();
        LoadFinish();
    }
    
    public void Play(string name)
    {
        animName = name;
        if (null != animator)
        {
            animator.Play(name, -1, 0f);
        }
    }
    public void CrossFade(string name,float delta = 0.1f)
    {
        animName = name;
        if (null != animator)
        {
            animator.CrossFade(name, delta,-1 );
        }
    }

    public  T AddComponent<T>() where T : Component
    {
        return gameObject.AddComponent<T>();
    }

    public void SetParentAndIdentyify(Transform transform)
    {
        this.transform.parent = transform;
        this.transform.localPosition = Vector3.zero;
        this.transform.localRotation = Quaternion.identity;
        this.transform.localScale = Vector3.one;
    }
}
