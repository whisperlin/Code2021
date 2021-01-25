using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.house{

/// <summary>
 /// 居民楼房间
 /// </summary>
public class HouseRoomPo : BasePo{

	public const int cmd = 312145;
	public const string reflectClassName = "com.hbt.protocol.po.house.HouseRoomPo";

	public HouseRoomPo():base() {
		commandId = 312145;
		encryptTypeUp = 0;
	}

	public HouseRoomPo(MemoryStream inputStream){
		commandId = 312145;
		encryptTypeUp = 0;
		this.setRoomId(PackageUtil.DecodeInteger(inputStream));
		this.setPetsId(PackageUtil.DecodeInteger(inputStream));

		short length0 = PackageUtil.DecodeShort(inputStream);//集合长度
		List<com.hbt.protocol.po.house.EquipmentSoltPo> slots = new List<com.hbt.protocol.po.house.EquipmentSoltPo>();
		for(int i = 0; i < length0; i++){
			PackageUtil.skipInputStream(inputStream, 4);//读4位
			slots.Add(new com.hbt.protocol.po.house.EquipmentSoltPo(inputStream));
		}
		this.setSlots(slots);
		this.setFurnitures(PackageUtil.DecodeString(inputStream));
		this.setLevel(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getRoomId());
		PackageUtil.EncodeInteger(outputStream, getPetsId());

		List<com.hbt.protocol.po.house.EquipmentSoltPo> slots = getSlots();
		short slotslength = (short)(slots == null ? 0 : slots.Count);
		PackageUtil.EncodeShort(outputStream, slotslength);
		for(int i = 0; i < slotslength; i++){
			slots[i].encodeVo(outputStream);
		}
		PackageUtil.EncodeString(outputStream, getFurnitures());
		PackageUtil.EncodeInteger(outputStream, getLevel());
	}

	/// <summary>
	 /// 房间ID
	 /// </summary>
	private int roomId; 

	/// <summary>
	 /// 宠物ID(未有进驻就是-1)
	 /// </summary>
	private int petsId; 

	/// <summary>
	 /// 装备栏
	 /// </summary>
	private List<com.hbt.protocol.po.house.EquipmentSoltPo> slots; 

	/// <summary>
	 /// 家具摆放(帮客户端存)
	 /// </summary>
	private string furnitures; 

	/// <summary>
	 /// 装备栏等级
	 /// </summary>
	private int level; 

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
	 /// 宠物ID(未有进驻就是-1)
	 /// </summary>
	public void setPetsId(int petsId){
		this.petsId=petsId;
	}

	/// <summary>
	 ///宠物ID(未有进驻就是-1)
	 /// </summary>
	public int  getPetsId(){  
		return petsId; 
	}

	/// <summary>
	 /// 装备栏
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

	/// <summary>
	 /// 家具摆放(帮客户端存)
	 /// </summary>
	public void setFurnitures(string furnitures){
		this.furnitures=furnitures;
	}

	/// <summary>
	 ///家具摆放(帮客户端存)
	 /// </summary>
	public string  getFurnitures(){  
		return furnitures; 
	}

	/// <summary>
	 /// 装备栏等级
	 /// </summary>
	public void setLevel(int level){
		this.level=level;
	}

	/// <summary>
	 ///装备栏等级
	 /// </summary>
	public int  getLevel(){  
		return level; 
	}

	public override string ToString() {
		return "roomId:" + roomId + "," + "petsId:" + petsId + "," + "slots size:" + slots.Count + "," + "furnitures:" + furnitures + "," + "level:" + level;
	}

}
}