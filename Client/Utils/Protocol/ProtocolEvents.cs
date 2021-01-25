using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//BasePo

public delegate void OnReciveProtocol(BasePo po);
public class ProtocolEvents 
{
    static Dictionary<int, OnReciveProtocol> msgs = new Dictionary<int, OnReciveProtocol>();

    static Dictionary<int, OnReciveProtocol> msgsOneTime = new Dictionary<int, OnReciveProtocol>();
    public static void AddEvent(int cmd, OnReciveProtocol fun)
    {
        OnReciveProtocol ef;
        if (msgs.TryGetValue(cmd, out ef))
        {
            ef += fun;
            msgs[cmd] = ef;
        }
        else
        {
            msgs[cmd] = fun;
        }
    }

    public static void CatchNextEvent(int cmd, OnReciveProtocol fun)
    {
        OnReciveProtocol ef;
        if (msgsOneTime.TryGetValue(cmd, out ef))
        {
            ef += fun;
            msgsOneTime[cmd] = ef;
        }
        else
        {
            msgsOneTime[cmd] = fun;
        }
    }
    public static void RemoveEvent(int cmd, OnReciveProtocol fun)
    {
        OnReciveProtocol ef;
        if (msgs.TryGetValue(cmd, out ef))
        {
            ef -= fun;
            msgs[cmd] = ef;
        }

    }
    public static void CallEvent(int cmd,BasePo op)
    {
        OnReciveProtocol ef;
        if (msgs.TryGetValue(cmd, out ef))
        {
            ef.Invoke(op);
        }
        else
        {
            Debug.LogError("网络消息未绑定 "+cmd);
        }
        if (msgsOneTime.TryGetValue(cmd, out ef))
        {
            ef.Invoke(op);
            msgsOneTime.Remove(cmd);
        }
    }

     

     
}
