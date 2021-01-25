using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.house{

/// <summary>
 /// 开启装备栏
 /// </summary>
public class EquipmentSlotOpenPo_Rp  : BasePo{

	public const int cmd = -312147;
	public const string reflectClassName = "com.hbt.protocol.po.house.EquipmentSlotOpenPo_Rp";

	public EquipmentSlotOpenPo_Rp():base() {
		commandId = -312147;
		encryptTypeDown = 0;
	}

	public EquipmentSlotOpenPo_Rp(MemoryStream inputStream){
		commandId = -312147;
		encryptTypeDown = 0;
		this.setResult(PackageUtil.DecodeInteger(inputStream));
		this.setRoomId(PackageUtil.DecodeInteger(inputStream));
		this.setSlotId(PackageUtil.DecodeInteger(inputStream));

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
		PackageUtil.EncodeInteger(outputStream, getSlotId());

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
	 ///装备栏ID(0-2)
	 /// </summary>
	private int slotId; 

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
	 ///装备栏ID(0-2)
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
		return "result:" + result + "," + "roomId:" + roomId + "," + "slotId:" + slotId + "," + "slots size:" + slots.Count;
	}

}
}