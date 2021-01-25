using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.chapter{

/// <summary>
 /// 地图数据
 /// </summary>
public class MapNodePo : BasePo{

	public const int cmd = 770897;
	public const string reflectClassName = "com.hbt.protocol.po.chapter.MapNodePo";

	public MapNodePo():base() {
		commandId = 770897;
		encryptTypeUp = 0;
	}

	public MapNodePo(MemoryStream inputStream){
		commandId = 770897;
		encryptTypeUp = 0;
		this.setId(PackageUtil.DecodeShort(inputStream));
		this.setMapId(PackageUtil.DecodeShort(inputStream));
		this.setTileId(PackageUtil.DecodeShort(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeShort(outputStream, getId());
		PackageUtil.EncodeShort(outputStream, getMapId());
		PackageUtil.EncodeShort(outputStream, getTileId());
	}

	/// <summary>
	 /// mapNodes的索引ID
	 /// </summary>
	private short id; 

	/// <summary>
	 /// 地图块唯一ID(row*rowcount+col)
	 /// </summary>
	private short mapId; 

	/// <summary>
	 /// 地块ID
	 /// </summary>
	private short tileId; 

	/// <summary>
	 /// mapNodes的索引ID
	 /// </summary>
	public void setId(short id){
		this.id=id;
	}

	/// <summary>
	 ///mapNodes的索引ID
	 /// </summary>
	public short  getId(){  
		return id; 
	}

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
	 /// 地块ID
	 /// </summary>
	public void setTileId(short tileId){
		this.tileId=tileId;
	}

	/// <summary>
	 ///地块ID
	 /// </summary>
	public short  getTileId(){  
		return tileId; 
	}

	public override string ToString() {
		return "id:" + id + "," + "mapId:" + mapId + "," + "tileId:" + tileId;
	}

}
}