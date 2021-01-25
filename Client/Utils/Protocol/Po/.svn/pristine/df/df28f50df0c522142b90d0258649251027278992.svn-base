using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.district{

/// <summary>
 /// 卸下建筑
 /// </summary>
public class RemovePo : BasePo{

	public const int cmd = 443222;
	public const string reflectClassName = "com.hbt.protocol.po.district.RemovePo";

	public RemovePo():base() {
		commandId = 443222;
		encryptTypeUp = 0;
	}

	public RemovePo(MemoryStream inputStream){
		commandId = 443222;
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