using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
/**
 * 协议配置文件读取配置(配置文件的setting字段)
 * 
 * @author admin
 * 
 */
public class ProtocolCollection
{

    private int protocolPfx;

    private List<Protocol_Q_A> protocolPackageList = new List<Protocol_Q_A>();

    private List<DefineConst> defineConsts = new List<DefineConst>();

    /**
	 * 从define节点获取常量定义
	 * 
	 * @param pc
	 * @param parseNodes
	 * @param ps
	 */
    public static void parseDefineFromNode(ProtocolCollection pc, XmlNodeList parseNodes, ProtocolSetting ps)
    {
        //XmlElement property = null;
        //NodeList categorySet = null;
        XmlElement element = null;
        for (int i = 0; i < parseNodes.Count; i++)
        {
            element = (XmlElement)parseNodes.Item(i);
            // 获取常量头
            string namePfx = element.GetAttribute("namePfx");

            XmlNodeList fields;
            // 获取提问包
            fields = element.SelectNodes("const");
            for (int j = 0; j < fields.Count; j++)
            {
                DefineConst defineConst = new DefineConst();
                XmlElement f = (XmlElement)fields.Item(j);

                string targetFieldName = namePfx + f.GetAttribute("name");
                string fieldType = f.GetAttribute("fieldType");
                string comString = f.GetAttribute("comment");
                string constValue = f.GetAttribute("value");

                defineConst.setComment(comString);
                defineConst.setConstValue(constValue);
                defineConst.setFieldName(targetFieldName);
                //defineConst.setFieldType(FieldType.valueOf(fieldType));
                defineConst.setFieldType((FieldType)System.Enum.Parse(typeof(FieldType), fieldType));
                pc.defineConsts.Add(defineConst);
            }

            // defineConst.setComment(element.GetAttribute("comment"));
            // defineConst.setComment(element.GetAttribute("comment"));
            // string targetFieldName = f.GetAttribute("fieldName");
            // string fieldType = f.GetAttribute("fieldType");
            // string comString = f.GetAttribute("comment");
            //						
        }

    }

    /**
	 * (配置文件的parse节点)
	 * 
	 * @param defNodes
	 * @return
	 * @throws Exception
	 */
    public static ProtocolCollection parseFromNode(int protocolPfx, XmlNodeList parseNodes, ProtocolSetting ps)
    {
        ProtocolCollection pc = new ProtocolCollection();
        //XmlElement property = null;
        //NodeList categorySet = null;
        XmlElement   element = null;

        pc.protocolPfx = protocolPfx;

		int autoGenerateProtocol = 50000;

		for (int i = 0; i<parseNodes.Count; i++) {
			Protocol_Q_A pp = new Protocol_Q_A();

            element = (XmlElement) parseNodes.Item(i);

            // 提取协议号字符
            string strProtocol = element.GetAttribute("protocol");
            // 提取子协议号
            int parseProtocol;

			if (strProtocol.ToLower()=="auto") {
				parseProtocol = autoGenerateProtocol;
				autoGenerateProtocol++;
			} else {
				parseProtocol = int.Parse(element.GetAttribute("protocol"));
				if ( parseProtocol< 1 || parseProtocol> 49999) {
					throw new System.Exception("key 'protocol' must be between 1-49999");
				}
			}
			// 根据前缀计算真正协议号(提问协议)
			pp.setProtocol((protocolPfx << 16) + parseProtocol);

			// 提取协议注释
			pp.setComment(element.GetAttribute("comment"));
			pp.setClassName(element.GetAttribute("className"));
			pp.setSpringBeanName(element.GetAttribute("springBeanName"));
			pp.setMethodName(element.GetAttribute("methodName"));

			string compress = element.GetAttribute("compress");
            string protocolType = element.GetAttribute("protocolType");

			if (compress == null || compress.Length==0) {
				pp.setCompress(ps.getDefaultCompress());
			} else {
				pp.setCompress(int.Parse(compress));
			}

			if (protocolType == null || protocolType.Length==0) {
				pp.setProtocolType(ps.getDefaultProtocolType());
			} else {
				pp.setProtocolType(int.Parse(protocolType));
			}

			string encryptTypeUp = element.GetAttribute("encryptTypeUp");
			if(encryptTypeUp == null || encryptTypeUp.Length==0){
				pp.setEncryptTypeUp(ps.getDefaultEncryptTypeUp());
			}else{
				pp.setEncryptTypeUp(int.Parse(encryptTypeUp));
			}
			
			string encryptTypeDown = element.GetAttribute("encryptTypeDown");
			if(encryptTypeDown == null || encryptTypeDown.Length==0){
				pp.setEncryptTypeDown(ps.getDefaultEncryptTypeDown());
			}else{
				pp.setEncryptTypeDown(int.Parse(encryptTypeDown));
			}

            XmlNodeList fields;
            // 获取提问包
            fields = element.SelectNodes("q");
			for (int j = 0; j<fields.Count; j++) {
				ProtocolField pf = new ProtocolField();
                XmlElement f = (XmlElement)fields.Item(j);
                string targetFieldName = f.GetAttribute("fieldName");
                string fieldType = f.GetAttribute("fieldType");
                string comString = f.GetAttribute("comment");
                string listDetailType = f.GetAttribute("listDetailType");
                string packing = f.GetAttribute("packing");
                int len = SysUtil.strToIntDef(f.GetAttribute("length"), 0);
                pf.setFieldName(targetFieldName);
                pf.setFieldType((FieldType)System.Enum.Parse(typeof(FieldType), fieldType));
                //pf.setFieldType(FieldType.valueOf(fieldType));
				pf.setListDetailType(listDetailType);
				pf.setComment(comString);
				pf.setDataLength(len);
				if(packing == null || packing.Length == 0){
					pf.setPacking(true);
				}else{
					pf.setPacking(packing != "false");
				}
				pp.getQuestionFields().Add(pf);
			}
			// 获取回答包
			fields = element.SelectNodes("a");
			for (int j = 0; j<fields.Count; j++) {
				ProtocolField pf = new ProtocolField();
                XmlElement f = (XmlElement)fields.Item(j);
                string targetFieldName = f.GetAttribute("fieldName");
                string fieldType = f.GetAttribute("fieldType");
                string comString = f.GetAttribute("comment");
                string listDetailType = f.GetAttribute("listDetailType");
                string packing = f.GetAttribute("packing");
                int len = SysUtil.strToIntDef(f.GetAttribute("length"), 0);
                pf.setFieldName(targetFieldName);
                pf.setFieldType((FieldType)System.Enum.Parse(typeof(FieldType), fieldType));
                //pf.setFieldType(FieldType.valueOf(fieldType));
				pf.setComment(comString);
				pf.setListDetailType(listDetailType);
				pf.setDataLength(len);
				if(packing == null || packing.Length==0){
					pf.setPacking(true);
				}else{
					pf.setPacking(packing != "false");
				}
				pp.getAnwserFields().Add(pf);
			}

			// 把包加入
			pc.protocolPackageList.Add(pp);
		}

		return pc;
	}

	public int getProtocolPfx()
    {
        return protocolPfx;
    }

    public void setProtocolPfx(int protocolPfx)
    {
        this.protocolPfx = protocolPfx;
    }

    public List<Protocol_Q_A> getProtocolPackageList()
    {
        return protocolPackageList;
    }

    public void setProtocolPackageList(List<Protocol_Q_A> protocolPackageList)
    {
        this.protocolPackageList = protocolPackageList;
    }

    public List<DefineConst> getDefineConsts()
    {
        return defineConsts;
    }

    public void setDefineConsts(List<DefineConst> defineConsts)
    {
        this.defineConsts = defineConsts;
    }

}