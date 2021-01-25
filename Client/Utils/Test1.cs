using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[System.Serializable]
public class MyTable
{
    public string a1;
    public int a2;
}
public class Test1 : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        string txt = @"
        {
            @a.json@:{@a1@:@xxxx@,@a2@:121},
            @b.json@:{@a1@:@oooo@,@a2@:3333},
        }
        ";
        txt = txt.Replace('@', '"');

        Debug.Log(txt);
        Dictionary<string, MyTable>  tab = JsonConvert.DeserializeObject<Dictionary<string, MyTable>>(txt);

        foreach (var kv in tab)
        {
            Debug.Log("key = "+kv.Key);
            Debug.Log("    " + kv.Value.a1);
            Debug.Log("    " + kv.Value.a2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
