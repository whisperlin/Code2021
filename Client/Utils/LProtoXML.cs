using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class LProtoXML :  ProtoXML
{
    public XmlDocument LoadFile()
    {
        XmlDocument doc = new XmlDocument();

  

#if  UNITY_EDITOR
        string xmlStr =   Application.dataPath + "/EditorTemp/protocol_main.xml";
#else
        string xmlStr ="";
#endif
        string xmlText = System.IO.File.ReadAllText(xmlStr);
        doc.LoadXml(xmlText);

        return doc;
    }
}
