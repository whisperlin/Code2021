using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.chapter{

/// <summary>
 /// 获取地图配置数据
 /// </summary>
public class GetMapSettingsPo_Rp  : BasePo{

	public const int cmd = -770904;
	public const string reflectClassName = "com.hbt.protocol.po.chapter.GetMapSettingsPo_Rp";

	public GetMapSettingsPo_Rp():base() {
		commandId = -770904;
		encryptTypeDown = 0;
	}

	public GetMapSettingsPo_Rp(MemoryStream inputStream){
		commandId = -770904;
		encryptTypeDown = 0;
		this.setChapterId(PackageUtil.DecodeInteger(inputStream));

		short length0 = PackageUtil.DecodeShort(inputStream);//集合长度
		List<com.hbt.protocol.po.chapter.MapSettingPo> settings = new List<com.hbt.protocol.po.chapter.MapSettingPo>();
		for(int i = 0; i < length0; i++){
			PackageUtil.skipInputStream(inputStream, 4);//读4位
			settings.Add(new com.hbt.protocol.po.chapter.MapSettingPo(inputStream));
		}
		this.setSettings(settings);
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getChapterId());

		List<com.hbt.protocol.po.chapter.MapSettingPo> settings = getSettings();
		short settingslength = (short)(settings == null ? 0 : settings.Count);
		PackageUtil.EncodeShort(outputStream, settingslength);
		for(int i = 0; i < settingslength; i++){
			settings[i].encodeVo(outputStream);
		}
	}

	/// <summary>
	 ///关卡ID
	 /// </summary>
	private int chapterId; 

	/// <summary>
	 ///地图配置数据
	 /// </summary>
	private List<com.hbt.protocol.po.chapter.MapSettingPo> settings; 

	/// <summary>
	 ///关卡ID
	 /// </summary>
	public void setChapterId(int chapterId){
		this.chapterId=chapterId;
	}

	/// <summary>
	 ///关卡ID
	 /// </summary>
	public int  getChapterId(){  
		return chapterId; 
	}

	/// <summary>
	 ///地图配置数据
	 /// </summary>
	public void setSettings(List<com.hbt.protocol.po.chapter.MapSettingPo> settings){
		this.settings=settings;
	}

	/// <summary>
	 ///地图配置数据
	 /// </summary>
	public List<com.hbt.protocol.po.chapter.MapSettingPo> getSettings(){  
		return settings; 
	}

	public override string ToString() {
		return "chapterId:" + chapterId + "," + "settings size:" + settings.Count;
	}

}
}