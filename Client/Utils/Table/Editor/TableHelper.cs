using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
#if UNITY_EDITOR
 
public class TableHelper  
{


    [MenuItem("工具/表格/加载表格")]
    static void Start()
    {
        string cnf_path = @"Tables\tables.json";
        string temp_path = @"Tables\TableTemps.cs";
        string temp_path2 = @"Tables\Tables.cs";
        string root = Application.persistentDataPath + "/";
        string outDir = @"Assets\Scripts\Data\Table\";
        //string outDir = @"Tables\Temp\";
        string cnf = System.IO.File.ReadAllText(cnf_path);
        string temp = System.IO.File.ReadAllText(temp_path);
        Dictionary<string,string> names = JsonConvert.DeserializeObject<Dictionary<string, string>>(cnf);
        Dictionary<string, string> name_types = JsonConvert.DeserializeObject<Dictionary<string, string>>(cnf);
        float delta = 1.0f / names.Count;
        float progress = 0f;

        foreach (var kv in names)
        {
            EditorUtility.DisplayProgressBar("加载", kv.Key, progress);
            progress += delta;
            string path = root + kv.Key + ".json";
            try
            {
                string txt = System.IO.File.ReadAllText(path);
                
                txt = JsonUtil.Config(txt);
 
                JArray listy = JArray.Parse(txt);
                if (listy != null && listy.Count > 0)
                {
                    string id = kv.Value;
                    JTokenType idType = JTokenType.Integer;
                    Dictionary<string, JTokenType> types = new Dictionary<string, JTokenType>();
                    foreach (JToken jt in listy)
                    {
                        if (jt.Type == JTokenType.Object)
                        {
                            JObject _map = jt.Value<JObject>();
                            if (_map.HasValues)
                            {
                                foreach (JProperty jp in _map.Properties())
                                {
                                    JTokenType _type;
                                    if (types.TryGetValue(jp.Name, out _type))
                                    {
                                        if (_type == JTokenType.Integer)
                                        {
                                            types[jp.Name] = jp.Value.Type;
                                        }
                                    }
                                    else
                                    {
                                        types[jp.Name] = jp.Value.Type;
                                    }
                                    if (id == jp.Name)
                                    {
                                        idType = jp.Value.Type;
                                    }
                                    //Debug.LogError(jp.Value.Type + " " + jp.Name + " " +  jp.Value);
                                }
                            }
                            

                        }
                    }
                    string propertys = "\n";
                    string output = ReplayTips(temp, kv.Key);
                    output = ReplayType(output, idType);
                    output = output.Replace("{id}", id);
                    foreach (var vk in types)
                    {
                        propertys += AddProperty(vk.Key, vk.Value);
                    }
                    
                    string id_type = Get_Type(idType);
                    name_types[kv.Key] = id_type;
                    output = output.Replace("{propertys}", propertys);
                    System.IO.File.WriteAllText(outDir + kv.Key+ "Table.cs", output);
                    AssetDatabase.ImportAsset(outDir + kv.Key + "Table.cs");
                    //Debug.LogError(output);
                } 
            }
            catch (System.Exception e)
            {
                Debug.LogError("加载"+path+"失败\n"+e.ToString()+"\n"+e.StackTrace );
            }
            string contaimText = System.IO.File.ReadAllText(temp_path2);
            string ctInit= "\n";
            string ctPropertys = "\n";
            foreach (var vk in name_types)
            {
                ctPropertys += "\tpublic static Dictionary<"+vk.Value+", "+ClassName(vk.Key) +"Table> "+ ProperName(vk.Key) + "Table;\n";
                ctPropertys += "\tpublic static List<"  + ClassName(vk.Key) + "Table> " + ProperName(vk.Key) + "List;\n";
                ctInit += "\t\thandle = TextFileLoader.Instance().LoadText(  \"" + vk.Key + ".json\");\n\t\twhile (!handle.isFinish) yield return null;\n";
                ctInit += "\t\t"+ ProperName(vk.Key) + "List = " + ClassName(vk.Key) + "Table.LoadList(JsonUtil.Config(handle.text));\n";
               
                ctInit += "\t\t"+ProperName(vk.Key)+"Table = "+ ClassName(vk.Key) + "Table.LoadDictionary( "+ProperName(vk.Key) + "List );\n";
            }
            contaimText = contaimText.Replace("{propertys}", ctPropertys);
            contaimText = contaimText.Replace("{init}", ctInit);
            System.IO.File.WriteAllText(outDir+"Tables.cs", contaimText);
            AssetDatabase.ImportAsset(outDir + "Tables.cs");
        }
        EditorUtility.ClearProgressBar();
    }

    

    static string ProperName(string name)
    {
        name = name.Substring(0, 1).ToLower() + name.Substring(1);
        return name;
    }
    static string ClassName(string name)
    {
        name = name.Substring(0, 1).ToUpper() + name.Substring(1);
        return name;
    }
    private static string Get_Type(JTokenType _type)
    {
        if (_type == JTokenType.Integer)
        {
            return "int";
        }
        else if (_type == JTokenType.String)
        {
            return "string";

        }
        return "float";
    }
    private static string AddProperty(string key, JTokenType _type)
    {
        string txt = "\tpublic " ;
        txt+= Get_Type(_type)+" "+key + ";\n";
        return txt;
    }
    static string ReplayType(string txt, JTokenType idType)
    {
        if (idType == JTokenType.Integer)
        {
            txt = txt.Replace("{type}", "int");
        }
        else if (idType == JTokenType.String)
        {
            txt = txt.Replace("{type}", "string");
            
        }
        else
        {
            txt = txt.Replace("{type}", "float");
        }
         
        
        return txt;
    }

    //JTokenType idType
    //                output = output.Replace("{type}","string");
    static string ReplayTips(string txt, string name)
    {
        txt = txt.Replace("{_name}", "\"" + name + "\"");
        txt = txt.Replace("{name}", ProperName(name));
        txt = txt.Replace("{Name}", ClassName(name));
        return txt;
    }


}
#endif