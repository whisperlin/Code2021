using UnityEngine;
using UnityEditor;
using System.IO;
using System.Xml;
using System;

public class BitmapFontExporter : EditorWindow
{
    [MenuItem("工具/文字/bmFont")]
    private static void CreateFont()
    {
        //ScriptableWizard.DisplayWizard<BitmapFontExporter>("Create Font");

        BitmapFontExporter window = (BitmapFontExporter)EditorWindow.GetWindow(typeof(BitmapFontExporter));
        window.Show();
    }

    void OnGUI()
    {
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);
        fontFile = (TextAsset)EditorGUILayout.ObjectField("bmFont文件", fontFile,typeof(TextAsset),false);

        textureFile = (Texture2D)EditorGUILayout.ObjectField("图片文件", textureFile, typeof(Texture2D), false);

        if (GUILayout.Button("确定"))
        {
            OnWizardCreate();
        }

    }
    public TextAsset fontFile;
    public Texture2D textureFile;

    private void OnWizardCreate()
    {
        if (fontFile == null || textureFile == null)
        {
            return;
        }

        string path = EditorUtility.SaveFilePanelInProject("Save Font", fontFile.name, "", "", @"Assets\Art\Font");

        if (!string.IsNullOrEmpty(path))
        {
            ResolveFont(path);
        }
    }


    private void ResolveFont(string exportPath)
    {
        if (!fontFile) throw new UnityException(fontFile.name + "is not a valid font-xml file");

        Font font = new Font();

        XmlDocument xml = new XmlDocument();
        xml.LoadXml(fontFile.text);

        XmlNode info = xml.GetElementsByTagName("info")[0];
        XmlNodeList chars = xml.GetElementsByTagName("chars")[0].ChildNodes;

        CharacterInfo[] charInfos = new CharacterInfo[chars.Count];

        for (int cnt = 0; cnt < chars.Count; cnt++)
        {
            XmlNode node = chars[cnt];
            CharacterInfo charInfo = new CharacterInfo();

            charInfo.index = ToInt(node, "id");
            charInfo.advance = ToInt(node, "xadvance");

            charInfo.uv = GetUV(node);
            charInfo.vert = GetVert(node);

            charInfos[cnt] = charInfo;
        }


        Shader shader = Shader.Find("UI/Default Font");
        Material material = new Material(shader);
        material.mainTexture = textureFile;
        AssetDatabase.CreateAsset(material, exportPath + ".mat");


        font.material = material;
        font.name = info.Attributes.GetNamedItem("face").InnerText;
        font.characterInfo = charInfos;
         
        string path0 = exportPath + ".fontsettings";
        AssetDatabase.CreateAsset(font, path0);

        TextureImporter t = AssetImporter.GetAtPath(AssetDatabase.GetAssetPath(textureFile)) as TextureImporter;
        if (null != t)
            t.alphaIsTransparency = true;

        AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(textureFile));
         
        string txt = System.IO.File.ReadAllText(path0);

        int m_Descent = txt.IndexOf("m_Descent:");
        if (m_Descent > 0)
        {
            int end = txt.IndexOf('\n', m_Descent);
            txt = txt.Substring(0, m_Descent) + "m_Descent: -" + info.Attributes.GetNamedItem("size").InnerText + txt.Substring(end);
        }
        int m_LineSpacing = txt.IndexOf("m_LineSpacing:");
        if (m_LineSpacing > 0)
        {
            int end = txt.IndexOf('\n', m_LineSpacing);
            txt = txt.Substring(0, m_LineSpacing) + "m_LineSpacing: " + info.Attributes.GetNamedItem("size").InnerText + txt.Substring(end);
        }
        
        System.IO.File.WriteAllText(path0,txt);
 
        EditorUtility.DisplayDialog("保存成功", "保存成功", "确定");
    }


    private Rect GetUV(XmlNode node)
    {
        Rect uv = new Rect();

        uv.x = ToFloat(node, "x") / textureFile.width;
        uv.y = ToFloat(node, "y") / textureFile.height;
        uv.width = ToFloat(node, "width") / textureFile.width;
        uv.height = ToFloat(node, "height") / textureFile.height;
        uv.y = 1f - uv.y - uv.height;

        return uv;
    }


    private Rect GetVert(XmlNode node)
    {
        Rect uv = new Rect();

        uv.x = ToFloat(node, "xoffset");
        uv.y = ToFloat(node, "yoffset");
        uv.width = ToFloat(node, "width");
        uv.height = ToFloat(node, "height");
        uv.y = -uv.y;
        uv.height = -uv.height;

        return uv;
    }


    private int ToInt(XmlNode node, string name)
    {
        return Convert.ToInt32(node.Attributes.GetNamedItem(name).InnerText);
    }


    private float ToFloat(XmlNode node, string name)
    {
        return (float)ToInt(node, name);
    }
}