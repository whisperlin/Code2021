using UnityEngine;
using System.Collections;

public class Test_Ping : MonoBehaviour
{

    public string IP = "123.125.114.144";
    Ping ping;
    float delayTime;

    void Start()
    {
        SendPing();
    }

    void OnGUI()
    {
        GUI.color = Color.red;
        GUI.Label(new Rect(10, 10, 100, 20), "ping: " + delayTime.ToString() + "ms");

        if (null != ping && ping.isDone)
        {
            delayTime = ping.time;
            ping.DestroyPing();
            ping = null;
            Invoke("SendPing", 1.0F);//每秒Ping一次
        }

        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            GUI.Label(new Rect(10, 50, 200, 30), "没有联网！！！");

        }
        if (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        {
            GUI.Label(new Rect(10, 50, 200, 30), "使用局域网！！！");

        }
        if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)
        {
            GUI.Label(new Rect(10, 50, 200, 30), "使用移动网络！！！");
        }
    }
    void SendPing()
    {
        ping = new Ping(IP);
    }
}