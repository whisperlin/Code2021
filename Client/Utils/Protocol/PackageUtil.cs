using com.hbt.protocol.po;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
 

public class PackageUtil  
{
    /**
	 * 公共执行结果：未知
	 */
    public const int RES_GENERAL_UNKNOW = 0x0;

    /**
	 * 公共执行结果：成功
	 */
    public const int RES_GENERAL_SUCCESSED = 0x1;

    /**
	 * 公共执行结果：失败
	 */
    public const int RES_GENERAL_FAILED = 0x2;

    /**
	 * 公共执行结果：没权限
	 */
    public const int RES_GENERAL_UNKNOWERROR = 0x10000000;

    /**
	 * 公共执行结果：没权限
	 */
    public const int RES_GENERAL_IMPERMISSIBLITY = 0x70000000;

    /**
	 * 公共执行结果：停止错误
	 */
    public const uint RES_GENERAL_STOP = 0x80000000;

    public const int msgType_AMF = 1;// 消息类型属AMF格式

    public const int msgType_Ages_Protocol = 2;// 消息类型是我们自定义的协议格式

    public const int msgType_3GUU_Protocol = 3;// 消息类型是我们自定义的协议格式	
                                                      /**
                                                       * 包头标识
                                                       */
    private  static byte[] headPfx = new byte[] { (byte) 0xFF,
             0xEE, (byte) 'p', (byte) 'v', (byte) 'o', (byte) '1',
            (byte) '0', (byte) '0' };

    /**
	 * 包结束标记
	 */
    private static byte[] etx = new byte[] { 0xFF, 0xEE };

    /**
	 * 包头大小:注意改变包头时候必须同步修改
	 */

    private const int headPfxSize = 8;

    /**
	 * 包结束标记大小:注意改变包头时候必须同步修改
	 */

    private const int headEtxSize = 2;


    private const int verifyCodeLength = 8;

    /**
	 * 跟踪代码
	 */

    private int traceNumber;

    /**
	 * 头部
	 */
    protected byte[] headerBuf;

    /**
	 * 头部大小
	 */

    private const int headerSize = 16;

    /**
	 * 长整型最长size
	 */

    private const int TYPE_LONG_MAX_SIZE = 20;

    /**
	 * 字符串最长size
	 */
    private const int TYPE_STRING_MAX_SIZE = 10240;


    /**
	 * 获取协议子代码
	 * 
	 * @param protocol
	 * @return
	 */
    public static int getProtocolSubCode(int protocol)
    {
        return UnityEngine.Mathf.Abs(protocol) & 0x0000FFFF;
    }


    /**
	 * 获取协议类代码
	 * 
	 * @param protocol
	 * @return
	 */
    public static int getProtocolPfxCode(int protocol)
    {
        // int x = ( UnityEngine.Mathf.Abs(protocol) & 0x0FFF0000);
        // x = x >> 16;
        // return x;
        return (UnityEngine.Mathf.Abs(protocol) & 0x0FFF0000) >> 16;
    }

     

     

    /**
     * 检查包头
     * 
     * @param bytes
     * @return
     */
    public static bool checkPackageHeader(byte[] bytes)
    {
        bool flag = true;
        for (int i = 0; i < bytes.Length; i++)
        {
            if (bytes[i] != headPfx[i])
            {
                flag = false;
                break;
            }
        }
        return flag;
    }


    public static void SetFields(System.Object  arg, string name, Object value)
    {
        var a = arg.GetType().GetField("_name",
                BindingFlags.Instance | BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.ExactBinding);
        a.SetValue(arg, value);

    }
    /**
     * 利用暴力反射把值晒到对象之中
     * 
     * @param obj
     * @param parseField
     * @param value
     */
    public static void setValueToObj(System.Object obj, ProtocolField parseField,
                Object value)
    {
        string targetFieldName = parseField.getFieldName();
        SetFields(obj, targetFieldName,value);
             
    }

    /**
     * 利用暴力反射获得属性值
     * 
     * @param obj
     * @param parseField
     * @return
     */
    public static Object getValueFromObj(Object obj, ProtocolField parseField)
    {
        string targetFieldName = parseField.getFieldName();
        if (targetFieldName != null && targetFieldName.Trim().Length > 0)
        {
            try
            {

                Type type = obj.GetType();
                FieldInfo fieldInfo = type.GetField(targetFieldName, BindingFlags.NonPublic | BindingFlags.Instance);
                return  fieldInfo.GetValue(obj);

                 
            }
            catch (Exception e)
            {
                UnityEngine.Debug.LogError(e.ToString());
            }
        }
        return null;
    }

    /**
     * 转流:Short类型
     * 
     * @param stream
     * @param value
     *            @
     */
    public static void EncodeShort(Stream stream, short value)

    {
        
        byte[] buf = ByteArrayPool.GetByte2();
        buf[0] = (byte)((value & 0xff00) >> 8);
        buf[1] = (byte)(value & 0xff);
        stream.Write(buf,0,2);
        ByteArrayPool.ReleaseByte2(buf);
    }


    /**
     * 解流:Short类型
     * 
     * @param buf
     * @return @
     */
    public static short DecodeShort(byte[] buf, int pos)
    {
        return (short)DecodeInteger(buf, pos);
        //return short.parseShort(DecodeInteger(buf, pos).toString());
    }



    /**
     * 布尔类型
     * 
     * @param stream
     * @param value
     *            @
     */
    public static void EncodeBoolean(Stream stream, bool value)

    {
        if (value)
        {
            EncodeByte(stream, (byte)1);
        }
        else
        {
            EncodeByte(stream, (byte)0);
        }
    }

    /**
     * 布尔类型
     * 
     * @param buf
     * @return @
     */
    public static Boolean DecodeBoolean(byte[] buf, int pos)
    {
        Byte b = DecodeByte(buf, pos);
        return b == (byte)1;
    }

    /**
     * 
     * @param inputStream
     * @return
     */
    public static Boolean DecodeBoolean(Stream inputStream)
    {
        Byte b = DecodeByte(inputStream);
        return b ==  (byte)1;
    }

    /**
     * 一个字节
     * 
     * @param stream
     * @param value
     *            @
     */
    public static void EncodeByte(Stream stream, byte value)

    {
        stream.WriteByte(value);
    }

    /**
     * 一个字节
     * 
     * @param buf
     * @return @
     */
    public static Byte DecodeByte(byte[] buf, int pos)
    {
        return buf[pos];
    }

    /**
     * 
     * @param inputStream
     * @return
     */
    public static Byte DecodeByte(Stream inputStream)
    {
        return (byte)inputStream.ReadByte();

    }

    /**
     * 多个字节
     * 
     * @param buf
     * @param pos
     * @return
     */
    public static byte[] DecodeBytes(byte[] buf, int pos, int len)
    {
        byte[] content = new byte[len];
        System.Array.Copy(buf, pos, content, 0, len);
        return content;
    }

    /**
     * 单精度浮点
     * 
     * @param stream
     * @param value
     *            @
     */
    public static void EncodeFloat(Stream stream, float value)
    {
        byte[] bytes = BitConverter.GetBytes(value);
        int x = BitConverter.ToInt32(bytes, 0);

        //int x = Float.floatToRawIntBits(value);
        EncodeInteger(stream, x);
    }

    /**
     * 单精度浮点
     */
    public static float DecodeFloat(byte[] buf, int pos)
    {
        int x = DecodeInteger(buf, pos);

        byte[] bytes = BitConverter.GetBytes(x);

        return BitConverter.ToSingle(bytes, 0);

        //return Float.intBitsToFloat(x);
    }

    /**
     * 单精度浮点
     */
    public static float DecodeFloat(MemoryStream inputStream)
    {
        int x = DecodeInteger(inputStream);
        byte[] bytes = BitConverter.GetBytes(x);
        return BitConverter.ToSingle(bytes, 0);
    }

    /**
     * 双精度浮点
     */
    public static void EncodeDouble(Stream stream, double value)

    {
        byte[] bytes = BitConverter.GetBytes(value);
        ulong x = BitConverter.ToUInt64(bytes, 0);

        //long x = Double.doubleToRawLongBits(value);
        EncodeLong(stream, x);
    }

    /**
     * 双精度浮点
     */
    public static double DecodeDouble(byte[] buf, int pos)
    {
        ulong x = DecodeLong(buf, pos);

        byte[] bytes = BitConverter.GetBytes(x);
        return BitConverter.ToDouble(bytes, 0);

        //return Double.longBitsToDouble(x);
    }

    /**
     * 双精度浮点
     */
    public static double DecodeDouble(Stream inputStream)
    {
        ulong x = DecodeLong(inputStream);
        byte[] bytes = BitConverter.GetBytes(x);
        return BitConverter.ToDouble(bytes, 0);
        //return Double.longBitsToDouble(x);
    }

    /**
     * 整形
     */
    public static void EncodeInteger(Stream stream, int value)

    {
        byte[] buf = ByteArrayPool.GetByte4() ;
        buf[0] = (byte)((value & 0xff000000) >> 24);
        buf[1] = (byte)((value & 0xff0000) >> 16);
        buf[2] = (byte)((value & 0xff00) >> 8);
        buf[3] = (byte)(value & 0xff);
        stream.Write(buf,0,4);
        ByteArrayPool.ReleaseByte4(buf);
    }

    /**
     * 整形
     */
    public static byte[] EncodeInteger(int value)
    {
        byte[] stream = new byte[4];
        stream[0] = (byte)((value & 0xff000000) >> 24);
        stream[1] = (byte)((value & 0xff0000) >> 16);
        stream[2] = (byte)((value & 0xff00) >> 8);
        stream[3] = (byte)(value & 0xff);
        return stream;
    }

    /**
     * int3
     */
    public static byte[] EncodeInteger(int value,byte[] stream, int offset = 0)
    {
        stream[0+ offset] = (byte)((value & 0xff000000) >> 16);
        stream[1+ offset] = (byte)((value & 0xff0000) >> 8);
        stream[2+ offset] = (byte)(value & 0xff);
        return stream;
    }


    /**
     * 整形
     */
    public static int DecodeInteger(byte[] buf)
    {
        int pos = 0;
        int value = 0;
        value =  ((buf[pos++] & 0xff) << 16)
                | ((buf[pos++] & 0xff) << 8) 
                | (buf[pos++] & 0xff);
        ByteArrayPool.ReleaseByte4(buf);
        return value;
    }
    /**
     * 整形
     */
    public static int DecodeInteger(Stream inputStream)
    {
        int pos = 0;
        byte[] buf = ByteArrayPool.GetByte4();
        try
        {
            inputStream.Read(buf, 0, 4);
 
        }
        catch (IOException e)
        {
            UnityEngine.Debug.LogError(e.ToString());
        }
        int value = 0;
        value = ((buf[pos++] & 0xff) << 24) | ((buf[pos++] & 0xff) << 16)
                | ((buf[pos++] & 0xff) << 8) | (buf[pos++] & 0xff);
        ByteArrayPool.ReleaseByte4(buf);
        return value;
    }

    /**
     * 短数值
     * @param inputStream
     * @return
     */
    public static short DecodeShort(Stream inputStream)
    {
        int pos = 0;
        byte[] buf = ByteArrayPool.GetByte2();
        try
        {
            inputStream.Read(buf,0,2);
        }
        catch (IOException e)
        {
            UnityEngine.Debug.LogError(e.ToString());
        }
        int value = 0;
        value = ((buf[pos++] & 0xff) << 8) | (buf[pos++] & 0xff);
        ByteArrayPool.ReleaseByte2(buf);
        return (short)value; //short.Parse(value + "");  TODO：待测试
    
    }

    /**
     * 空读，占位
     */
    public static void skipInputStream(Stream inputStream, int len)
    {
 
        try
        {
            inputStream.Seek(len, SeekOrigin.Current);
 
        }
        catch (IOException e)
        {
            UnityEngine.Debug.LogError(e.ToString());
        }
    }

    /**
     * 整形
     */
    public static int DecodeInteger(byte[] buf, int pos)
    {
        int value = 0;

        value = ((buf[pos++] & 0xff) << 24) | ((buf[pos++] & 0xff) << 16)
                | ((buf[pos++] & 0xff) << 8) | (buf[pos++] & 0xff);

        return value;
    }

    /**
     * 长整型
     */
    public static void EncodeLong(Stream stream, ulong value)
    {
        
        byte[] buf = ByteArrayPool.GetByte8(); ;
        buf[0] = (byte) ((value & 0xff00000000000000L) >> 56);
        buf[1] = (byte) ((value & 0xff000000000000L) >> 48);
        buf[2] = (byte) ((value & 0xff0000000000L) >> 40);
        buf[3] = (byte) ((value & 0xff00000000L) >> 32);
        buf[4] = (byte) ((value & 0xff000000L) >> 24);
        buf[5] = (byte) ((value & 0xff0000L) >> 16);
        buf[6] = (byte) ((value & 0xff00L) >> 8);
        buf[7] = (byte) (value & 0xffL);
        stream.Write(buf,0,8);
        ByteArrayPool.ReleaseByte8(buf);
    }

    /**
	 * 长整型
	 */
    public static ulong DecodeLong(byte[] buf, int pos)
    {
        ulong value = 0;
        value |= (ulong)(buf[pos++] & 0xff) << 56;
        value |= (ulong)(buf[pos++] & 0xff) << 48;
        value |= (ulong)(buf[pos++] & 0xff) << 40;
        value |= (ulong)(buf[pos++] & 0xff) << 32;
        value |= (ulong)(buf[pos++] & 0xff) << 24;
        value |= (ulong)(buf[pos++] & 0xff) << 16;
        value |= (ulong)(buf[pos++] & 0xff) << 8;
        value |= (ulong)(buf[pos++] & 0xff);
        return value;
        // string s = DecodeString(stream, TYPE_LONG_MAX_SIZE);
        // return Long.parseLong(s.trim());
    }

    /**
     * 长整型
     */
    public static ulong DecodeLong(Stream inputStream)
    {
        int pos = 0;
        byte[] buf = ByteArrayPool.GetByte8(); ;
        try
        {
            inputStream.Read(buf,0,8);
        }
        catch (IOException e)
        {
            UnityEngine.Debug.LogError(e.ToString());
        }
        ulong value = 0;
        value |= (ulong)(buf[pos++] & 0xff) << 56;
        value |= (ulong)(buf[pos++] & 0xff) << 48;
        value |= (ulong)(buf[pos++] & 0xff) << 40;
        value |= (ulong)(buf[pos++] & 0xff) << 32;
        value |= (ulong)(buf[pos++] & 0xff) << 24;
        value |= (ulong)(buf[pos++] & 0xff) << 16;
        value |= (ulong)(buf[pos++] & 0xff) << 8;
        value |= (ulong)(buf[pos++] & 0xff);
        ByteArrayPool.ReleaseByte8(buf);
        return value;
        // string s = DecodeString(stream, TYPE_LONG_MAX_SIZE);
        // return Long.parseLong(s.trim());
    }

    /**
     * 字符串(自适应长度)
     */
    public static void EncodeString(Stream stream, string value)

                
    {
        EncodeString(stream, value, -1);
    }

    /**
	 * 字符串
	 * 
	 * @param stream
	 * @param value
	 * @param fixedLength
	 *            定长字符串长度，如果0则不定长度，自动适应 @
	 */
    public static void EncodeString(Stream stream, string value,
            int fixedLength)
    {
        if (value != null && value.Length > 0)
        {
            byte[] content = Encoding.UTF8.GetBytes(value);
            int len = content.Length;
            if (fixedLength > 0)
            {
                if (len > fixedLength)
                {
                    len = fixedLength;
                }
                EncodeInteger(stream, len);
                stream.Write(content, 0, len);
            }
            else
            {
                // 不定长字符串，用4个字节记录字符串长度
                // 写字符串长度
                EncodeInteger(stream, len);
                stream.Write(content, 0, len);
            }
            
        }
        else
        {
            EncodeInteger(stream, 0);
        }
    }

    /**
     * 字符串(自适应长度)
     */
    public static string DecodeString(byte[] buf, int pos) 
    {
            return DecodeString(buf, pos, -1);
    }

    /**
	 * 字符串
	 */
    public static string DecodeString(byte[] buf, int pos, int fixedLength)  
    {
        int len;
        // 先从流中获取长度
        len = DecodeInteger(buf, pos);
                if (len > TYPE_STRING_MAX_SIZE)
                {
                    throw new  Exception("字符串过长，解析协议出错!");
        }
        pos = pos + 4;
        if (fixedLength > 0)
        {
            // 定长
            if (fixedLength > len)
            {
                len = fixedLength;
            }

        }
        return Encoding.UTF8.GetString(buf, pos,len);
        //byte[] content = new byte[len];
        //System.Array.Copy(buf, pos, content, 0, len);
        //return new string (content);
    }

    /**
	 * 字符串
	 */
    public static string DecodeString(Stream inputStream)  {
        return DecodeString(inputStream, -1);
    }

    /**
	 * 字符串
	 */
    public static string DecodeString(Stream inputStream, int fixedLength)
    {
        int len;
        // 先从流中获取长度
        len = DecodeInteger(inputStream);
        if (len > TYPE_STRING_MAX_SIZE)
        {
            throw new Exception("字符串过长，解析协议出错!");
        }
        if (fixedLength > 0)
        {
            // 定长
            if (fixedLength > len)
            {
                len = fixedLength;
            }
        }
        byte[] content = new byte[len];
        try
        {
            inputStream.Read(content,0,len);
        }
        catch (IOException e)
        {
            UnityEngine.Debug.LogError(e.ToString());
        }
        return Encoding.UTF8.GetString(content);
    }

    

    /**
     * 字节比对
     */
    public static bool compareByte(byte[] a, byte[] b)
    {
        if (a.Length == b.Length)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }
            return true;
        }
        return false;
    }

    /**
     * 封包
     */
    public static byte[] newEncodeVo(BasePo po)
    {
        MemoryStream baos = new MemoryStream();
        po.encodeVo(baos);
        return baos.ToArray();
    }

    /**
     * 解包
     * @param msg  消息数据
     * @param encryptTypeUp  上行加密方式  0 不加密  1 3des 加密
     * @return
     * @throws Exception
     */
    public static System.Object newDecodeVo(byte[] msg, int encryptTypeUp)  
    {
        //		System.out.println(Test3DES.bytes2HexString(msg));
        byte[] result = msg;
        if (encryptTypeUp == 1)
            result = CryptUtil3DES.decrypt(msg);


        MemoryStream inputStream = new MemoryStream(result);

        //ByteArrayInputStream inputStream = new ByteArrayInputStream(result);

      

        int commandId = PackageUtil.DecodeInteger(inputStream);


        return ProtocolIntToClassFactory.GetClassInstance(commandId);
        /*Dictionary<int, ProtocolContainer> parseMap = Context.getInstance()
                .getProtocolMap();
        ProtocolContainer parseContainer = parseMap[commandId];
        string requestClass = parseContainer.getNameSpaceClass();


        return ProtocolClassFactory.Instance().CreateInstancce(requestClass, inputStream);*/
        
	}
}
