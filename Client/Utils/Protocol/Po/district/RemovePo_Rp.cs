using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.district{

/// <summary>
 /// 卸下建筑
 /// </summary>
public class RemovePo_Rp  : BasePo{

	public const int cmd = -443222;
	public const string reflectClassName = "com.hbt.protocol.po.district.RemovePo_Rp";

	public RemovePo_Rp():base() {
		commandId = -443222;
		encryptTypeDown = 0;
	}

	public RemovePo_Rp(MemoryStream inputStream){
		commandId = -443222;
		encryptTypeDown = 0;
		this.setId(PackageUtil.DecodeInteger(inputStream));
		this.setItemUuid(PackageUtil.DecodeLong(inputStream));
		this.setReturnCoin(PackageUtil.DecodeInteger(inputStream));
		this.setResult(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getId());
		PackageUtil.EncodeLong(outputStream, getItemUuid());
		PackageUtil.EncodeInteger(outputStream, getReturnCoin());
		PackageUtil.EncodeInteger(outputStream, getResult());
	}

	/// <summary>
	 ///唯一ID
	 /// </summary>
	private int id; 

	/// <summary>
	 ///对应道具ID
	 /// </summary>
	private ulong itemUuid; 

	/// <summary>
	 ///返还金币
	 /// </summary>
	private int returnCoin; 

	/// <summary>
	 ///结果: DefaultConst.COMM_RESULT_*
	 /// </summary>
	private int result; 

	/// <summary>
	 ///唯一ID
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

	/// <summary>
	 ///对应道具ID
	 /// </summary>
	public void setItemUuid(ulong itemUuid){
		this.itemUuid=itemUuid;
	}

	/// <summary>
	 ///对应道具ID
	 /// </summary>
	public ulong  getItemUuid(){  
		return itemUuid; 
	}

	/// <summary>
	 ///返还金币
	 /// </summary>
	public void setReturnCoin(int returnCoin){
		this.returnCoin=returnCoin;
	}

	/// <summary>
	 ///返还金币
	 /// </summary>
	public int  getReturnCoin(){  
		return returnCoin; 
	}

	/// <summary>
	 ///结果: DefaultConst.COMM_RESULT_*
	 /// </summary>
	public void setResult(int result){
		this.result=result;
	}

	/// <summary>
	 ///结果: DefaultConst.COMM_RESULT_*
	 /// </summary>
	public int  getResult(){  
		return result; 
	}

	public override string ToString() {
		return "id:" + id + "," + "itemUuid:" + itemUuid + "," + "returnCoin:" + returnCoin + "," + "result:" + result;
	}

}
}