using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonUtil  
{
    const string heater = "\"data\":";
    public static string Config(string text)
    {
        int index = text.IndexOf(heater);
        if (index > 0)
        {
            index += 7;
 
            text = text.Substring(index, text.Length-index-1);
        }
        return text;
    }
}
