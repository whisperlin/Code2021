using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.house{

/// <summary>
 /// 宠物列表
 /// </summary>
public class PetListPo : BasePo{

	public const int cmd = 312155;
	public const string reflectClassName = "com.hbt.protocol.po.house.PetListPo";

	public PetListPo():base() {
		commandId = 312155;
		encryptTypeUp = 0;
	}

	public PetListPo(MemoryStream inputStream){
		commandId = 312155;
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