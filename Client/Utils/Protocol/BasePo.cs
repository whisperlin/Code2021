using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;



/**
 * 基础网络VO对象
 * 
 * @author Seraph
 * 
 */
public abstract class BasePo   {

	private const long serialVersionUID = -2503482652061267695L;
    /**
     * 跟踪ID，随机生成
     */
    protected int trackId = 0;

    /**
     * 命令号，让传输包继承时重载
     */
    protected int commandId = 0;

    protected int terminalType = 1;
    /**
     * 加密类型 上行
     */
    protected int encryptTypeUp = 0;
    /**
     * 加密类型 下行
     */
    protected int encryptTypeDown = 0;

    public abstract void encodeVo(MemoryStream outputStream)  ;

    /**
     * 获取命令号
     */
    public int getCommandId()
    {
        return commandId;
    }

    /**
     * 跟踪ID
     * @return
     */
    public int getTrackId()
    {
        return trackId;
    }

    /**
     * 加密类型 上行
     */
    public int getEncryptTypeUp()
    {
        return encryptTypeUp;
    }
    /**
     * 加密类型 下行
     */
    public int getEncryptTypeDown()
    {
        return encryptTypeDown;
    }

    /**
     * 跟踪ID
     * @param trackId
     */
    public void setTrackId(int trackId)
    {
        this.trackId = trackId;
    }

    public int getTerminalType()
    {
        return terminalType;
    }

    public void setTerminalType(int terminalType)
    {
        this.terminalType = terminalType;
    }
	

}
