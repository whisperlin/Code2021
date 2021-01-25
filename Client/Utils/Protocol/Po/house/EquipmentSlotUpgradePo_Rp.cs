using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.house{

/// <summary>
 /// 装备栏升级
 /// </summary>
public class EquipmentSlotUpgradePo_Rp  : BasePo{

	public const int cmd = -312148;
	public const string reflectClassName = "com.hbt.protocol.po.house.EquipmentSlotUpgradePo_Rp";

	public EquipmentSlotUpgradePo_Rp():base() {
		commandId = -312148;
		encryptTypeDown = 0;
	}

	public EquipmentSlotUpgradePo_Rp(MemoryStream inputStream){
		commandId = -312148;
		encryptTypeDown = 0;
		this.setResult(PackageUtil.DecodeInteger(inputStream));
		this.setRoomId(PackageUtil.DecodeInteger(inputStream));
		this.setLevel(PackageUtil.DecodeInteger(inputStream));

		short length0 = PackageUtil.DecodeShort(inputStream);//集合长度
		List<com.hbt.protocol.po.house.EquipmentSoltPo> slots = new List<com.hbt.protocol.po.house.EquipmentSoltPo>();
		for(int i = 0; i < length0; i++){
			PackageUtil.skipInputStream(inputStream, 4);//读4位
			slots.Add(new com.hbt.protocol.po.house.EquipmentSoltPo(inputStream));
		}
		this.setSlots(slots);
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getResult());
		PackageUtil.EncodeInteger(outputStream, getRoomId());
		PackageUtil.EncodeInteger(outputStream, getLevel());

		List<com.hbt.protocol.po.house.EquipmentSoltPo> slots = getSlots();
		short slotslength = (short)(slots == null ? 0 : slots.Count);
		PackageUtil.EncodeShort(outputStream, slotslength);
		for(int i = 0; i < slotslength; i++){
			slots[i].encodeVo(outputStream);
		}
	}

	/// <summary>
	 ///升级结果： DefaultConst.COMM_RESULT_*
	 /// </summary>
	private int result; 

	/// <summary>
	 ///房间ID
	 /// </summary>
	private int roomId; 

	/// <summary>
	 ///升级后装备栏等级
	 /// </summary>
	private int level; 

	/// <summary>
	 ///装备栏
	 /// </summary>
	private List<com.hbt.protocol.po.house.EquipmentSoltPo> slots; 

	/// <summary>
	 ///升级结果： DefaultConst.COMM_RESULT_*
	 /// </summary>
	public void setResult(int result){
		this.result=result;
	}

	/// <summary>
	 ///升级结果： DefaultConst.COMM_RESULT_*
	 /// </summary>
	public int  getResult(){  
		return result; 
	}

	/// <summary>
	 ///房间ID
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
	 ///升级后装备栏等级
	 /// </summary>
	public void setLevel(int level){
		this.level=level;
	}

	/// <summary>
	 ///升级后装备栏等级
	 /// </summary>
	public int  getLevel(){  
		return level; 
	}

	/// <summary>
	 ///装备栏
	 /// </summary>
	public void setSlots(List<com.hbt.protocol.po.house.EquipmentSoltPo> slots){
		this.slots=slots;
	}

	/// <summary>
	 ///装备栏
	 /// </summary>
	public List<com.hbt.protocol.po.house.EquipmentSoltPo> getSlots(){  
		return slots; 
	}

	public override string ToString() {
		return "result:" + result + "," + "roomId:" + roomId + "," + "level:" + level + "," + "slots size:" + slots.Count;
	}

}
}