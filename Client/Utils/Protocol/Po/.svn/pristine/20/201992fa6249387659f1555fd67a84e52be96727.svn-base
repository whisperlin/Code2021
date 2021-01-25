using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.house{

/// <summary>
 /// 开启装备栏
 /// </summary>
public class EquipmentSlotOpenPo : BasePo{

	public const int cmd = 312147;
	public const string reflectClassName = "com.hbt.protocol.po.house.EquipmentSlotOpenPo";

	public EquipmentSlotOpenPo():base() {
		commandId = 312147;
		encryptTypeUp = 0;
	}

	public EquipmentSlotOpenPo(MemoryStream inputStream){
		commandId = 312147;
		encryptTypeUp = 0;
		this.setRoomId(PackageUtil.DecodeInteger(inputStream));
		this.setSlotId(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getRoomId());
		PackageUtil.EncodeInteger(outputStream, getSlotId());
	}

	/// <summary>
	 /// 房间ID
	 /// </summary>
	private int roomId; 

	/// <summary>
	 /// 装备栏ID(0-2)
	 /// </summary>
	private int slotId; 

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

	/// <summary>
	 /// 装备栏ID(0-2)
	 /// </summary>
	public void setSlotId(int slotId){
		this.slotId=slotId;
	}

	/// <summary>
	 ///装备栏ID(0-2)
	 /// </summary>
	public int  getSlotId(){  
		return slotId; 
	}

	public override string ToString() {
		return "roomId:" + roomId + "," + "slotId:" + slotId;
	}

}
}