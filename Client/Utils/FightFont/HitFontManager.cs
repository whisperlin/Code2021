using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

#if UNITY_EDITOR


using UnityEditor;


[CustomEditor(typeof(HitFontManager))]
public class HitFontManagerGUI : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        if (GUILayout.Button("测试"))
        {
            if (Application.isPlaying)
            {

                HitFontManager fm = (HitFontManager)target;
                fm.gameObject.SetActive(true);

                fm.CreateFont(fm.testIndex, fm.testValue/*Random.Range(1, 3000)*/, Vector3.zero);
            }
            else
            {
                Debug.LogError("请运行起来");
            }
                
        }
    }
}
#endif

    //BMP Font上一个文字的uv信息
    public class FontItem
{
    public Vector2 uv0;
    public Vector2 uv1;
    public float width;
    public float height;
}

[System.Serializable]
public class SceenFontData
{
    [Label("文字描述文件")]
    public TextAsset text;
    [Label("美术编辑完的预制,包含(FontMesh)")]
    public FontMesh fontMesh;
    public Material mat;
    [System.NonSerialized]
    public Dictionary<int, FontItem> fonts = new Dictionary<int, FontItem>();
    [System.NonSerialized]
    public SimplePool<FontMesh> pools = new SimplePool<FontMesh>();

    public FontMesh CreateFontMesh()
    {
        return GameObject.Instantiate<FontMesh>(fontMesh);
    }

}
public class HitFontManager : MonoBehaviour
{
    
    public static HitFontManager globalMgr;
    public SceenFontData[] fonts;
    [Label("存放的跟节点")]
    public Transform root;

    public Vector3 scale = Vector3.one;
#if UNITY_EDITOR
    [Label("测试索引")]
    public int testIndex = 0;
    public int testValue = 10;
#endif

    public Camera cam;
    //public Mesh mesh;

    // Use this for initialization
    void Start()
    {
        globalMgr = this;
        for (int i = 0; i < fonts.Length; i++)
        {
            var font = fonts[i];
            if (font.text == null || null == font.fontMesh)
                continue;
 
            font.pools.createHandle = font.CreateFontMesh;

            float scaleW = 0f;
            float scaleH = 0f;
            string xmlData = font.text.text;
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(xmlData);
            XmlNode root = xml.SelectSingleNode("font");
            XmlNodeList xmlNodeList = root.SelectSingleNode("chars").ChildNodes;

            XmlElement com = root.SelectSingleNode("common") as XmlElement;
            scaleW = System.Convert.ToSingle(com.GetAttribute("scaleW"));
            scaleH = System.Convert.ToSingle(com.GetAttribute("scaleH"));

            foreach (var o in xmlNodeList)
            {
                if (o is XmlElement)
                {
                    XmlElement xl1 = (XmlElement)o;
                   
                    int _id = System.Convert.ToInt32(xl1.GetAttribute("id"));
                    float _x = System.Convert.ToSingle(xl1.GetAttribute("x"));
                    float _y = System.Convert.ToSingle(xl1.GetAttribute("y"));
                    float _width = System.Convert.ToSingle(xl1.GetAttribute("width"));
                    float _height = System.Convert.ToSingle(xl1.GetAttribute("height"));

                    FontItem _font = new FontItem();
                    _font.uv0 = new Vector2(_x / scaleW, _y / scaleH);
                    _font.uv1 = _font.uv0 + new Vector2(_width / scaleW, _height / scaleH);
                    _font.width = _width;
                    _font.height = _height;
                    font.fonts[_id] = _font;
                    //Debug.LogError("id = "+ _id);
                }
                /*else
                {
                    Debug.LogError(o);
                }*/
               
            }
        }
    }

    public void CreateFont(int type, int value,Vector3 pos)
    {
        FontMesh mf =  fonts[type].pools.Get();
        if(null != cam)
            mf.cam = cam.transform;
        mf.SetValue(value, fonts[type].fonts);
        mf.pools = fonts[type].pools;
        mf.ResetFont();
        mf.transform.parent = root;
        mf.transform.localPosition = pos;
        mf.gameObject.SetActive(true);
        mf.transform.localScale = scale;

    }


}
 