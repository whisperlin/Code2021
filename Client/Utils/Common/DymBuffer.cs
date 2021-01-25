using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class DymBuffer 
{
    public int size = 10;

    public int startIndex = 0;
    int endIndex = 0;
    int count = 0;
    byte[] conatin;
 
    public int Count
    {
        get { return count; }
    }
    public DymBuffer(int size = 0)
    {
        conatin = new byte[size];
        this.size = conatin.Length;
    }

    void Copy(byte[] data, int c)
    {
 
        int len0 = size - endIndex;
        if (len0 >= c)
        {
            System.Array.Copy(data, 0, conatin, endIndex, c);
        }
        else
        {
            int len2 = c - len0;
            System.Array.Copy(data, 0, conatin, endIndex, len0);
            System.Array.Copy(data, len0, conatin, 0, len2);
        }
        count += c;
        endIndex += c;
        endIndex %= size;


    }
    public void Add(string text)
    {
        var buffer = Encoding.UTF8.GetBytes(text);
        Add(buffer, buffer.Length);
    }
    public void Add(byte[] data, int c)
    {
        if (size - count <= c)
        {
           byte [] bs = new byte[size+c];
           int c1 = ReadAll(bs,0);
           conatin = bs;
           startIndex = 0;
           endIndex = c1;
           count = c1;
            this.size = conatin.Length;
        }
        Copy(data, c);
    }

    public int ReadAll(byte [] outTemp,int index)
    {
        return Read(outTemp,index,count);
    }

    public string ReadAll()
    {
        byte[] outTemp = new byte[2048];
        int c =  Read(outTemp, 0, 2048);

        string str = Encoding.UTF8.GetString(outTemp, 0, c);
        return str;
    }
    public int Read(byte[] outTemp, int index, int c)
    {
        if (c > count)
            c = count;
        for (int i = 0; i < c; i++)
        {
            outTemp[index++] = conatin[startIndex++];
            startIndex %= size;
        }
        count -= c;
        return c;
    }
    
    public int Read(byte[] outTemp )
    {
        return Read(outTemp,0, outTemp.Length);
    }

    public byte ReadByte()
    {
        if (count <1)
            return 0;
        byte ret =  conatin[startIndex++];
        startIndex %= size;
        count--;
        return ret;
    }

    public void Move(int c)
    {
        if (c > count)
            c = count;
        startIndex += c;
        startIndex %= size;
        count -= c;
 


    }
    public byte LookByte()
    {
        if (count < 1)
            return 0;
        return conatin[startIndex];
    }
    public byte LookByte(int index)
    {
        if (count < 1+ index)
            return 0;
        return conatin[(startIndex + index) % size];
    }


    public int GetByte(int start ,byte[] outTemp, int index, int c)
    {
        start = startIndex + start;
        start %= size;
        int oldStartIndex = startIndex;
 
        for (int i = 0; i < c; i++)
        {
            outTemp[index++] = conatin[start++];
            start %= size;
        }
 
        return c;
    }
    public int GetByte(int start,byte[] outTemp )
    {
        return GetByte(start,outTemp, 0,outTemp.Length);
    }




}
