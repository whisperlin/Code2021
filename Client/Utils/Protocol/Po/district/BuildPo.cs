using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.district{

/// <summary>
 /// 建造/替换建筑
 /// </summary>
public class BuildPo : BasePo{

	public const int cmd = 443221;
	public const string reflectClassName = "com.hbt.protocol.po.district.BuildPo";

	public BuildPo():base() {
		commandId = 443221;
		encryptTypeUp = 0;
	}

	public BuildPo(MemoryStream inputStream){
		commandId = 443221;
		encryptTypeUp = 0;
		this.setId(PackageUtil.DecodeInteger(inputStream));
		this.setKid(PackageUtil.DecodeInteger(inputStream));
		this.setBuildId(PackageUtil.DecodeInteger(inputStream));
		this.setItemUuid(PackageUtil.DecodeLong(inputStream));
		this.setLayout(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getId());
		PackageUtil.EncodeInteger(outputStream, getKid());
		PackageUtil.EncodeInteger(outputStream, getBuildId());
		PackageUtil.EncodeLong(outputStream, getItemUuid());
		PackageUtil.EncodeInteger(outputStream, getLayout());
	}

	/// <summary>
	 /// 唯一ID
	 /// </summary>
	private int id; 

	/// <summary>
	 /// 类型（1：提供产能 2：提供属性）
	 /// </summary>
	private int kid; 

	/// <summary>
	 /// 建筑ID
	 /// </summary>
	private int buildId; 

	/// <summary>
	 /// 对应道具ID
	 /// </summary>
	private ulong itemUuid; 

	/// <summary>
	 /// 摆位，默认0
	 /// </summary>
	private int layout; 

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

	/// <summary>
	 /// 类型（1：提供产能 2：提供属性）
	 /// </summary>
	public void setKid(int kid){
		this.kid=kid;
	}

	/// <summary>
	 ///类型（1：提供产能 2：提供属性）
	 /// </summary>
	public int  getKid(){  
		return kid; 
	}

	/// <summary>
	 /// 建筑ID
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
	 /// 对应道具ID
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
	 /// 摆位，默认0
	 /// </summary>
	public void setLayout(int layout){
		this.layout=layout;
	}

	/// <summary>
	 ///摆位，默认0
	 /// </summary>
	public int  getLayout(){  
		return layout; 
	}

	public override string ToString() {
		return "id:" + id + "," + "kid:" + kid + "," + "buildId:" + buildId + "," + "itemUuid:" + itemUuid + "," + "layout:" + layout;
	}

}
}