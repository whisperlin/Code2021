using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.town{

/// <summary>
 /// 升级食品工厂
 /// </summary>
public class UpgradeFoodFactoryPo : BasePo{

	public const int cmd = 246609;
	public const string reflectClassName = "com.hbt.protocol.po.town.UpgradeFoodFactoryPo";

	public UpgradeFoodFactoryPo():base() {
		commandId = 246609;
		encryptTypeUp = 0;
	}

	public UpgradeFoodFactoryPo(MemoryStream inputStream){
		commandId = 246609;
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