using com.hbt.protocol.po;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public enum CONNECT_STATE
{
    NONE = 0,
    SCUESS = 1,
    FALSE = 2
}
public class NettyClient : MonoBehaviour
{
    static NettyClient _ist;
    public static NettyClient Instance()
    {
        if (null == _ist)
        {
            GameObject g = new GameObject("NettyClient");
            _ist = g.AddComponent<NettyClient>();
            GameObject.DontDestroyOnLoad(g);
        }
        return _ist;
    }
    public string _ip = "192.168.0.105";
    public int _port = 5000;

    Context context;
    ProtocolSetting ps;

    int x = 0;
    const string packagetHeader = "apvo";
    public void TestSend()
    {
        test2();
    }
     
    public void SendPo(BasePo vo)
    {
        
        MemoryStream baos = new MemoryStream();
        byte[] msgBytes = baos.ToArray();//vo
        byte[] header = Encoding.UTF8.GetBytes(packagetHeader);
        baos.Write(header, 0, header.Length);
 

        /**
		 * 包头"avpo"
		 *   4byte                                           +4=4b
		 * 预留字段	+	终端类型  +   加密方式  +  消息类型
		 *  1byte   +    1byte  +    1byte   +   1byte       +4=8b
		 * 包未加密长度
		 *   4byte                                           +4=12b
		 * 包加密后长度
		 *   4byte                                           +4=16b
		 *  类似CRC验证(暂时未用)
		 *   8byte                                           +8=24b
		 *  实际包体
		 *  X byte
		 *
		 *  终端类型：1=手机到服务器  2=Flash到服务器  3=服务器到客户端
		 *  加密方式：0=不开启   1=开启
		 *  消息类型：1=AMF    3=buff字节流(默认)
		 */
        byte[] arr = new byte[4];
        arr[0] = (byte)(0);
        arr[1] = (byte)(3);
        arr[2] = (byte)(0);
        arr[3] = (byte)(3);

        baos.Write(arr, 0, arr.Length);



        MemoryStream baos2 = new MemoryStream();
        vo.encodeVo(baos2);
        byte[] buffer = baos2.ToArray();
        PackageUtil.EncodeInteger(baos, (int)buffer.Length);//包长度
        PackageUtil.EncodeInteger(baos, (int)buffer.Length);//加密前包长度
        //byte[] bytesLen = BitConverter.GetBytes((int)buffer.Length);
        //baos.Write(bytesLen, 0, bytesLen.Length);

        byte[] verifyBuf = new byte[8];

        baos.Write(verifyBuf, 0, verifyBuf.Length);

        baos.Write(buffer, 0, buffer.Length);

        //vo.encodeVo(baos);
        byte[] bufferFinal = baos.ToArray();

        try
        {
            socketSend.Send(bufferFinal, 0, bufferFinal.Length, SocketFlags.None);
        }
        catch (System.Net.Sockets.SocketException e1)
        {
            Debug.LogError(e1);
            MainLogic.Instance.DisConnectionNet = true;
            beginRec = false;
            if (null != socketSend)
                socketSend.Close();
        }

    }
    void test2()
    {
        EchoPo bp = new EchoPo();
        bp.setEchoStr("from unity!!!!!!");
        bp.setEchoInt(x++);
        SendPo(bp);
         
    }
    bool fistInit = false;
    public IEnumerator Init()
    {
        if (!fistInit)
        {
            fistInit = true;
            context = Context.getInstance();
            GameObject.DontDestroyOnLoad(gameObject);
            try
            {

                ps = ProtocolSetting.loadFromXml("protocol_main.xml");
                context.setProtocolSetting(ps);
            }
            catch (Exception e)
            {
                Debug.LogError(e.ToString());

            }
        }
        yield return StartCoroutine(bt_connect());
       
    }
    void Start()
    {
        Init();
    }

 
    void Update()
    {

        while (true)
        {
            //Debug.LogError("begin " + tempBuffer.startIndex + " " + tempBuffer.Count);
            if (tempBuffer.Count < 4 + 4 + 4 + 4 + 8)
            {
                break;
            }

 

            if (tempBuffer.LookByte() == packagetHeader[0])
            {
                if (tempBuffer.LookByte(1) == packagetHeader[1])
                {
                    if (tempBuffer.LookByte(2) == packagetHeader[2])
                    {
                        if (tempBuffer.LookByte(3) == packagetHeader[3])
                        {
                            //isHeader = true;
                        }
                        else
                        {
                            Debug.LogError("非包头"+ tempBuffer.LookByte(3));
                            tempBuffer.Move(4);
                            continue;
                        }
                    }
                    else
                    {
                        Debug.LogError("非包头"+ tempBuffer.LookByte(2));
                        tempBuffer.Move(3);
                        continue;
                    }
                }
                else
                {
                    Debug.LogError("非包头"+ tempBuffer.LookByte(1));
                    tempBuffer.Move(2);
                    continue;
                }
            }
            else
            {
                Debug.LogError("非包头"+ tempBuffer.LookByte());
                tempBuffer.Move(1);
                continue;
            }

            /**
		     * 包头"avpo"
		     *   4byte                                           +4=4b
		     * 预留字段	+	终端类型  +   加密方式  +  消息类型
		     *  1byte   +    1byte  +    1byte   +   1byte       +4=8b
		     * 包未加密长度
		     *   4byte                                           +4=12b
		     * 包加密后长度
		     *   4byte                                           +4=16b
		     *  类似CRC验证(暂时未用)
		     *   8byte                                           +8=24b
		     *  实际包体
		     *  X byte
		     *
		     *  终端类型：1=手机到服务器  2=Flash到服务器  3=服务器到客户端
		     *  加密方式：0=不开启   1=开启
		     *  消息类型：1=AMF    3=buff字节流(默认)
		     */

            byte[] byte4 = ByteArrayPool.GetByte4();
            tempBuffer.GetByte(4,byte4 );
            int nouse = byte4[0];//预留字段
            int terminalType = byte4[1];//终端类型
            int signalMethod = byte4[2];//加密方式
            int msgType = byte4[3];//消息类型


            // 包体长度,包长度
            tempBuffer.GetByte(8, byte4);
            int dataLength = PackageUtil.DecodeInteger(byte4, 0);

            //int originalLen = buffer.readInt();//原来的长度
            tempBuffer.GetByte(12,byte4);
            int encrypDataLength = PackageUtil.DecodeInteger(byte4, 0);
 
            byte[] byte8 = ByteArrayPool.GetByte8();
            tempBuffer.GetByte(16,byte8);

            
            ByteArrayPool.ReleaseByte8(byte8);

            //检测剩余可读buff是否充足
            if (tempBuffer.Count >= dataLength + 24)
            {
                tempBuffer.Move(24);
            }
            else
            {
#if DEBUG_LOG
                Debug.Log("不符合长度");
#endif
                ByteArrayPool.ReleaseByte4(byte4);
                break;
            }
            //Debug.LogError("move 24  " + tempBuffer.startIndex + " " + tempBuffer.Count);

            byte[] data = new byte[dataLength];
            tempBuffer.Read(data);
#if DEBUG_LOG
            //SysUtil.debugData(data,data.Length);
#endif
            //Debug.LogError("here "  + tempBuffer.startIndex + " " + tempBuffer.Count + "  read "+ dataLength);
            if (signalMethod == 1)
            {
                data = CryptUtil3DES.decrypt(data);
            }
 
            MemoryStream inputStream = new MemoryStream(data);
    
            int commandId = PackageUtil.DecodeInteger(inputStream);
            object _object = ProtocolIntToClassFactory.GetClassInstance(commandId, inputStream);
#if DEBUG_LOG
            //Debug.Log(_object);
#endif
            //Debug.LogError("finial "   + tempBuffer.startIndex + " " + tempBuffer.Count);
#if !DEVELOP
            try
            {
#endif

                ProtocolEvents.CallEvent(commandId, (BasePo)_object);
#if !DEVELOP
            }
            catch (Exception e)
            {
                Debug.LogError(e.ToString());
            }
#endif

            ByteArrayPool.ReleaseByte4(byte4);
        }
    }

    public static bool connected = false;
    private void OnConnect(object sender, SocketAsyncEventArgs e)
    {
     
                                // Set the flag for socket connected.  
        connected = (e.SocketError == SocketError.Success);
        if (connected)
        {
            state = CONNECT_STATE.SCUESS;
        }
        else
        {
            state = CONNECT_STATE.FALSE;
        }

        
    }
    bool beginRec = false;
    public void Close()
    {
        beginRec = false;
        if (null != socketSend)
        {
            socketSend.Close();
            socketSend = null;
        }
        connected = false;
        Debug.LogError("断开网络");
    }
    public CONNECT_STATE state = CONNECT_STATE.NONE;
    Socket socketSend;
    private IEnumerator bt_connect()
    {
        try
        {
            connected = false;

            //创建客户端Socket，获得远程ip和端口号
            socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Parse(_ip);
            IPEndPoint point = new IPEndPoint(ip, _port);

            socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            SocketAsyncEventArgs saea = new SocketAsyncEventArgs();
            saea.RemoteEndPoint = new System.Net.IPEndPoint(ip, _port);
            saea.SocketFlags = SocketFlags.None;
            saea.Completed += new EventHandler<SocketAsyncEventArgs>(OnConnect);
            socketSend.ConnectAsync(saea);
            //state = CONNECT_STATE.SCUESS;
        }
        catch (Exception e)
        {
            //state = CONNECT_STATE.FALSE;
            Debug.Log("IP或者端口号错误..." + e.ToString());
        }
        while (state == CONNECT_STATE.NONE)
                yield return null;
        if (state == CONNECT_STATE.SCUESS)
        {
#if DEBUG_LOG
            Debug.LogError("连接成功!");
#endif

            
        }
        else
        {
            Debug.LogError("无法连接服务器");
        }
        //开启新的线程，不停的接收服务器发来的消息
        beginRec = true;
        Thread c_thread = new Thread(Received);
        c_thread.IsBackground = true;
        c_thread.Start();

    }
    
    byte[] recBuffer = new byte[1024 * 1024 * 3];
    DymBuffer tempBuffer = new DymBuffer();
    /// <summary>
    /// 接收服务端返回的消息
    /// </summary>
    void Received()
    {
        while (beginRec)
        {
            try
            {
                if (state == CONNECT_STATE.SCUESS)
                {
                    //实际接收到的有效字节数
                    int len = socketSend.Receive(recBuffer);
                    if (len == 0)
                    {
                        break;
                    }
                    //Debug.Log("tcp 接收 " + len);
                    tempBuffer.Add(recBuffer, len);
                    Thread.Sleep(10);
                }

            }
            catch (System.Net.Sockets.SocketException e1)
            {
                Debug.LogError(e1);
                MainLogic.Instance.DisConnectionNet = true;
                beginRec = false;
                if (null != socketSend)
                    socketSend.Close();
            }
            catch (Exception e)
            {
#if DEBUG_LOG
                Debug.LogError(e.ToString());
#endif
            }
        }
    }

    byte[] buffer = new byte[1024 * 1024 * 3];

    

    /// <summary>
    /// 向服务器发送消息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void bt_send_Click(string str)
    {
        try
        {
            int count;
            string msg = str;
            count = Encoding.UTF8.GetBytes(msg, 0, msg.Length, buffer, 0);
            socketSend.Send(buffer, count, SocketFlags.None);
        }
        catch { }
    }


} 