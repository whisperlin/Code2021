using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConifg 
{

#if UNITY_EDITOR
    
    public static string PersistentDataPath = Application.dataPath + "/EditorTemp";
#else
    public static string PersistentDataPath = Application.persistentDataPath ;
#endif

}
