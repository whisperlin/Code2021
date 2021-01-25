using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.town{

/// <summary>
 /// 升级居民楼
 /// </summary>
public class UpgradeHousePo : BasePo{

	public const int cmd = 246610;
	public const string reflectClassName = "com.hbt.protocol.po.town.UpgradeHousePo";

	public UpgradeHousePo():base() {
		commandId = 246610;
		encryptTypeUp = 0;
	}

	public UpgradeHousePo(MemoryStream inputStream){
		commandId = 246610;
		encryptTypeUp = 0;
		this.setLevel(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getLevel());
	}

	/// <summary>
	 /// 需要升级的建筑的当前等级
	 /// </summary>
	private int level; 

	/// <summary>
	 /// 需要升级的建筑的当前等级
	 /// </summary>
	public void setLevel(int level){
		this.level=level;
	}

	/// <summary>
	 ///需要升级的建筑的当前等级
	 /// </summary>
	public int  getLevel(){  
		return level; 
	}

	public override string ToString() {
		return "level:" + level;
	}

}
}