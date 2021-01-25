using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtocolField  
{
    private FieldType fieldType;//解析的类型	
    private string fieldName;//字段名
    private string comment;//注释
    private int dataLength;//解析变长字符串时，要解析的长度
    private string listDetailType;
    private bool packing;//为true则不生成传输

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
    public int getDataLength()
    {
        return dataLength;
    }
    public void setDataLength(int dataLength)
    {
        this.dataLength = dataLength;
    }
    public string getListDetailType()
    {
        return listDetailType;
    }
    public void setListDetailType(string listDetailType)
    {
        this.listDetailType = listDetailType;
    }
    public bool isPacking()
    {
        return packing;
    }
    public void setPacking(bool packing)
    {
        this.packing = packing;
    }

}
