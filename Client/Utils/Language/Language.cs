using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Language
{
    public static List<UILanguageCtrl> ctrls = new List<UILanguageCtrl>();

    static Dictionary<int, string> map = new Dictionary<int, string>();
    static Dictionary<string, string> bundleMap = new Dictionary<string, string>();
    static Action<bool> cmp;
    static string curLanguage;
    
    static string[] names = new string[0];
    static bool loadFromResources = false;
    public static string[] Names { get => names;  }

 
    /// <summary>
    /// 获取键值
    /// </summary>
    /// <param name="key">数字索引</param>
    /// <returns></returns>
    public static string GetValue(int key)
    {
#if ART_PROJECT
        Init("中文", OnArtFinish );
#endif
        try
        {
            return map[key];
        }
        catch (System.Exception e)
        {
            return "找不到标签"+ key + " "+e.ToString().Substring(0,0);
        }
    }
#if ART_PROJECT
    private static void OnArtFinish(bool obj)
    {
        
    }
#endif
    /// <summary>
    /// 从bundle中初始化
    /// </summary>
    /// <param name="defaultLanguage">默认语言</param>
    /// <param name="onCompline">回调函数</param>
    public static void Init(string defaultLanguage , Action<bool> onCompline)
    {
        curLanguage = defaultLanguage;
        cmp = onCompline;
        LanguageFileLoader.Instance().LoadTextCallBack( "assets/language/list.txt",OnLoadList);
 
    }

    private static void OnLoadList(bool scuess, string txt)
    {
        bundleMap = JsonConvert.DeserializeObject<Dictionary<string, string>>(txt);
        List<string> ns = new List<string>();
        foreach (var k in bundleMap.Keys)
        {
            ns.Add(k);
        }
        names = ns.ToArray();
        if (!bundleMap.ContainsKey(curLanguage))
        {
            foreach (var k in bundleMap.Keys)
            {
                curLanguage = k;
                break;
            }
        }
        loadFromResources = false;
        LoadLanguage(curLanguage);
        cmp(true);
    }

   

    /// <summary>
    /// 在加载assetbunle之前，
    /// </summary>
    public static void InitFromResource()
    {
        TextAsset txt = (TextAsset)Resources.Load(BundleNameToResources("language/list.txt"));
        bundleMap = JsonConvert.DeserializeObject<Dictionary<string, string>>(txt.text);
        List<string> ns = new List<string>();
        foreach (var k in bundleMap.Keys)
        {
            ns.Add(k);
        }
        names = ns.ToArray();
        loadFromResources = true;
    }
    static string BundleNameToResources(string name)
    {
        int index = name.LastIndexOf('.');
        if (index > 0)
        {
            name = name.Substring(0, index);
        }
        return name;
    }

    

    public static void LoadLanguage(string language)
    {
        if(!bundleMap.ContainsKey(language))
        {
            return;
        }
        curLanguage = language;
        if (loadFromResources)
        {
            OnLanguageFromResource();
        }
        else
        {
            string path = "assets/" + bundleMap[curLanguage];
            LanguageFileLoader.Instance().LoadTextCallBack(  path, OnLoadLanguage);
            
        }
        
    }
    private static void OnLoadLanguage(bool scuess, string json)
    {
        Dictionary<int, string> tipsMap = JsonConvert.DeserializeObject<Dictionary<int, string>>(json);
        Fill(tipsMap);
        foreach (var c in ctrls)
        {
            c.SetDirty();
        }
    }

   
    static void OnLanguageFromResource( )
    {
        string path = BundleNameToResources( bundleMap[curLanguage]);
        TextAsset txt = (TextAsset) Resources.Load(path);
        string json = txt.text;
        Dictionary<int, string> tipsMap = JsonConvert.DeserializeObject<Dictionary<int, string>>(json);
        Fill(tipsMap);
        foreach (var c in ctrls)
        {
            c.SetDirty();
        }
    }

    static void Fill(Dictionary<int, string> data)
    {
        
        foreach (var p in data)
        {
            map[p.Key] = p.Value;
        }
    }
}
