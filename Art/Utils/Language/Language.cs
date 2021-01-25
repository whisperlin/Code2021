using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Language
{

    public static int minId = 100;
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
        if (map.Count == 0)
        {
            Init("中文", null);
        }
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

    public static void SaveMap(string path)
    {
        string allText = JsonConvert.SerializeObject(map);
        allText = allText.Replace("\",\"", "\",\n\"");
        System.IO.File.WriteAllText(path, allText);

#if UNITY_EDITOR
        AssetDatabase.ImportAsset(path);
#endif

    }

    
    public static int AddToMap(string tempStr)
    {
        try
        {
            Language.minId = int.Parse(System.IO.File.ReadAllText("languageId.ids"));
        }
        catch (System.Exception e)
        {
        }
        int id = minId;
        while (map.ContainsKey(id))
        {
            id++;
        }
        map[id] = tempStr;
        return id;
    }

    public static bool HasValue(string tempStr,ref int id)
    {
        foreach (var kv in map)
        {
            try
            {
                if (kv.Value == null)
                {
                    map[kv.Key] = tempStr;
                    return true;
                }
                int cmp = kv.Value.CompareTo(tempStr);
                if (cmp==0)
                {
                    id = kv.Key;
                    return true;
                }
            
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
            }

        }
        return false;
    }

    /*#if ART_PROJECT
   private static void OnArtFinish(bool obj)
   {

   }
#endif*/
    /// <summary>
    /// 从bundle中初始化
    /// </summary>
    /// <param name="defaultLanguage">默认语言</param>
    /// <param name="onCompline">回调函数</param>
    public static void Init(string defaultLanguage , Action<bool> onCompline)
    {
        curLanguage = defaultLanguage;
        cmp = onCompline;
        TextFileLoader.Instance().LoadText(Config.LANGUAGE_ASSET_BUNDLE_NAME, "assets/language/list.txt",OnLoadList);
 
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
        if(null != cmp)
            cmp(true);
    }

   

    /// <summary>
    /// 在加载assetbunle之前，
    /// </summary>
    public static void InitFromResource()
    {
        //var o = Resources.Load<TextAsset>(BundleNameToResources("language/list.txt"));
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
            TextFileLoader.Instance().LoadText(Config.LANGUAGE_ASSET_BUNDLE_NAME, path, OnLoadLanguage);
            
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
