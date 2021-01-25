using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.house{

/// <summary>
 /// 居民楼资料
 /// </summary>
public class HouseInfoPo_Rp  : BasePo{

	public const int cmd = -312144;
	public const string reflectClassName = "com.hbt.protocol.po.house.HouseInfoPo_Rp";

	public HouseInfoPo_Rp():base() {
		commandId = -312144;
		encryptTypeDown = 0;
	}

	public HouseInfoPo_Rp(MemoryStream inputStream){
		commandId = -312144;
		encryptTypeDown = 0;

		short length0 = PackageUtil.DecodeShort(inputStream);//集合长度
		List<com.hbt.protocol.po.house.HouseRoomPo> rooms = new List<com.hbt.protocol.po.house.HouseRoomPo>();
		for(int i = 0; i < length0; i++){
			PackageUtil.skipInputStream(inputStream, 4);//读4位
			rooms.Add(new com.hbt.protocol.po.house.HouseRoomPo(inputStream));
		}
		this.setRooms(rooms);
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);

		List<com.hbt.protocol.po.house.HouseRoomPo> rooms = getRooms();
		short roomslength = (short)(rooms == null ? 0 : rooms.Count);
		PackageUtil.EncodeShort(outputStream, roomslength);
		for(int i = 0; i < roomslength; i++){
			rooms[i].encodeVo(outputStream);
		}
	}

	/// <summary>
	 ///居民楼房间
	 /// </summary>
	private List<com.hbt.protocol.po.house.HouseRoomPo> rooms; 

	/// <summary>
	 ///居民楼房间
	 /// </summary>
	public void setRooms(List<com.hbt.protocol.po.house.HouseRoomPo> rooms){
		this.rooms=rooms;
	}

	/// <summary>
	 ///居民楼房间
	 /// </summary>
	public List<com.hbt.protocol.po.house.HouseRoomPo> getRooms(){  
		return rooms; 
	}

	public override string ToString() {
		return "rooms size:" + rooms.Count;
	}

}
}