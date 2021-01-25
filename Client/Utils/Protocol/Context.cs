using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * 贯穿全局的上下文环境，为单例
 * 
 * @author guoxi
 * 
 */
public class Context
{

    private Random random;
    public static int serverType = 1;// 1:游戏服，2:战斗服  3:匹配服

    /**
	 * 构造器
	 */
    private Context()
    {
        random = new Random( );
    }

    //public Log log = LogFactory.getLog(this.getClass());

    private static Context context = null;

    /**
	 * 协议解析的XML配置文件转化后的map
	 */
    private Dictionary<int, ProtocolContainer> protocolMap = new Dictionary<int, ProtocolContainer>();

    /**
	 * 传输包设置
	 */
    private ProtocolSetting protocolSetting;

   

    /**
	 * 获得Context实例
	 * 
	 * @return
	 */
    public static Context getInstance()
    {
        if (context == null)
        {
            synInit();
        }
        return context;
    }

    public static  void synInit()
    {
        if (context == null)
        {
            context = new Context();
        }
    }
    /*public Dictionary<int, ProtocolContainer> getProtocolMap()
    {
        return protocolMap;
    }*/




    /*public void setParseMap(Dictionary<int, ProtocolContainer> parseMap)
    {
        this.protocolMap = parseMap;
    }*/


    public ProtocolSetting getProtocolSetting()
    {
        return protocolSetting;
    }

    public void setProtocolSetting(ProtocolSetting protocolSetting)
    {
        this.protocolSetting = protocolSetting;
    }

    public Random getRandom()
    {
        return random;
    }

 
}
