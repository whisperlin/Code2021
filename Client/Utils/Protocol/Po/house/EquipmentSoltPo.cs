using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.house{

/// <summary>
 /// 装备栏
 /// </summary>
public class EquipmentSoltPo : BasePo{

	public const int cmd = 312146;
	public const string reflectClassName = "com.hbt.protocol.po.house.EquipmentSoltPo";

	public EquipmentSoltPo():base() {
		commandId = 312146;
		encryptTypeUp = 0;
	}

	public EquipmentSoltPo(MemoryStream inputStream){
		commandId = 312146;
		encryptTypeUp = 0;
		this.setSlotId(PackageUtil.DecodeInteger(inputStream));
		this.setOpened(PackageUtil.DecodeBoolean(inputStream));
		this.setEquipedItemId(PackageUtil.DecodeLong(inputStream));
		this.setEquipedId(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getSlotId());
		PackageUtil.EncodeBoolean(outputStream, getOpened());
		PackageUtil.EncodeLong(outputStream, getEquipedItemId());
		PackageUtil.EncodeInteger(outputStream, getEquipedId());
	}

	/// <summary>
	 /// 装备栏ID(0-2)
	 /// </summary>
	private int slotId; 

	/// <summary>
	 /// 是否开启 >0开启
	 /// </summary>
	private bool opened; 

	/// <summary>
	 /// 装备对应道具ID
	 /// </summary>
	private ulong equipedItemId; 

	/// <summary>
	 /// 装备ID
	 /// </summary>
	private int equipedId; 

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

	/// <summary>
	 /// 是否开启 >0开启
	 /// </summary>
	public void setOpened(bool opened){
		this.opened=opened;
	}

	/// <summary>
	 ///是否开启 >0开启
	 /// </summary>
	public bool  getOpened(){  
		return opened; 
	}

	/// <summary>
	 /// 装备对应道具ID
	 /// </summary>
	public void setEquipedItemId(ulong equipedItemId){
		this.equipedItemId=equipedItemId;
	}

	/// <summary>
	 ///装备对应道具ID
	 /// </summary>
	public ulong  getEquipedItemId(){  
		return equipedItemId; 
	}

	/// <summary>
	 /// 装备ID
	 /// </summary>
	public void setEquipedId(int equipedId){
		this.equipedId=equipedId;
	}

	/// <summary>
	 ///装备ID
	 /// </summary>
	public int  getEquipedId(){  
		return equipedId; 
	}

	public override string ToString() {
		return "slotId:" + slotId + "," + "opened:" + opened + "," + "equipedItemId:" + equipedItemId + "," + "equipedId:" + equipedId;
	}

}
}