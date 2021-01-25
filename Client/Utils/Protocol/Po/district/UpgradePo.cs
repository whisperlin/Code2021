using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.district{

/// <summary>
 /// 升级建筑
 /// </summary>
public class UpgradePo : BasePo{

	public const int cmd = 443223;
	public const string reflectClassName = "com.hbt.protocol.po.district.UpgradePo";

	public UpgradePo():base() {
		commandId = 443223;
		encryptTypeUp = 0;
	}

	public UpgradePo(MemoryStream inputStream){
		commandId = 443223;
		encryptTypeUp = 0;
		this.setId(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getId());
	}

	/// <summary>
	 /// 唯一ID
	 /// </summary>
	private int id; 

	/// <summary>
	 /// 唯一ID
	 /// </summary>
	public void setId(int id){
		this.id=id;
	}

	/// <summary>
	 ///唯一ID
	 /// </summary>
	public int  getId(){  
		return id; 
	}

	public override string ToString() {
		return "id:" + id;
	}

}
}