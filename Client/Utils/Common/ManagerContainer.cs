
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  enum  ManagerContainerState
{
    NONE = 0,
    INITTING = 1,
    SCUESS = 2,
    FALSE = 3,
}
public class ManagerContainer 
{

    static ManagerContainerState state = ManagerContainerState.NONE;
    //public static AssetBundleManager assetBundleManager;
 
    public static ManagerContainerState State { get => state; }

    public static void Init ()
    {
        if (State != ManagerContainerState.NONE)
            return;
        state = ManagerContainerState.INITTING;

        Debug.Log("初始化assetbundle " + Time.realtimeSinceStartup);
        //ManagerContainer.assetBundleManager = new AssetBundles.AssetBundleManager();
#if UNITY_ANDROID
        //assetBundles
        //var url = Application.dataPath + "/../assetBundles";
        var url = Application.persistentDataPath ;
        LAssetBundleManager.platform_mark = "Android";
#else
            var url = "file:///" + Application.dataPath + "/../assetBundles";
         LAssetBundleManager.platform_mark = "IOS";
#endif
        //ManagerContainer.assetBundleManager.SetBaseUri(new[] { url });
#if DEBUG_LOG
        //ManagerContainer.assetBundleManager.DisableDebugLogging();
#endif
        //ManagerContainer.assetBundleManager.Initialize(OnAssetBundleManagerInitialized);
        LAssetBundleManager.ROOT = url;
        LAssetBundleManager.Instance().Init();
        LAssetBundleManager.Instance().PrintDependencies();
        BundleMap.Load(OnBundleMapFinish);
    }

    static void OnBundleMapFinish()
    {
        Debug.Log("初始化多语言 " + Time.realtimeSinceStartup);
        Language.Init("中文", OnLanguageFinish);
    }
    /*private static void OnAssetBundleManagerInitialized(bool success)
    {

        
        if (success)
        {
            BundleMap.Load(OnBundleMapFinish);
            

            
        }
        else
        {
            state = ManagerContainerState.FALSE;
        }

    }*/
    private static void OnLanguageFinish(bool scuess)
    {
 
        Debug.Log("初始化表格 " + Time.realtimeSinceStartup);
        //加载表格
        Tables.Init(OnGameDataFinish);
        
    }

    private static void OnGameDataFinish()
    {
        //手写的一些表格相关代码
        TablesHelper.Init();
        state = ManagerContainerState.SCUESS;
    }
    
}
