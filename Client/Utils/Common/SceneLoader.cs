
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public delegate void OnProecssCallback(float t);
public class SceneLoader  
{

    public static IEnumerator FLoadLevel(string sceneName)
    {
        {
            string bundleName = Config.SCENE_ASSET_BUNDLE_HEATER + sceneName.ToLower();
            LAssetBundleHandle handle2 = LAssetBundleManager.Instance().LoadScene(sceneName, bundleName);
            while (handle2.state != AssetBundleState.FINISH)
                yield return null;
            //lasLevelName = sceneName;
        }
    }
 
}
