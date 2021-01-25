using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.item{

/// <summary>
 /// 装备合成
 /// </summary>
public class EquipmentCombinePo_Rp  : BasePo{

	public const int cmd = -377683;
	public const string reflectClassName = "com.hbt.protocol.po.item.EquipmentCombinePo_Rp";

	public EquipmentCombinePo_Rp():base() {
		commandId = -377683;
		encryptTypeDown = 0;
	}

	public EquipmentCombinePo_Rp(MemoryStream inputStream){
		commandId = -377683;
		encryptTypeDown = 0;
		this.setResult(PackageUtil.DecodeInteger(inputStream));
		this.setItemUuid(PackageUtil.DecodeLong(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getResult());
		PackageUtil.EncodeLong(outputStream, getItemUuid());
	}

	/// <summary>
	 ///合成结果： SLOT_UPGRADE_RESULT_*
	 /// </summary>
	private int result; 

	/// <summary>
	 ///升级后道具ID
	 /// </summary>
	private ulong itemUuid; 

	/// <summary>
	 ///合成结果： SLOT_UPGRADE_RESULT_*
	 /// </summary>
	public void setResult(int result){
		this.result=result;
	}

	/// <summary>
	 ///合成结果： SLOT_UPGRADE_RESULT_*
	 /// </summary>
	public int  getResult(){  
		return result; 
	}

	/// <summary>
	 ///升级后道具ID
	 /// </summary>
	public void setItemUuid(ulong itemUuid){
		this.itemUuid=itemUuid;
	}

	/// <summary>
	 ///升级后道具ID
	 /// </summary>
	public ulong  getItemUuid(){  
		return itemUuid; 
	}

	public override string ToString() {
		return "result:" + result + "," + "itemUuid:" + itemUuid;
	}

}
}