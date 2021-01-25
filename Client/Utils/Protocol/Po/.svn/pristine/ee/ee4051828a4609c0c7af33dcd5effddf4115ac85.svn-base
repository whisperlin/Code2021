using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.town{

/// <summary>
 /// 城镇资料
 /// </summary>
public class TownInfoPo : BasePo{

	public const int cmd = 246608;
	public const string reflectClassName = "com.hbt.protocol.po.town.TownInfoPo";

	public TownInfoPo():base() {
		commandId = 246608;
		encryptTypeUp = 0;
	}

	public TownInfoPo(MemoryStream inputStream){
		commandId = 246608;
		encryptTypeUp = 0;
		this.setNouse(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getNouse());
	}

	/// <summary>
	 /// 占位
	 /// </summary>
	private int nouse; 

	/// <summary>
	 /// 占位
	 /// </summary>
	public void setNouse(int nouse){
		this.nouse=nouse;
	}

	/// <summary>
	 ///占位
	 /// </summary>
	public int  getNouse(){  
		return nouse; 
	}

	public override string ToString() {
		return "nouse:" + nouse;
	}

}
}