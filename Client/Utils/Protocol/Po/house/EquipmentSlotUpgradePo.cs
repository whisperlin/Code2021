using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.house{

/// <summary>
 /// 装备栏升级
 /// </summary>
public class EquipmentSlotUpgradePo : BasePo{

	public const int cmd = 312148;
	public const string reflectClassName = "com.hbt.protocol.po.house.EquipmentSlotUpgradePo";

	public EquipmentSlotUpgradePo():base() {
		commandId = 312148;
		encryptTypeUp = 0;
	}

	public EquipmentSlotUpgradePo(MemoryStream inputStream){
		commandId = 312148;
		encryptTypeUp = 0;
		this.setRoomId(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getRoomId());
	}

	/// <summary>
	 /// 房间ID
	 /// </summary>
	private int roomId; 

	/// <summary>
	 /// 房间ID
	 /// </summary>
	public void setRoomId(int roomId){
		this.roomId=roomId;
	}

	/// <summary>
	 ///房间ID
	 /// </summary>
	public int  getRoomId(){  
		return roomId; 
	}

	public override string ToString() {
		return "roomId:" + roomId;
	}

}
}