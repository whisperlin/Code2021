using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.district{

/// <summary>
 /// 升级建筑
 /// </summary>
public class UpgradePo_Rp  : BasePo{

	public const int cmd = -443223;
	public const string reflectClassName = "com.hbt.protocol.po.district.UpgradePo_Rp";

	public UpgradePo_Rp():base() {
		commandId = -443223;
		encryptTypeDown = 0;
	}

	public UpgradePo_Rp(MemoryStream inputStream){
		commandId = -443223;
		encryptTypeDown = 0;
		this.setId(PackageUtil.DecodeInteger(inputStream));
		this.setItemUuid(PackageUtil.DecodeLong(inputStream));
		this.setItemId(PackageUtil.DecodeInteger(inputStream));
		this.setBuildId(PackageUtil.DecodeInteger(inputStream));
		this.setLevel(PackageUtil.DecodeInteger(inputStream));
		this.setResult(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getId());
		PackageUtil.EncodeLong(outputStream, getItemUuid());
		PackageUtil.EncodeInteger(outputStream, getItemId());
		PackageUtil.EncodeInteger(outputStream, getBuildId());
		PackageUtil.EncodeInteger(outputStream, getLevel());
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
	 ///道具类ID
	 /// </summary>
	private int itemId; 

	/// <summary>
	 ///建筑ID
	 /// </summary>
	private int buildId; 

	/// <summary>
	 ///建筑等级
	 /// </summary>
	private int level; 

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
	 ///道具类ID
	 /// </summary>
	public void setItemId(int itemId){
		this.itemId=itemId;
	}

	/// <summary>
	 ///道具类ID
	 /// </summary>
	public int  getItemId(){  
		return itemId; 
	}

	/// <summary>
	 ///建筑ID
	 /// </summary>
	public void setBuildId(int buildId){
		this.buildId=buildId;
	}

	/// <summary>
	 ///建筑ID
	 /// </summary>
	public int  getBuildId(){  
		return buildId; 
	}

	/// <summary>
	 ///建筑等级
	 /// </summary>
	public void setLevel(int level){
		this.level=level;
	}

	/// <summary>
	 ///建筑等级
	 /// </summary>
	public int  getLevel(){  
		return level; 
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
		return "id:" + id + "," + "itemUuid:" + itemUuid + "," + "itemId:" + itemId + "," + "buildId:" + buildId + "," + "level:" + level + "," + "result:" + result;
	}

}
}