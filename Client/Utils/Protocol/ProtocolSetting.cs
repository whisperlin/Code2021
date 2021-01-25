
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using UnityEngine;

public class ProtocolSetting  
{
    /**
	 * 包头长度
	 */
    private  const int PACKAGE_HEADER_SIZE = 4;
    private string javaPackage;
    private string javaBasePoImport;
    private string javaGenerateDir;
    private string flashPackage;
    private string flashBasePoImport;
    private string flashGenerateDir;
    private string cppPackage;
    private string cppBasePoImport;
    private string cppGenerateDir;

    private string questionPackageFormat;
    private string answerPackageFormat;

    private string packageHeaderReq;
    private byte[] packageHeaderReqBytes;

    private string packageHeaderRes;
    private byte[] packageHeaderResBytes;

    private string packageType;

    //<!-- compress 默认压缩方式 -->
    private int defaultCompress;
    private int defaultProtocolType;
    //<!-- compressType 默认传输包类型 -->	

    //<!-- 默认加密方式1为加密，0为不加密 -->
    private int defaultEncryptTypeUp;
    private int defaultEncryptTypeDown;


    // Start is called before the first frame update
    public static ProtocolSetting loadFromXml(string configFile)  
    {
        TextAsset o1 = Resources.Load<TextAsset>("protocol_main");
        /*var o = Resources.Load<TextAsset>(configFile);
        configFile = GameConifg.PersistentDataPath + "/"+configFile;
        if (!System.IO.File.Exists(configFile))
        {
            throw new System.Exception("读取配置文件" + configFile + "错误");
        }
        string xmlText = System.IO.File.ReadAllText(configFile);*/
        string xmlText = o1.text;
        XmlDocument doc = new XmlDocument();
        
        doc.LoadXml(xmlText);
        
        XmlNode root = doc.SelectSingleNode("gamePrococol-config");
        XmlNode settingNodes = root.SelectSingleNode("setting");
        if (settingNodes == null)
        {
            throw new System.Exception("没法读取协议配置文件");
        }

         
        return ProtocolSetting.parseFromNode(settingNodes);

    }

    private static ProtocolSetting parseFromNode(XmlNode settingNodes)
    {
        ProtocolSetting ps = new ProtocolSetting();
        XmlNodeList _sn = settingNodes.ChildNodes;
        XmlElement element;
        XmlElement property;
        //XmlElement categorySet;
        if (_sn.Count > 0)
        {
            element = (XmlElement)_sn.Item(0);
            property = (XmlElement)settingNodes.SelectSingleNode("java");
            if (property.HasAttribute("package"))
            {
                ps.javaPackage = property.GetAttribute("package");
            }
            // 把namespace的最后的点去掉，以免重复
            if (ps.javaPackage.EndsWith("."))
            {
                ps.javaPackage = ps.javaPackage.Substring(0, ps.javaPackage.Length - 1);
            }

            ps.javaBasePoImport = property.GetAttribute("BasePoImport");
            if (!ps.javaBasePoImport.EndsWith(";")) ps.javaBasePoImport += ";";

            ps.javaGenerateDir = property.GetAttribute("GenerateDir");
            if (!ps.javaGenerateDir.EndsWith("\\")) ps.javaGenerateDir += "\\";

            property = (XmlElement)settingNodes.SelectSingleNode("flash");
            if (property != null && property.HasAttribute("package"))
            {
                ps.flashPackage = property.GetAttribute("package");
                // 把namespace的最后的点去掉，以免重复
                if (ps.flashPackage.EndsWith("."))
                {
                    ps.flashPackage = ps.flashPackage.Substring(0, ps.flashPackage.Length - 1);
                }

                ps.flashBasePoImport = property.GetAttribute("BasePoImport");
                if (!ps.flashBasePoImport.EndsWith(";")) ps.flashBasePoImport += ";";

                ps.flashGenerateDir = property.GetAttribute("GenerateDir");
                if (!ps.flashGenerateDir.EndsWith("\\")) ps.flashGenerateDir += "\\";
            }

            // 读cpp
 
            property = (XmlElement)settingNodes.SelectSingleNode("cpp");
            if (property != null && property.HasAttribute("package"))
            {

                ps.cppPackage = property.GetAttribute("package");

                // 把namespace的最后的点去掉，以免重复
                if (ps.cppPackage.EndsWith("."))
                {
                    ps.cppPackage = ps.cppPackage.Substring(0, ps.cppPackage.Length - 1);
                }

                ps.cppBasePoImport = property.GetAttribute("BasePoImport");
                if (!ps.cppBasePoImport.EndsWith(";")) ps.cppBasePoImport += ";";

                ps.cppGenerateDir = property.GetAttribute("GenerateDir");
                if (!ps.cppGenerateDir.EndsWith("\\")) ps.cppGenerateDir += "\\";
            }

            property = (XmlElement)settingNodes.SelectSingleNode("packageHeaderReq");
            ps.packageType = property.GetAttribute("type");
            ps.packageHeaderReq = property.GetAttribute("code").Replace("\\\\r", "\r").Replace("\\\\n", "\n");

            try
            {
                ps.packageHeaderReqBytes = Encoding.UTF8.GetBytes(ps.packageHeaderReq);
            }
            catch (System.Exception e)
            {
                Debug.LogError(e.ToString());
            }

            property = (XmlElement)settingNodes.SelectSingleNode("packageHeaderRes");
            ps.packageType = property.GetAttribute("type");
            ps.packageHeaderRes = property.GetAttribute("code").Replace("\\\\r", "\r").Replace("\\\\n", "\n");
            //把包头处理成字节流						
            try
            {
                ps.packageHeaderResBytes = Encoding.UTF8.GetBytes(ps.packageHeaderRes);
            }
            catch (System.Exception e)
            {
                Debug.LogError(e.ToString());
            }


            // 读Question包格式 questionPackageFormat
  
            property = (XmlElement)settingNodes.SelectSingleNode("questionPackageFormat");
            ps.questionPackageFormat = property.InnerText;
            // 读Answer包格式 answerPackageFormat
 

            property = (XmlElement)settingNodes.SelectSingleNode("answerPackageFormat");
            ps.answerPackageFormat = property.InnerText;


            property = (XmlElement)settingNodes.SelectSingleNode("defaultCompress");
            ps.defaultCompress =  int.Parse( property.InnerText);


            property = (XmlElement)settingNodes.SelectSingleNode("defaultProtocolType");
            ps.defaultProtocolType = int.Parse(property.InnerText);


            property = (XmlElement)settingNodes.SelectSingleNode("defaultEncryptTypeUp");
            ps.defaultEncryptTypeUp = int.Parse(property.InnerText);


            property = (XmlElement)settingNodes.SelectSingleNode("defaultEncryptTypeDown");
            ps.defaultEncryptTypeDown = int.Parse(property.InnerText);

            
        }

        return ps;
    }


    public string getJavaPackage()
    {
        return javaPackage;
    }

    public string getJavaBasePoImport()
    {
        return javaBasePoImport;
    }

    public string getJavaGenerateDir()
    {
        return javaGenerateDir;
    }

    public string getFlashPackage()
    {
        return flashPackage;
    }

    public string getFlashBasePoImport()
    {
        return flashBasePoImport;
    }

    public string getFlashGenerateDir()
    {
        return flashGenerateDir;
    }

    public string getCppPackage()
    {
        return cppPackage;
    }

    public void setCppPackage(string cppPackage)
    {
        this.cppPackage = cppPackage;
    }

    public string getCppBasePoImport()
    {
        return cppBasePoImport;
    }

    public void setCppBasePoImport(string cppBasePoImport)
    {
        this.cppBasePoImport = cppBasePoImport;
    }

    public string getCppGenerateDir()
    {
        return cppGenerateDir;
    }

    public void setCppGenerateDir(string cppGenerateDir)
    {
        this.cppGenerateDir = cppGenerateDir;
    }

    public string getQuestionPackageFormat()
    {
        return questionPackageFormat;
    }

    public string getAnswerPackageFormat()
    {
        return answerPackageFormat;
    }

    public string getPackageType()
    {
        return packageType;
    }


    public int getDefaultCompress()
    {
        return defaultCompress;
    }

    public void setDefaultCompress(int defaultCompress)
    {
        this.defaultCompress = defaultCompress;
    }

    public int getDefaultProtocolType()
    {
        return defaultProtocolType;
    }

    public void setDefaultProtocolType(int defaultProtocolType)
    {
        this.defaultProtocolType = defaultProtocolType;
    }

    public int getDefaultEncryptTypeUp()
    {
        return defaultEncryptTypeUp;
    }

    public void setDefaultEncryptTypeUp(int defaultEncryptTypeUp)
    {
        this.defaultEncryptTypeUp = defaultEncryptTypeUp;
    }

    public int getDefaultEncryptTypeDown()
    {
        return defaultEncryptTypeDown;
    }

    public void setDefaultEncryptTypeDown(int defaultEncryptTypeDown)
    {
        this.defaultEncryptTypeDown = defaultEncryptTypeDown;
    }

    public string getPackageHeaderReq()
    {
        return packageHeaderReq;
    }

    public void setPackageHeaderReq(string packageHeaderReq)
    {
        this.packageHeaderReq = packageHeaderReq;
    }

    public byte[] getPackageHeaderReqBytes()
    {
        return packageHeaderReqBytes;
    }

    public void setPackageHeaderReqBytes(byte[] packageHeaderReqBytes)
    {
        this.packageHeaderReqBytes = packageHeaderReqBytes;
    }

    public string getPackageHeaderRes()
    {
        return packageHeaderRes;
    }

    public void setPackageHeaderRes(string packageHeaderRes)
    {
        this.packageHeaderRes = packageHeaderRes;
    }

    public byte[] getPackageHeaderResBytes()
    {
        return packageHeaderResBytes;
    }

    public void setPackageHeaderResBytes(byte[] packageHeaderResBytes)
    {
        this.packageHeaderResBytes = packageHeaderResBytes;
    }
}
