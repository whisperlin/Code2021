using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.chapter{

/// <summary>
 /// 地图状态数据
 /// </summary>
public class MapStatusPo : BasePo{

	public const int cmd = 770898;
	public const string reflectClassName = "com.hbt.protocol.po.chapter.MapStatusPo";

	public MapStatusPo():base() {
		commandId = 770898;
		encryptTypeUp = 0;
	}

	public MapStatusPo(MemoryStream inputStream){
		commandId = 770898;
		encryptTypeUp = 0;
		this.setMapId(PackageUtil.DecodeShort(inputStream));
		this.setWalked(PackageUtil.DecodeBoolean(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeShort(outputStream, getMapId());
		PackageUtil.EncodeBoolean(outputStream, getWalked());
	}

	/// <summary>
	 /// 地图块唯一ID(row*rowcount+col)
	 /// </summary>
	private short mapId; 

	/// <summary>
	 /// 是否已行走
	 /// </summary>
	private bool walked; 

	/// <summary>
	 /// 地图块唯一ID(row*rowcount+col)
	 /// </summary>
	public void setMapId(short mapId){
		this.mapId=mapId;
	}

	/// <summary>
	 ///地图块唯一ID(row*rowcount+col)
	 /// </summary>
	public short  getMapId(){  
		return mapId; 
	}

	/// <summary>
	 /// 是否已行走
	 /// </summary>
	public void setWalked(bool walked){
		this.walked=walked;
	}

	/// <summary>
	 ///是否已行走
	 /// </summary>
	public bool  getWalked(){  
		return walked; 
	}

	public override string ToString() {
		return "mapId:" + mapId + "," + "walked:" + walked;
	}

}
}