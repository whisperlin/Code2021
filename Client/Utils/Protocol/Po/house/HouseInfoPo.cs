using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.house{

/// <summary>
 /// 居民楼资料
 /// </summary>
public class HouseInfoPo : BasePo{

	public const int cmd = 312144;
	public const string reflectClassName = "com.hbt.protocol.po.house.HouseInfoPo";

	public HouseInfoPo():base() {
		commandId = 312144;
		encryptTypeUp = 0;
	}

	public HouseInfoPo(MemoryStream inputStream){
		commandId = 312144;
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