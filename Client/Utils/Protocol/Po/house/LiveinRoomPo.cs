using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.house{

/// <summary>
 /// 宠物入住房间
 /// </summary>
public class LiveinRoomPo : BasePo{

	public const int cmd = 312154;
	public const string reflectClassName = "com.hbt.protocol.po.house.LiveinRoomPo";

	public LiveinRoomPo():base() {
		commandId = 312154;
		encryptTypeUp = 0;
	}

	public LiveinRoomPo(MemoryStream inputStream){
		commandId = 312154;
		encryptTypeUp = 0;
		this.setRoomId(PackageUtil.DecodeInteger(inputStream));
		this.setPetId(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getRoomId());
		PackageUtil.EncodeInteger(outputStream, getPetId());
	}

	/// <summary>
	 /// 房间ID
	 /// </summary>
	private int roomId; 

	/// <summary>
	 /// 宠物ID(-1为拆下宠物)
	 /// </summary>
	private int petId; 

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
	 /// 宠物ID(-1为拆下宠物)
	 /// </summary>
	public void setPetId(int petId){
		this.petId=petId;
	}

	/// <summary>
	 ///宠物ID(-1为拆下宠物)
	 /// </summary>
	public int  getPetId(){  
		return petId; 
	}

	public override string ToString() {
		return "roomId:" + roomId + "," + "petId:" + petId;
	}

}
}