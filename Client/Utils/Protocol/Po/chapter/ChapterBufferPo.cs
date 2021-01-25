using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.chapter{

/// <summary>
 /// 冒险关卡Buff
 /// </summary>
public class ChapterBufferPo : BasePo{

	public const int cmd = 770914;
	public const string reflectClassName = "com.hbt.protocol.po.chapter.ChapterBufferPo";

	public ChapterBufferPo():base() {
		commandId = 770914;
		encryptTypeUp = 0;
	}

	public ChapterBufferPo(MemoryStream inputStream){
		commandId = 770914;
		encryptTypeUp = 0;
		this.setBuffId(PackageUtil.DecodeInteger(inputStream));
		this.setIsBattleRound(PackageUtil.DecodeBoolean(inputStream));
		this.setRound(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getBuffId());
		PackageUtil.EncodeBoolean(outputStream, getIsBattleRound());
		PackageUtil.EncodeInteger(outputStream, getRound());
	}

	/// <summary>
	 /// 冒险关卡buffID
	 /// </summary>
	private int buffId; 

	/// <summary>
	 /// 是=战斗次数； 否=开图回合
	 /// </summary>
	private bool isBattleRound; 

	/// <summary>
	 /// 剩余回合/次数
	 /// </summary>
	private int round; 

	/// <summary>
	 /// 冒险关卡buffID
	 /// </summary>
	public void setBuffId(int buffId){
		this.buffId=buffId;
	}

	/// <summary>
	 ///冒险关卡buffID
	 /// </summary>
	public int  getBuffId(){  
		return buffId; 
	}

	/// <summary>
	 /// 是=战斗次数； 否=开图回合
	 /// </summary>
	public void setIsBattleRound(bool isBattleRound){
		this.isBattleRound=isBattleRound;
	}

	/// <summary>
	 ///是=战斗次数； 否=开图回合
	 /// </summary>
	public bool  getIsBattleRound(){  
		return isBattleRound; 
	}

	/// <summary>
	 /// 剩余回合/次数
	 /// </summary>
	public void setRound(int round){
		this.round=round;
	}

	/// <summary>
	 ///剩余回合/次数
	 /// </summary>
	public int  getRound(){  
		return round; 
	}

	public override string ToString() {
		return "buffId:" + buffId + "," + "isBattleRound:" + isBattleRound + "," + "round:" + round;
	}

}
}