using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.chapter{

/// <summary>
 /// 执行地图元素对话框（如宝箱，NPC等）
 /// </summary>
public class ExcuteMapDialoguePo : BasePo{

	public const int cmd = 770908;
	public const string reflectClassName = "com.hbt.protocol.po.chapter.ExcuteMapDialoguePo";

	public ExcuteMapDialoguePo():base() {
		commandId = 770908;
		encryptTypeUp = 0;
	}

	public ExcuteMapDialoguePo(MemoryStream inputStream){
		commandId = 770908;
		encryptTypeUp = 0;
		this.setMapSettingId(PackageUtil.DecodeInteger(inputStream));
		this.setMapDialogueId(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getMapSettingId());
		PackageUtil.EncodeInteger(outputStream, getMapDialogueId());
	}

	/// <summary>
	 /// 关卡对应事件ID
	 /// </summary>
	private int mapSettingId; 

	/// <summary>
	 /// 事件对应的对白ID
	 /// </summary>
	private int mapDialogueId; 

	/// <summary>
	 /// 关卡对应事件ID
	 /// </summary>
	public void setMapSettingId(int mapSettingId){
		this.mapSettingId=mapSettingId;
	}

	/// <summary>
	 ///关卡对应事件ID
	 /// </summary>
	public int  getMapSettingId(){  
		return mapSettingId; 
	}

	/// <summary>
	 /// 事件对应的对白ID
	 /// </summary>
	public void setMapDialogueId(int mapDialogueId){
		this.mapDialogueId=mapDialogueId;
	}

	/// <summary>
	 ///事件对应的对白ID
	 /// </summary>
	public int  getMapDialogueId(){  
		return mapDialogueId; 
	}

	public override string ToString() {
		return "mapSettingId:" + mapSettingId + "," + "mapDialogueId:" + mapDialogueId;
	}

}
}