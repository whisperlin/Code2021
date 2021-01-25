using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protocol_Q_A
{
    private int protocol;
    private string comment;
    private string className;
    private string springBeanName;
    private string methodName;//对应处理的方法名称
    private int compress;
    private int protocolType;
    private int encryptTypeUp;
    private int encryptTypeDown;

    private List<ProtocolField> questionFields = new List<ProtocolField>();
    private List<ProtocolField> anwserFields = new List<ProtocolField>();


    public string formatClassName(string formatStr)
    {
        return formatStr.Replace("%", className);
    }

    public int getProtocol()
    {
        return protocol;
    }
    public void setProtocol(int protocol)
    {
        this.protocol = protocol;
    }
    public string getComment()
    {
        return comment;
    }
    public void setComment(string comment)
    {
        this.comment = comment;
    }
    public List<ProtocolField> getQuestionFields()
    {
        return questionFields;
    }
    public void setQuestionFields(List<ProtocolField> questionFields)
    {
        this.questionFields = questionFields;
    }
    public List<ProtocolField> getAnwserFields()
    {
        return anwserFields;
    }
    public void setAnwserFields(List<ProtocolField> anwserFields)
    {
        this.anwserFields = anwserFields;
    }
    public string getClassName()
    {
        return className;
    }
    public void setClassName(string className)
    {
        this.className = className;
    }
    public string getSpringBeanName()
    {
        return springBeanName;
    }
    public void setSpringBeanName(string springBeanName)
    {
        this.springBeanName = springBeanName;
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

    public int getEncryptTypeUp()
    {
        return encryptTypeUp;
    }

    public void setEncryptTypeUp(int encryptTypeUp)
    {
        this.encryptTypeUp = encryptTypeUp;
    }

    public int getEncryptTypeDown()
    {
        return encryptTypeDown;
    }

    public void setEncryptTypeDown(int encryptTypeDown)
    {
        this.encryptTypeDown = encryptTypeDown;
    }
}