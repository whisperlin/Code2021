using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.district{

/// <summary>
 /// 街区资料
 /// </summary>
public class AreaInfoPo : BasePo{

	public const int cmd = 443218;
	public const string reflectClassName = "com.hbt.protocol.po.district.AreaInfoPo";

	public AreaInfoPo():base() {
		commandId = 443218;
		encryptTypeUp = 0;
	}

	public AreaInfoPo(MemoryStream inputStream){
		commandId = 443218;
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