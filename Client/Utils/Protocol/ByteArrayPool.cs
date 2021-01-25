using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ByteArrayPool 
{
    static Stack<byte[]> bytes2 = new Stack<byte[]>();
    static Stack<byte[]> bytes4 = new Stack<byte[]>();
    static Stack<byte[]> bytes8 = new Stack<byte[]>();

    public static byte[] GetByte2()
    {
        if (bytes2.Count > 0)
            return bytes2.Pop();
        return new byte[2];
    }
    public static void ReleaseByte2(byte[] byes)
    {
        bytes2.Push(byes);
    }

    public static byte[] GetByte4()
    {
        if (bytes4.Count > 0)
            return bytes4.Pop();
        return new byte[4];
    }
    public static void ReleaseByte4(byte[] byes)
    {
        bytes4.Push(byes);
    }

    public static byte[] GetByte8()
    {
        if (bytes8.Count > 0)
            return bytes8.Pop();
        return new byte[8];
    }
    public static void ReleaseByte8(byte[] byes)
    {
        bytes8.Push(byes);
    }

}
