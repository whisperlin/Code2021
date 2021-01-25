using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po{

/// <summary>
 /// 心跳包
 /// </summary>
public class HeartbeatPo : BasePo{

	public const int cmd = 2;
	public const string reflectClassName = "com.hbt.protocol.po.HeartbeatPo";

	public HeartbeatPo():base() {
		commandId = 2;
		encryptTypeUp = 0;
	}

	public HeartbeatPo(MemoryStream inputStream){
		commandId = 2;
		encryptTypeUp = 0;
		this.setPlayerId(PackageUtil.DecodeString(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeString(outputStream, getPlayerId());
	}

	/// <summary>
	 /// 玩家id
	 /// </summary>
	private string playerId; 

	/// <summary>
	 /// 玩家id
	 /// </summary>
	public void setPlayerId(string playerId){
		this.playerId=playerId;
	}

	/// <summary>
	 ///玩家id
	 /// </summary>
	public string  getPlayerId(){  
		return playerId; 
	}

	public override string ToString() {
		return "playerId:" + playerId;
	}

}
}