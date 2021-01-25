using UnityEngine;
using UnityEditor;
using System;
using UnityEngine.UI;
using System.Collections.Generic;



 
public class BuildUIScript : EditorWindow
{
    string savePath = @"D:\MyWorkspaces\client\AndroidClient\Assets\Scripts\UI";
    string ui_temp = "";
    GameObject g;
    string uiClassName = "DemoUI";


    [MenuItem("工具/UI/控件大小使用精灵大小 _F10")]
    static void FixToSpritSize()
    {
        if (null != Selection.activeGameObject)
        {
            Image img = Selection.activeGameObject.GetComponent<Image>();
            if (null != img)
            {
                RectTransform rt = Selection.activeGameObject.GetComponent<RectTransform>();
                rt.sizeDelta = new Vector2(img.sprite.rect.width, img.sprite.rect.height);
            }
        }
    }
    // Add menu named "My Window" to the Window menu
    [MenuItem("工具/UI/生成UI类方法 _F11")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        BuildUIScript window = (BuildUIScript)EditorWindow.GetWindow(typeof(BuildUIScript));
        window.Show();
    }
    [MenuItem("GameObject/UI/Image图片")]
    static void UIImage()
    {
        GameObject g = new GameObject();
        g.AddComponent<Image>();
        RectTransform rt = g.GetComponent<RectTransform>();
        g.name = "Image";
        rt.anchorMax = rt.anchorMin = new Vector2(0f, 1f);
        rt.pivot = new Vector2(0f, 1f);
        if (Selection.activeGameObject != null)
        {
            rt.parent = Selection.activeGameObject.transform;
            rt.anchoredPosition = Vector2.zero;
        }
        Selection.activeGameObject = g;
 
    }

    [MenuItem("GameObject/UI/Button按钮")]
    static void UIButton()
    {
        GameObject g = (GameObject)PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath("assets/art/ui/common/button.prefab",typeof(GameObject)))  ;
      
        RectTransform rt = g.GetComponent<RectTransform>();
        g.name = "Button";
        rt.anchorMax = rt.anchorMin = new Vector2(0f, 1f);
        rt.pivot = new Vector2(0f, 1f);
        if (Selection.activeGameObject != null)
        {
            rt.parent = Selection.activeGameObject.transform;
            rt.anchoredPosition = Vector2.zero;
        }
        Selection.activeGameObject = g;

    }

    [MenuItem("GameObject/UI/Text文字")]
    static void UIFone()
    {
        GameObject g = new GameObject();
        Text txt = g.AddComponent<Text>();
        RectTransform rt = g.GetComponent<RectTransform>();
        g.name = "Text";
        rt.anchorMax = rt.anchorMin = new Vector2(0f, 1f);
        rt.pivot = new Vector2(0f, 1f);
        rt.sizeDelta = new Vector2(150f, 50f);
        if (Selection.activeGameObject != null)
        {
            rt.parent = Selection.activeGameObject.transform;
            rt.anchoredPosition = Vector2.zero;
        }
        txt.alignment = TextAnchor.MiddleLeft;
        txt.horizontalOverflow = HorizontalWrapMode.Overflow;
        txt.verticalOverflow = VerticalWrapMode.Overflow;
        txt.fontSize = 30;
        g.AddComponent<Outline>();
        txt.color = Color.white;
        g.AddComponent<TextLanguageCtrl>();
        Selection.activeGameObject = g;
    
        
    }

    void OnGUI()
    {
         
        uiClassName = EditorGUILayout.TextField("类名", uiClassName);
        GameObject g0 = g;
        g = (GameObject)EditorGUILayout.ObjectField("对象",g,typeof(GameObject),true);
        if (g0 != g)
        {
            uiClassName = g.name  ;
            if (!uiClassName.EndsWith("UI"))
                uiClassName += "UI";
            uiClassName = ClassName (uiClassName);
        }
         
        if (GUILayout.Button("生成基类"))
        {
            {
                var t = AssetDatabase.LoadAssetAtPath<TextAsset>("Assets/Utils/UI/Editor/UITemp.txt");
                if (null != t)
                    ui_temp = t.text;
                string uiSavePath = savePath + "/" + uiClassName + "Base.cs";
                if (System.IO.File.Exists(uiSavePath))
                {
                    if (!EditorUtility.DisplayDialog("提升", "文件已经存在,是否覆盖", "确定", "取消"))
                    {
                        return;
                    }
                }
                string ui_final = GetUIClassBase(AssetDatabase.LoadAssetAtPath<TextAsset>("Assets/Utils/UI/Editor/UITempBase.txt").text, uiClassName, g);
                System.IO.File.WriteAllText(uiSavePath, ui_final);
            }
            {
                var t = AssetDatabase.LoadAssetAtPath<TextAsset>("Assets/Utils/UI/Editor/UITempSub.txt");
                if (null != t)
                    ui_temp = t.text;
                string uiSavePath = savePath + "/" + uiClassName + ".cs";

                if (!System.IO.File.Exists(uiSavePath))
                {
                    string ui_final = GetUIClassSub(AssetDatabase.LoadAssetAtPath<TextAsset>("Assets/Utils/UI/Editor/UITempSub.txt").text, uiClassName, g);
                    System.IO.File.WriteAllText(uiSavePath, ui_final);
                }
            }
        }

        /*if (GUILayout.Button("生成子类"))
        {
            
        }*/
        /*if (GUILayout.Button("生成子类"))
        {
            var t = AssetDatabase.LoadAssetAtPath<TextAsset>("Assets/Utils/UI/Editor/UITemp.txt");
            if (null != t)
                ui_temp = t.text;
            string uiSavePath = savePath + "/" + uiClassName + ".cs";
            if (System.IO.File.Exists(uiSavePath))
            {
                if (!EditorUtility.DisplayDialog("提升", "文件已经存在,是否覆盖", "确定", "取消"))
                {
                    return;
                }
            }
 

            string ui_final = GetUIClass(ui_temp, uiClassName, g);
            System.IO.File.WriteAllText(uiSavePath, ui_final);
        }*/
        savePath  = EditorGUILayout.TextField("保存路径", savePath);

    }
    string buttomTemp0 = @"		{name} = FindButton({_name});
    ";
    string textTemp0 = @"		{name} = FindText({_name});
    ";
    
    string textAdvancedTemp0 = @"		{name} = FindAdvancedText({_name});
    ";

    string textTemp1 = @"		{name} = FindTextCtrl({_name});
    ";

    string imageTemp0 = @"		{name} = FindImage({_name});
    ";

    string rectTemp0 = @"		{name} = FindTransform({_name});
    ";

    string inputFieldTemp0 = @"		{name} = FindInputField({_name});
    ";

    

    string buttonsFunTemp0 = @"
        if ({name})
        {
            {name}.OnClick = this.On{Name}Click ;
        }
    ";
    string gridTemp0 = @"		{name} = FindGrid({_name});
    ";
    string listBarTemp0 = @"		{name} = FindListBar({_name});
    ";
    string dropDownTemp0 = @"		{name} = FindDropdown({_name});
    ";

    string rawImage0 = @"		{name} = Common.FindInChild(root, {_name}).GetComponent<RawImage>();
    ";
    string gridFunTemp0 = @"
        if ({name})
        {
            {name}.itemClick = this.On{Name}ItemClick ;
        }
    ";
    string dropDownFunTemp0 = @"
        if ({name})
        {
            {name}.onValueChanged.AddListener((int value) => On{Name}Change(value));
        }
    ";
    
    string rawFunImage0 = @"
        if ({name})
        {
             IMouseCallback m = {name}.gameObject.AddComponent<IMouseCallback>();
             m.onClick = On{Name}Click;
             m.OnDragFun = On{Name}Drag;
             m.onBeginDrag = On{Name}BeginDrag;
             m.onEndDrag = On{Name}EndDrag;
        }
    ";
    string listBarFunTemp0 = @"
        if ({name})
        {
            {name}.itemClick = this.On{Name}ItemClick ;
        }
    ";

    string gridFunciontTemp0B = @"
    public abstract void On{Name}ItemClick(int index) ;";
    string dropDownFunciontTemp0B = @"
    public abstract void On{Name}Change(int index) ;";
    string rawImageFunciontTemp0B = @"
    public abstract void On{Name}Click(PointerEventData eventData) ;
    public abstract void On{Name}Drag(PointerEventData eventData) ;
    public abstract void On{Name}BeginDrag(PointerEventData eventData) ;
    public abstract void On{Name}EndDrag(PointerEventData eventData) ;
";

    string listBarFunciontTemp0B = @"
    public abstract void On{Name}ItemClick(int index) ;";

    string buttonsFunciontTemp0B = @"
    public abstract void On{Name}Click(GameObject sender,int userData) ;";

    string buttonsFunciontTemp0 = @"
    public void On{Name}Click(GameObject sender)
    {
         //ClickHidePanelUI.PopAndHide();
    }
    ";


    string inputFieldFunTemp0 = @"
        if ({name})
        {
            {name}.onValueChanged.AddListener( On{Name}Change);
            {name}.onEndEdit.AddListener( On{Name}EndEdit);
        }
    ";

    string inputFieldFunciontTemp0 = @"
    public void On{Name}Change(string txt)
    {
         
    }
    public void On{Name}EndEdit(string txt)
    {
         
    }
    ";

    string inputFieldFunciontTemp0B = @"
    public abstract void On{Name}Change(string txt);
    public abstract void On{Name}EndEdit(string txt);";

    string clickTemp0 = @"
         
        if ({name})
        {
            UIHelper.AddOnClick({name}.gameObject, On{Name}Click);
        }
    ";
    string clickFunctionTemp0 = @"
         
    private void On{Name}Click(PointerEventData eventData)
    {
            
    } 
    ";

    string clickFunctionTemp0B = @"
         
    public abstract void On{Name}Click(PointerEventData eventData);";
    string ProperName(string name)
    {
        name = name.Substring(0, 1).ToLower() + name.Substring(1);
        name = name.Replace(" ","");
        return name;
    }
    string ClassName(string name)
    {
        name = name.Substring(0, 1).ToUpper() + name.Substring(1);
        return name;
    }

    string ReplayTips(string txt ,GameObject g)
    {
        txt = txt.Replace("{_name}", "\"" + g.name + "\"");
        txt = txt.Replace("{name}", ProperName(g.name));
        txt = txt.Replace("{Name}", ClassName(g.name));
        return txt;
    }
    GameObject[] GetAllChild(GameObject g)
    {
        List<GameObject> gs = new List<GameObject>();
        GetAllChild(g.transform, gs);
        return gs.ToArray();
    }



    void GetAllChild(Transform t, List<GameObject> gs)
    {
        for (int i = 0; i < t .childCount; i++)
        {
            Transform t0 = t.GetChild(i);
            gs.Add(t0.gameObject);
            GetAllChild(t0, gs);
        }
    }

    T[] GetAllChild<T>(GameObject g) where T : Component
    {
        List<T> gs = new List<T>();
        GetAllChildCmp<T>(g.transform, gs);
        return gs.ToArray();
    }
    void GetAllChildCmp<T>(Transform t, List<T> gs) where T : Component
    {
        for (int i = 0; i < t.childCount; i++)
        {
            Transform t0 = t.GetChild(i);
            T t1 = t0.GetComponent<T>();
            if (null != t1)
            {
                gs.Add(t1);
            }
            GetAllChildCmp(t0, gs);
        }
    }

    private string GetUIClassBase(string ui_temp, string uiClassName, GameObject g)
    {
        uiClassName += "Base";
        RemoveSomeCharactor(g.transform);
        string txt = ui_temp.Replace("{class_name}", uiClassName);

        txt = txt.Replace("{ui_name}", g.name);

        string propertys = "\n";
        string funcionts = "\n";
        string inits_txt = "\n";

        HashSet<string> usedNames = new HashSet<string>();
        {
            Grid[] buttons = GetAllChild<Grid>(g);
            foreach (Grid b in buttons)
            {
                if (usedNames.Contains(ProperName(b.name)))
                    continue;
                propertys += "\tpublic Grid " + ProperName(b.name) + ";\n";
                inits_txt += ReplayTips(gridTemp0, b.gameObject);
                inits_txt += ReplayTips(gridFunTemp0, b.gameObject);
                funcionts += ReplayTips(gridFunciontTemp0B, b.gameObject);
                usedNames.Add(ProperName(b.name));
            }
        }

        {
            Dropdown[] buttons = GetAllChild<Dropdown>(g);
            foreach (Dropdown b in buttons)
            {
                if (usedNames.Contains(ProperName(b.name)))
                    continue;
                propertys += "\tpublic Dropdown " + ProperName(b.name) + ";\n";
                inits_txt += ReplayTips(dropDownTemp0, b.gameObject);
                inits_txt += ReplayTips(dropDownFunTemp0, b.gameObject);
                funcionts += ReplayTips(dropDownFunciontTemp0B, b.gameObject);
                usedNames.Add(ProperName(b.name));
            }
        }
        {
            RawImage[] buttons = GetAllChild<RawImage>(g);
            foreach (RawImage b in buttons)
            {
                if (usedNames.Contains(ProperName(b.name)))
                    continue;
                propertys += "\tpublic RawImage " + ProperName(b.name) + ";\n";
                inits_txt += ReplayTips(rawImage0, b.gameObject);
                inits_txt += ReplayTips(rawFunImage0, b.gameObject);
                funcionts += ReplayTips(rawImageFunciontTemp0B, b.gameObject);
                usedNames.Add(ProperName(b.name));
            }
        }
        //public RawImage rawImage;

        {
            ListBar[] buttons = GetAllChild<ListBar>(g);
            foreach (ListBar b in buttons)
            {
                if (usedNames.Contains(ProperName(b.name)))
                    continue;
                propertys += "\tpublic ListBar " + ProperName(b.name) + ";\n";
                inits_txt += ReplayTips(listBarTemp0, b.gameObject);
                inits_txt += ReplayTips(listBarFunTemp0, b.gameObject);
                funcionts += ReplayTips(listBarFunciontTemp0B, b.gameObject);
                usedNames.Add(ProperName(b.name));
            }
        }
        {
            ButtonEX[] buttons = GetAllChild<ButtonEX>(g);
            foreach (ButtonEX b in buttons)
            {
                if (usedNames.Contains(ProperName(b.name)))
                    continue;
                propertys += "\tpublic ButtonEX " + ProperName(b.name) + ";\n";
                inits_txt += ReplayTips(buttomTemp0, b.gameObject);
                inits_txt += ReplayTips(buttonsFunTemp0, b.gameObject);
                funcionts += ReplayTips(buttonsFunciontTemp0B, b.gameObject);
                usedNames.Add(ProperName(b.name));
            }
        }

        


        {
            TextLanguageCtrl[] childs = GetAllChild<TextLanguageCtrl>(g);
            foreach (TextLanguageCtrl b in childs)
            {
                if (usedNames.Contains(ProperName(b.name)))
                    continue;
                if (b.name == "Text")
                    continue;
                propertys += "\tpublic TextLanguageCtrl " + ProperName(b.name) + ";\n";
                inits_txt += ReplayTips(textTemp1, b.gameObject);
                usedNames.Add(ProperName(b.name));
            }
        }
        {
            AdvancedText[] childs = GetAllChild<AdvancedText>(g);
            foreach (AdvancedText b in childs)
            {
                if (usedNames.Contains(ProperName(b.name)))
                    continue;

                propertys += "\tpublic AdvancedText " + ProperName(b.name) + ";\n";
                inits_txt += ReplayTips(textAdvancedTemp0, b.gameObject);
                usedNames.Add(ProperName(b.name));
            }
        }


        {
            Text[] childs = GetAllChild<Text>(g);
            foreach (Text b in childs)
            {
                if (usedNames.Contains(ProperName(b.name)))
                    continue;
                if (b.name == "Placeholder")
                    continue;
                if (b.name.IndexOf('(') > 0)
                    continue;
                if (b.name.IndexOf(')') > 0)
                    continue;
                if (b.gameObject.GetComponent<TextLanguageCtrl>() == null)
                {
                    propertys += "\tpublic Text " + ProperName(b.name) + ";\n";
                    inits_txt += ReplayTips(textTemp0, b.gameObject);
                    usedNames.Add(ProperName(b.name));
                }
                else  
                {
                    propertys += "\tpublic Text " + ProperName(b.name) + ";\n";
                    inits_txt += ReplayTips(textTemp0, b.gameObject);
                    usedNames.Add(ProperName(b.name));
                }
            }
        }
        {
            InputField[] childs = GetAllChild<InputField>(g);
            foreach (InputField b in childs)
            {
                if (usedNames.Contains(ProperName(b.name)))
                    continue;
                propertys += "\tpublic InputField " + ProperName(b.name) + ";\n";
                inits_txt += ReplayTips(inputFieldTemp0, b.gameObject);
                inits_txt += ReplayTips(inputFieldFunTemp0, b.gameObject);
                funcionts += ReplayTips(inputFieldFunciontTemp0B, b.gameObject);
                usedNames.Add(ProperName(b.name));
            }
        }

        {
            Image[] imgs = GetAllChild<Image>(g);
            foreach (Image b in imgs)
            {
                if (usedNames.Contains(ProperName(b.name)))
                    continue;
                propertys += "\tpublic Image " + ProperName(b.name) + ";\n";
                inits_txt += ReplayTips(imageTemp0, b.gameObject);
                usedNames.Add(ProperName(b.name));

            }
        }
        {
            GameObject[] childs = GetAllChild(g);
            foreach (GameObject b in childs)
            {
                if (b.name.EndsWith("_c"))
                {
                    if (b.GetComponent<Image>() != null)
                    {
                        inits_txt += ReplayTips(imageTemp0, b.gameObject);
                    }
                    else
                    {
                        propertys += "\tpublic Transform " + ProperName(b.name) + ";\n";
                        inits_txt += ReplayTips(rectTemp0, b.gameObject);
                    }
                    inits_txt += ReplayTips(clickTemp0, b.gameObject);
                    funcionts += ReplayTips(clickFunctionTemp0B, b.gameObject);
                }
            }
        }

        propertys += "\n";
        propertys += funcionts + "\n";
        string tip0 = "//{propertys_and_function}";
        string tip1 = " //{ui_init}";
        int index = txt.IndexOf(tip0) + tip0.Length;
        txt = txt.Insert(index, propertys);

        int index1 = txt.IndexOf(tip1) + tip1.Length;
        txt = txt.Insert(index1, inits_txt);

        return txt;
    }
    private string GetUIClassSub(string ui_temp, string uiClassName, GameObject g)
    {
        RemoveSomeCharactor(g.transform);
        string txt = ui_temp.Replace("{class_name}", uiClassName);

        txt = txt.Replace("{ui_name}", g.name);

         
        return txt;
    }

   

    private void RemoveSomeCharactor(Transform g)
    {
        g.name = g.name.Replace("(", "").Replace(")","");
        for (int i = 0; i < g.childCount; i++)
        {
            RemoveSomeCharactor(g.GetChild(i));
        }
    }
}
 