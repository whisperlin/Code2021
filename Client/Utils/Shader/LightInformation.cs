using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LightInformation : MonoBehaviour
{
    public Color roleAmbientColor = Color.gray;
    void SetParams()
    {
        Shader.SetGlobalColor("RoleAmbientColor", roleAmbientColor);
    }
    
#if UNITY_EDITOR

    private void Update()
    {
        SetParams();
    }
#else
    
    private void OnPreRender()
    {

    }
    private void OnPostRender()
    {

    }

#endif

}
