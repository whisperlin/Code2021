using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[ExecuteInEditMode]
[RequireComponent(typeof(UnityEngine.UI.Text))]
public class TextLanguageCtrl : MonoBehaviour, UILanguageCtrl
{

#if ART_PROJECT
    [System.NonSerialized]
    public string tempStr;
#endif
    public int id;
    [System.NonSerialized]
    public Text text;
    System.Object[] foramtParams = new System.Object[0];


    public void SetParams(params System.Object[] _params)
    {
        ForamtParams = _params;
    }
    public object[] ForamtParams
    {
        set
        {
            foramtParams = value;
            SetDirty();
        }
    }

    public void CheckText()
    {
        if (null == text)
            text = GetComponent<Text>();
    }
    private void Start()
    {
        CheckText();
    }
    private void OnEnable()
    {
        Language.ctrls.Add(this);
        SetDirty();

    }
    public void OnDisable()
    {
        Language.ctrls.Remove(this);
    }

    public void SetDirty()
    {
        CheckText();
        if (null == text)
            return;
        if (foramtParams.Length == 0)
        {
            text.text = Language.GetValue(id);
        }
        else
        {
            try
            {
                text.text = string.Format(Language.GetValue(id), foramtParams);
            }
            catch (System.Exception e)
            {
                e.ToString();
            }

        }

    }

}


