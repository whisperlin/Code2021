using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.town{

/// <summary>
 /// 升级食品工厂
 /// </summary>
public class UpgradeFoodFactoryPo_Rp  : BasePo{

	public const int cmd = -246609;
	public const string reflectClassName = "com.hbt.protocol.po.town.UpgradeFoodFactoryPo_Rp";

	public UpgradeFoodFactoryPo_Rp():base() {
		commandId = -246609;
		encryptTypeDown = 0;
	}

	public UpgradeFoodFactoryPo_Rp(MemoryStream inputStream){
		commandId = -246609;
		encryptTypeDown = 0;
		this.setResult(PackageUtil.DecodeInteger(inputStream));
		this.setLevel(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getResult());
		PackageUtil.EncodeInteger(outputStream, getLevel());
	}

	/// <summary>
	 ///结果: Town.BUILD_RESULT_* 
	 /// </summary>
	private int result; 

	/// <summary>
	 ///升级后等级
	 /// </summary>
	private int level; 

	/// <summary>
	 ///结果: Town.BUILD_RESULT_* 
	 /// </summary>
	public void setResult(int result){
		this.result=result;
	}

	/// <summary>
	 ///结果: Town.BUILD_RESULT_* 
	 /// </summary>
	public int  getResult(){  
		return result; 
	}

	/// <summary>
	 ///升级后等级
	 /// </summary>
	public void setLevel(int level){
		this.level=level;
	}

	/// <summary>
	 ///升级后等级
	 /// </summary>
	public int  getLevel(){  
		return level; 
	}

	public override string ToString() {
		return "result:" + result + "," + "level:" + level;
	}

}
}