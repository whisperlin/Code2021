using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
/**
 * 加载配置文件
 * 
 * @author Seraph
 * 
 */
public class ConfigParser
{

  

	/**
	 * 加载配置文件
	 * 
	 * @param path 文件名
	 * @return
	 * @throws Exception
	 */
	public static Dictionary<int, ProtocolContainer> readFromProtocolConfig(string configFile, string subPackageName, ProtocolSetting ps, int protocolPfx)
    {

        TextAsset o1 = Resources.Load<TextAsset>("protocol_main");
 
        string xmlText = o1.text;
        XmlDocument doc = new XmlDocument();
        try
        {
            doc.LoadXml(xmlText);
        }
        catch (System.Exception e)
        {
            UnityEngine.Debug.LogError(e.ToString());
        }
        Dictionary<int, ProtocolContainer> r = null;
        try
        {
            r = parse(doc, subPackageName, ps, protocolPfx);
        }
        catch (System.Exception e)
        {
            UnityEngine.Debug.LogError(e.ToString());
        }

        return r;
        
    }

	/**
	 * 读取传输VO包(PO)
	 * 
	 * @param stream
	 * @return
	 * @throws Exception
	 */
	protected static Dictionary<int, ProtocolContainer> parse(XmlDocument doc, string subPackageName, ProtocolSetting ps, int protocolPfx)
    {
        Dictionary<int, ProtocolContainer> map = new Dictionary<int, ProtocolContainer>();

		// 检查协议前缀范围
		if (protocolPfx< 0 || protocolPfx> 4095) {
			throw new System.Exception(
				"import Protocol Xml must be have 'protocolPfx' code between 1 - 4095");
		}

        XmlNode root = doc.SelectSingleNode("gamePrococol-config");
 
		XmlElement element = null;

		// 把namespace的最后的点去掉，以免重复
		if (subPackageName.EndsWith(".")) subPackageName = subPackageName.Substring(0,
			subPackageName.Length - 1);

		string originalPackageName = ps.getJavaPackage();
		//string basePoImport = ps.getJavaBasePoImport();

		// 检查是否配置好javaPackage路径与flashPackage路径
		if ((originalPackageName.Length < 1)) {
			throw new System.IO.IOException(
				"Error default setting，have not 'javaPackage' and 'flashPackage' roots! [seraph notice]");
		}

        XmlNodeList pcNodes = root.SelectNodes("parse");
        //NodeList pcNodes = root.getElementsByTagName("parse");
        ProtocolCollection pc = ProtocolCollection.parseFromNode(protocolPfx, pcNodes, ps);

		foreach (Protocol_Q_A pp in pc.getProtocolPackageList()) {
			// 创建协议保存容器
			ProtocolContainer containerQuestion = new ProtocolContainer();

        string classNameQ = pp.formatClassName(ps.getQuestionPackageFormat());
        string classNameA = pp.formatClassName(ps.getAnswerPackageFormat());

        string nameSpaceClass;
        string beanName = pp.getSpringBeanName();
        string comment = pp.getComment();
        string writeSubPackageName = subPackageName;

		// 写
		if (subPackageName.Length > 0) {
			nameSpaceClass = originalPackageName + "." + subPackageName + "." + classNameQ;
		} else {
			nameSpaceClass = originalPackageName + "." + pp.getClassName();
			writeSubPackageName = "default";
		}

		containerQuestion.setClassName(classNameQ);
		containerQuestion.setSubPackageName(writeSubPackageName);
		containerQuestion.setParseProcotol(pp.getProtocol());
		containerQuestion.setNameSpaceClass(nameSpaceClass);
		containerQuestion.setSpringBeanName(beanName);
		containerQuestion.setComment(comment);
		containerQuestion.setMethodName(pp.getMethodName());
		// 把整个列表给容器
		containerQuestion.setParsetList(pp.getQuestionFields());

		if (map.ContainsKey(containerQuestion.getParseProtocol())) {
			throw new System.Exception("有键值相同了，相同的是:" + subPackageName + "->"
								+ containerQuestion.getClassName() + ",protocol:"
								+ containerQuestion.getParseProtocol());
		}
		// 把容器加入哈希表
		if(pp.getQuestionFields().Count > 0){
			map[containerQuestion.getParseProtocol()] =  containerQuestion;
		}

		// 检测此包有没有对应的回复包
		if (pp.getAnwserFields().Count > 0) {
			ProtocolContainer containerAnswer = new ProtocolContainer();

			// 写
			if (subPackageName.Length > 0) {
				nameSpaceClass = originalPackageName + "." + subPackageName + "." + classNameA;
			} else {
				nameSpaceClass = originalPackageName + "." + classNameA;
				writeSubPackageName = "default";
			}

			containerAnswer.setClassName(classNameA);
			containerAnswer.setSubPackageName(writeSubPackageName);
			containerAnswer.setParseProcotol(-pp.getProtocol());
			containerAnswer.setNameSpaceClass(nameSpaceClass);
			containerAnswer.setSpringBeanName(beanName);
			containerAnswer.setComment(comment);
			containerAnswer.setMethodName(pp.getMethodName());
			// 把整个列表给容器
			containerAnswer.setParsetList(pp.getAnwserFields());

			if (map.ContainsKey(containerAnswer.getParseProtocol())) {
				throw new System.Exception("有键值相同了，相同的是:" + subPackageName + "->"
					+ containerAnswer.getClassName() + ",protocol:"
					+ containerAnswer.getParseProtocol());
			}
			// 把容器加入哈希表
			map[containerAnswer.getParseProtocol()]= containerAnswer;
		}

		}

		// 查找要从其他XML设定文件导入的文件名
		XmlNodeList importNodes = root.SelectNodes("import");
		for (int i = 0; i<importNodes.Count; i++) {
			element = (XmlElement) importNodes.Item(i);
            // string voPackage = elem.getAttribute("voPackage");
            string _subPackageName = element.GetAttribute("subPackageName");

			if (_subPackageName == null || _subPackageName.Length ==0) {
				throw new System.IO.IOException("can not found key 'subPackageName' from the node 'import'");
			}

			int _protocolPfx = int.Parse(element.GetAttribute("protocolPfx"));
			string configFileName = element.GetAttribute("configFileName");
            Dictionary<int, ProtocolContainer> importMap = readFromProtocolConfig(configFileName,
            _subPackageName, ps, _protocolPfx);

            foreach (var kv in  importMap)
            {
                map[kv.Key] = kv.Value;
            }
		}

		return map;

	}
}
