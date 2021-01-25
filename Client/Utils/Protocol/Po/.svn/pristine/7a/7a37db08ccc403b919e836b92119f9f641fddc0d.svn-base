using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.town{

/// <summary>
 /// 净化食物
 /// </summary>
public class PurifyFoodPo : BasePo{

	public const int cmd = 246617;
	public const string reflectClassName = "com.hbt.protocol.po.town.PurifyFoodPo";

	public PurifyFoodPo():base() {
		commandId = 246617;
		encryptTypeUp = 0;
	}

	public PurifyFoodPo(MemoryStream inputStream){
		commandId = 246617;
		encryptTypeUp = 0;
		this.setItemUuid(PackageUtil.DecodeLong(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeLong(outputStream, getItemUuid());
	}

	/// <summary>
	 /// 道具ID
	 /// </summary>
	private ulong itemUuid; 

	/// <summary>
	 /// 道具ID
	 /// </summary>
	public void setItemUuid(ulong itemUuid){
		this.itemUuid=itemUuid;
	}

	/// <summary>
	 ///道具ID
	 /// </summary>
	public ulong  getItemUuid(){  
		return itemUuid; 
	}

	public override string ToString() {
		return "itemUuid:" + itemUuid;
	}

}
}