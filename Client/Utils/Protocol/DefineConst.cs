using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 配置文件定义服务器客户端公用常量表字段
 * @author Seraph.Yang
 *
 */
public class DefineConst
{


    private FieldType fieldType;//解析的类型
    private string fieldName;//字段名
    private string comment;//注释
    private string constValue;//常量的值

    public FieldType getFieldType()
    {
        return fieldType;
    }
    public void setFieldType(FieldType fieldType)
    {
        this.fieldType = fieldType;
    }
    public string getFieldName()
    {
        return fieldName;
    }
    public void setFieldName(string fieldName)
    {
        this.fieldName = fieldName;
    }
    public string getComment()
    {
        return comment;
    }
    public void setComment(string comment)
    {
        this.comment = comment;
    }

    public string getConstValue()
    {
        return constValue;
    }
    public void setConstValue(string constValue)
    {
        this.constValue = constValue;
    }

}