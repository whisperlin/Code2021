using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Dropdown))]
public class DropdownLanguageCtrl : MonoBehaviour, UILanguageCtrl
{

#if ART_PROJECT
    [System.NonSerialized]
    public string tempStr;
#endif
    Dropdown dropdown;

    public int[] ids = new int[0];
    public void SetDirty()
    {
        if (null == dropdown)
            dropdown = GetComponent<Dropdown>();
        List<string> list = new List<string>();
        for (int i = 0; i < ids.Length; i++)
        {
            int id = ids[i];
            list.Add( Language.GetValue(id));
        }
        int val = dropdown.value;
        UpdateDropDownItem(list);
        dropdown.value = val;
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


    void UpdateDropDownItem(List<string> showNames)
    {
        dropdown.options.Clear();
        Dropdown.OptionData temoData;
        for (int i = 0; i < showNames.Count; i++)
        {
            //给每一个option选项赋值
            temoData = new Dropdown.OptionData();
            temoData.text = showNames[i];
            
            //temoData.image = sprite_list[i];
            dropdown.options.Add(temoData);
        }
        dropdown.captionText.text = showNames[0];

    }

    // Start is called before the first frame update
    void Start()
    {
        dropdown = GetComponent<Dropdown>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
