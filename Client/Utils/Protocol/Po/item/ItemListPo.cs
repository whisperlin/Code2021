using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.item{

/// <summary>
 /// 道具列表
 /// </summary>
public class ItemListPo : BasePo{

	public const int cmd = 377680;
	public const string reflectClassName = "com.hbt.protocol.po.item.ItemListPo";

	public ItemListPo():base() {
		commandId = 377680;
		encryptTypeUp = 0;
	}

	public ItemListPo(MemoryStream inputStream){
		commandId = 377680;
		encryptTypeUp = 0;
		this.setCtype(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getCtype());
	}

	/// <summary>
	 /// 分类ID(传0则显示所有)
	 /// </summary>
	private int ctype; 

	/// <summary>
	 /// 分类ID(传0则显示所有)
	 /// </summary>
	public void setCtype(int ctype){
		this.ctype=ctype;
	}

	/// <summary>
	 ///分类ID(传0则显示所有)
	 /// </summary>
	public int  getCtype(){  
		return ctype; 
	}

	public override string ToString() {
		return "ctype:" + ctype;
	}

}
}