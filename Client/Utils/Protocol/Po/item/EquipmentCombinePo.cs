using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.item{

/// <summary>
 /// 装备合成
 /// </summary>
public class EquipmentCombinePo : BasePo{

	public const int cmd = 377683;
	public const string reflectClassName = "com.hbt.protocol.po.item.EquipmentCombinePo";

	public EquipmentCombinePo():base() {
		commandId = 377683;
		encryptTypeUp = 0;
	}

	public EquipmentCombinePo(MemoryStream inputStream){
		commandId = 377683;
		encryptTypeUp = 0;
		this.setCombineItemUuid1(PackageUtil.DecodeLong(inputStream));
		this.setCombineItemUuid2(PackageUtil.DecodeLong(inputStream));
		this.setCombineItemUuid3(PackageUtil.DecodeLong(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeLong(outputStream, getCombineItemUuid1());
		PackageUtil.EncodeLong(outputStream, getCombineItemUuid2());
		PackageUtil.EncodeLong(outputStream, getCombineItemUuid3());
	}

	/// <summary>
	 /// 道具ID1
	 /// </summary>
	private ulong combineItemUuid1; 

	/// <summary>
	 /// 道具ID2
	 /// </summary>
	private ulong combineItemUuid2; 

	/// <summary>
	 /// 道具ID3
	 /// </summary>
	private ulong combineItemUuid3; 

	/// <summary>
	 /// 道具ID1
	 /// </summary>
	public void setCombineItemUuid1(ulong combineItemUuid1){
		this.combineItemUuid1=combineItemUuid1;
	}

	/// <summary>
	 ///道具ID1
	 /// </summary>
	public ulong  getCombineItemUuid1(){  
		return combineItemUuid1; 
	}

	/// <summary>
	 /// 道具ID2
	 /// </summary>
	public void setCombineItemUuid2(ulong combineItemUuid2){
		this.combineItemUuid2=combineItemUuid2;
	}

	/// <summary>
	 ///道具ID2
	 /// </summary>
	public ulong  getCombineItemUuid2(){  
		return combineItemUuid2; 
	}

	/// <summary>
	 /// 道具ID3
	 /// </summary>
	public void setCombineItemUuid3(ulong combineItemUuid3){
		this.combineItemUuid3=combineItemUuid3;
	}

	/// <summary>
	 ///道具ID3
	 /// </summary>
	public ulong  getCombineItemUuid3(){  
		return combineItemUuid3; 
	}

	public override string ToString() {
		return "combineItemUuid1:" + combineItemUuid1 + "," + "combineItemUuid2:" + combineItemUuid2 + "," + "combineItemUuid3:" + combineItemUuid3;
	}

}
}