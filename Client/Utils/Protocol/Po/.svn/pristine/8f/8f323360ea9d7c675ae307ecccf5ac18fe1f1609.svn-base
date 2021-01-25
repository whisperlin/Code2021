using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.battle{

/// <summary>
 /// 获取战斗动画序列
 /// </summary>
public class BattleMotionPo : BasePo{

	public const int cmd = 705362;
	public const string reflectClassName = "com.hbt.protocol.po.battle.BattleMotionPo";

	public BattleMotionPo():base() {
		commandId = 705362;
		encryptTypeUp = 0;
	}

	public BattleMotionPo(MemoryStream inputStream){
		commandId = 705362;
		encryptTypeUp = 0;
		this.setStartOrder(PackageUtil.DecodeInteger(inputStream));
		this.setCount(PackageUtil.DecodeInteger(inputStream));
		this.setPlayId(PackageUtil.DecodeString(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getStartOrder());
		PackageUtil.EncodeInteger(outputStream, getCount());
		PackageUtil.EncodeString(outputStream, getPlayId());
	}

	/// <summary>
	 /// 起始Motion位置
	 /// </summary>
	private int startOrder; 

	/// <summary>
	 /// 获取多少个Motion
	 /// </summary>
	private int count; 

	/// <summary>
	 /// 战斗id
	 /// </summary>
	private string playId; 

	/// <summary>
	 /// 起始Motion位置
	 /// </summary>
	public void setStartOrder(int startOrder){
		this.startOrder=startOrder;
	}

	/// <summary>
	 ///起始Motion位置
	 /// </summary>
	public int  getStartOrder(){  
		return startOrder; 
	}

	/// <summary>
	 /// 获取多少个Motion
	 /// </summary>
	public void setCount(int count){
		this.count=count;
	}

	/// <summary>
	 ///获取多少个Motion
	 /// </summary>
	public int  getCount(){  
		return count; 
	}

	/// <summary>
	 /// 战斗id
	 /// </summary>
	public void setPlayId(string playId){
		this.playId=playId;
	}

	/// <summary>
	 ///战斗id
	 /// </summary>
	public string  getPlayId(){  
		return playId; 
	}

	public override string ToString() {
		return "startOrder:" + startOrder + "," + "count:" + count + "," + "playId:" + playId;
	}

}
}