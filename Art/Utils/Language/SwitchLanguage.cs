using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
public class SwitchLanguage : MonoBehaviour
{
     

    // Update is called once per frame
    public void SetLange(string name)
    {
        Language.LoadLanguage(name);
    }
}
