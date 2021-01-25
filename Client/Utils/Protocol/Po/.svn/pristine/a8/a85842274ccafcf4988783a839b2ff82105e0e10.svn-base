using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.district{

/// <summary>
 /// 打开小区域
 /// </summary>
public class OpenAreaPo : BasePo{

	public const int cmd = 443220;
	public const string reflectClassName = "com.hbt.protocol.po.district.OpenAreaPo";

	public OpenAreaPo():base() {
		commandId = 443220;
		encryptTypeUp = 0;
	}

	public OpenAreaPo(MemoryStream inputStream){
		commandId = 443220;
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