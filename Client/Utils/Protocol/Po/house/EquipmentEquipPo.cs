using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.house{

/// <summary>
 /// 装备-装备
 /// </summary>
public class EquipmentEquipPo : BasePo{

	public const int cmd = 312149;
	public const string reflectClassName = "com.hbt.protocol.po.house.EquipmentEquipPo";

	public EquipmentEquipPo():base() {
		commandId = 312149;
		encryptTypeUp = 0;
	}

	public EquipmentEquipPo(MemoryStream inputStream){
		commandId = 312149;
		encryptTypeUp = 0;
		this.setItemUuid(PackageUtil.DecodeLong(inputStream));
		this.setRoomId(PackageUtil.DecodeInteger(inputStream));
		this.setSlotId(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeLong(outputStream, getItemUuid());
		PackageUtil.EncodeInteger(outputStream, getRoomId());
		PackageUtil.EncodeInteger(outputStream, getSlotId());
	}

	/// <summary>
	 /// 装备道具ID
	 /// </summary>
	private ulong itemUuid; 

	/// <summary>
	 /// 房间ID
	 /// </summary>
	private int roomId; 

	/// <summary>
	 /// 装备栏ID(0-2)
	 /// </summary>
	private int slotId; 

	/// <summary>
	 /// 装备道具ID
	 /// </summary>
	public void setItemUuid(ulong itemUuid){
		this.itemUuid=itemUuid;
	}

	/// <summary>
	 ///装备道具ID
	 /// </summary>
	public ulong  getItemUuid(){  
		return itemUuid; 
	}

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
		return "itemUuid:" + itemUuid + "," + "roomId:" + roomId + "," + "slotId:" + slotId;
	}

}
}