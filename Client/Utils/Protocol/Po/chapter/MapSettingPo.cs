using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.chapter{

/// <summary>
 /// 地图特殊点数据
 /// </summary>
public class MapSettingPo : BasePo{

	public const int cmd = 770899;
	public const string reflectClassName = "com.hbt.protocol.po.chapter.MapSettingPo";

	public MapSettingPo():base() {
		commandId = 770899;
		encryptTypeUp = 0;
	}

	public MapSettingPo(MemoryStream inputStream){
		commandId = 770899;
		encryptTypeUp = 0;
		this.setSettingId(PackageUtil.DecodeInteger(inputStream));
		this.setMapId(PackageUtil.DecodeShort(inputStream));
		this.setMapType(PackageUtil.DecodeInteger(inputStream));
		this.setDialogueId(PackageUtil.DecodeInteger(inputStream));
		this.setEnabled(PackageUtil.DecodeBoolean(inputStream));
		this.setP1(PackageUtil.DecodeInteger(inputStream));
		this.setP2(PackageUtil.DecodeInteger(inputStream));
		this.setS1(PackageUtil.DecodeString(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getSettingId());
		PackageUtil.EncodeShort(outputStream, getMapId());
		PackageUtil.EncodeInteger(outputStream, getMapType());
		PackageUtil.EncodeInteger(outputStream, getDialogueId());
		PackageUtil.EncodeBoolean(outputStream, getEnabled());
		PackageUtil.EncodeInteger(outputStream, getP1());
		PackageUtil.EncodeInteger(outputStream, getP2());
		PackageUtil.EncodeString(outputStream, getS1());
	}

	/// <summary>
	 /// 配置唯一ID  type《16 + gid
	 /// </summary>
	private int settingId; 

	/// <summary>
	 /// 地图块唯一ID(row*rowcount+col)
	 /// </summary>
	private short mapId; 

	/// <summary>
	 /// 地图特殊点(0则为空)对应:ChapterConst.MAP_TYPE_*
	 /// </summary>
	private int mapType; 

	/// <summary>
	 /// 对白ID（0则没对白）
	 /// </summary>
	private int dialogueId; 

	/// <summary>
	 /// 是否可用(使用后就没了)
	 /// </summary>
	private bool enabled; 

	/// <summary>
	 /// 参数1
	 /// </summary>
	private int p1; 

	/// <summary>
	 /// 参数2
	 /// </summary>
	private int p2; 

	/// <summary>
	 /// 字符参数
	 /// </summary>
	private string s1; 

	/// <summary>
	 /// 配置唯一ID  type《16 + gid
	 /// </summary>
	public void setSettingId(int settingId){
		this.settingId=settingId;
	}

	/// <summary>
	 ///配置唯一ID  type《16 + gid
	 /// </summary>
	public int  getSettingId(){  
		return settingId; 
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
	 /// 地图特殊点(0则为空)对应:ChapterConst.MAP_TYPE_*
	 /// </summary>
	public void setMapType(int mapType){
		this.mapType=mapType;
	}

	/// <summary>
	 ///地图特殊点(0则为空)对应:ChapterConst.MAP_TYPE_*
	 /// </summary>
	public int  getMapType(){  
		return mapType; 
	}

	/// <summary>
	 /// 对白ID（0则没对白）
	 /// </summary>
	public void setDialogueId(int dialogueId){
		this.dialogueId=dialogueId;
	}

	/// <summary>
	 ///对白ID（0则没对白）
	 /// </summary>
	public int  getDialogueId(){  
		return dialogueId; 
	}

	/// <summary>
	 /// 是否可用(使用后就没了)
	 /// </summary>
	public void setEnabled(bool enabled){
		this.enabled=enabled;
	}

	/// <summary>
	 ///是否可用(使用后就没了)
	 /// </summary>
	public bool  getEnabled(){  
		return enabled; 
	}

	/// <summary>
	 /// 参数1
	 /// </summary>
	public void setP1(int p1){
		this.p1=p1;
	}

	/// <summary>
	 ///参数1
	 /// </summary>
	public int  getP1(){  
		return p1; 
	}

	/// <summary>
	 /// 参数2
	 /// </summary>
	public void setP2(int p2){
		this.p2=p2;
	}

	/// <summary>
	 ///参数2
	 /// </summary>
	public int  getP2(){  
		return p2; 
	}

	/// <summary>
	 /// 字符参数
	 /// </summary>
	public void setS1(string s1){
		this.s1=s1;
	}

	/// <summary>
	 ///字符参数
	 /// </summary>
	public string  getS1(){  
		return s1; 
	}

	public override string ToString() {
		return "settingId:" + settingId + "," + "mapId:" + mapId + "," + "mapType:" + mapType + "," + "dialogueId:" + dialogueId + "," + "enabled:" + enabled + "," + "p1:" + p1 + "," + "p2:" + p2 + "," + "s1:" + s1;
	}

}
}