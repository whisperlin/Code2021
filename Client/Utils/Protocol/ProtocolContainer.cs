using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtocolContainer 
{
    private List<ProtocolField> parsetList = new List<ProtocolField>(); // 从XML配置文件获得要解析的属性
    private int protocol;// 从XML配置文件获得要解析的消息类型
    private string subPackageName;//所属子包
    private string className;//包类名
    private string nameSpaceClass;// 消息要转换的VO
    private string springBeanName;//对应Spring的事务
    private string comment;//注释
    private string methodName;//对应处理的方法名称
    private int compress = 0;
    private int protocolType = PackageUtil.msgType_AMF;

    // spring bean name
    public List<ProtocolField> getParsetList()
    {
        return parsetList;
    }

    public void setParsetList(List<ProtocolField> parsetList)
    {
        this.parsetList = parsetList;
    }

    public int getParseProtocol()
    {
        return protocol;
    }

    public void setParseProcotol(int parseProtocol)
    {
        this.protocol = parseProtocol;
    }

    public string getNameSpaceClass()
    {
        return nameSpaceClass;
    }

    public void setNameSpaceClass(string nameSpaceClass)
    {
        this.nameSpaceClass = nameSpaceClass;
    }

    public string getSpringBeanName()
    {
        return springBeanName;
    }

    public void setSpringBeanName(string springBeanName)
    {
        this.springBeanName = springBeanName;
    }

    public string getSubPackageName()
    {
        return subPackageName;
    }

    public void setSubPackageName(string subPackageName)
    {
        this.subPackageName = subPackageName;
    }

    public string getComment()
    {
        return comment;
    }

    public void setComment(string comment)
    {
        this.comment = comment;
    }

    public string getClassName()
    {
        return className;
    }

    public void setClassName(string className)
    {
        this.className = className;
    }

    public string getMethodName()
    {
        return methodName;
    }

    public void setMethodName(string methodName)
    {
        this.methodName = methodName;
    }

    public int getCompress()
    {
        return compress;
    }

    public void setCompress(int compress)
    {
        this.compress = compress;
    }

    public int getProtocolType()
    {
        return protocolType;
    }

    public void setProtocolType(int protocolType)
    {
        this.protocolType = protocolType;
    }
}
