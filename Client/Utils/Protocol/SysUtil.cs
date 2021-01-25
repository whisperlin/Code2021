using com.hbt.protocol.po;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
 
public class SysUtil  
{
    /**
	 * 调用翻身API产生对象实例
	 * 
	 * @param className
	 * @return
	 * @throws ClassNotFoundException
	 * @throws InstantiationException
	 * @throws IllegalAccessException
	 */
    public static Object getInstance(string className)  {
        //return ProtocolClassFactory.Instance().CreateInstancce(name);
         //TODO:IOS上有问题.
        Type type2 = Assembly.GetExecutingAssembly().GetType(className);
        return Activator.CreateInstance(type2);

    }

    /**
	 * 字符转数字（带默认值）
	 * @param number
	 * @param defValue
	 * @return
	 */
    public static int strToIntDef(String number, int defValue)
    {
        int len= defValue;
        try
        {
            len = int.Parse(number);
        }
        catch (Exception e)
        {
#if DEBUG_LOG
            UnityEngine.Debug.LogError(e.ToString());
            len = defValue;
#endif
        }
        return len;
    }


    
    /**
	 * 调试函数
	 * 
	 * @param dir
	 * @param data
	 */
    public static void debugData(byte[] data, int count1, int type = 0)
    {
#if DEBUG_LOG
        if (type ==0 )
            UnityEngine.Debug.Log("调试数据长度:" + count1);
        else if (type == 1)
            UnityEngine.Debug.LogWarning("调试数据长度:" + count1);
        else
            UnityEngine.Debug.LogWarning("调试数据长度:" + count1);
 
        int count = 0;
        string outText = "";
        for (int i = 0; i < count1; i++)
        {
            byte b = data[i];

            // 16进制如果不满2位则补零
            outText += b.ToString("X");
            //hexString = (hexString.Length == 1) ? "0" + hexString : hexString;
            //Debu.out.print(hexString + " ");
            count++;
            if (count % 4 == 0)
            {
                outText += " ";
            }
            if (count % 16 == 0)
            {
                outText += "\r\n";
            }
        }

        if (type == 0)
            UnityEngine.Debug.Log(outText);
        else if (type == 1)
            UnityEngine.Debug.LogWarning(outText);
        else
            UnityEngine.Debug.LogWarning(outText);

   
#endif
    }

}
