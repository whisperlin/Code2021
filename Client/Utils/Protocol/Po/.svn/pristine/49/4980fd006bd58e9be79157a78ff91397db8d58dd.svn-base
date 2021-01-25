using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.battle{

/// <summary>
 /// 进入冒险关卡战斗房间
 /// </summary>
public class EnterChapterBattlePo : BasePo{

	public const int cmd = 705364;
	public const string reflectClassName = "com.hbt.protocol.po.battle.EnterChapterBattlePo";

	public EnterChapterBattlePo():base() {
		commandId = 705364;
		encryptTypeUp = 0;
	}

	public EnterChapterBattlePo(MemoryStream inputStream){
		commandId = 705364;
		encryptTypeUp = 0;
		this.setMapSettingId(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getMapSettingId());
	}

	/// <summary>
	 /// 关卡对应事件ID
	 /// </summary>
	private int mapSettingId; 

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

	public override string ToString() {
		return "mapSettingId:" + mapSettingId;
	}

}
}