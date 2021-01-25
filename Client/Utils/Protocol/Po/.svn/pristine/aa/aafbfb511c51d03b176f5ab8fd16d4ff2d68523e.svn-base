using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.item{

/// <summary>
 /// 单个ITEM
 /// </summary>
public class ItemInfoPo : BasePo{

	public const int cmd = 377682;
	public const string reflectClassName = "com.hbt.protocol.po.item.ItemInfoPo";

	public ItemInfoPo():base() {
		commandId = 377682;
		encryptTypeUp = 0;
	}

	public ItemInfoPo(MemoryStream inputStream){
		commandId = 377682;
		encryptTypeUp = 0;
		this.setUuid(PackageUtil.DecodeLong(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeLong(outputStream, getUuid());
	}

	/// <summary>
	 /// 唯一ID
	 /// </summary>
	private ulong uuid; 

	/// <summary>
	 /// 唯一ID
	 /// </summary>
	public void setUuid(ulong uuid){
		this.uuid=uuid;
	}

	/// <summary>
	 ///唯一ID
	 /// </summary>
	public ulong  getUuid(){  
		return uuid; 
	}

	public override string ToString() {
		return "uuid:" + uuid;
	}

}
}