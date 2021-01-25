using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po{

/// <summary>
 /// 版本发送包
 /// </summary>
public class VersionPo_Rp  : BasePo{

	public const int cmd = -50000;
	public const string reflectClassName = "com.hbt.protocol.po.VersionPo_Rp";

	public VersionPo_Rp():base() {
		commandId = -50000;
		encryptTypeDown = 0;
	}

	public VersionPo_Rp(MemoryStream inputStream){
		commandId = -50000;
		encryptTypeDown = 0;
		this.setId(PackageUtil.DecodeInteger(inputStream));
		this.setPublishDate(PackageUtil.DecodeString(inputStream));
		this.setSVersion(PackageUtil.DecodeString(inputStream));
		this.setCVersion(PackageUtil.DecodeString(inputStream));
		this.setDescription(PackageUtil.DecodeString(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getId());
		PackageUtil.EncodeString(outputStream, getPublishDate());
		PackageUtil.EncodeString(outputStream, getSVersion());
		PackageUtil.EncodeString(outputStream, getCVersion());
		PackageUtil.EncodeString(outputStream, getDescription());
	}

	/// <summary>
	 ///版本id
	 /// </summary>
	private int id; 

	/// <summary>
	 ///发布日期
	 /// </summary>
	private string publishDate; 

	/// <summary>
	 ///服务器版本
	 /// </summary>
	private string sVersion; 

	/// <summary>
	 ///客户端版本
	 /// </summary>
	private string cVersion; 

	/// <summary>
	 ///描述
	 /// </summary>
	private string description; 

	/// <summary>
	 ///版本id
	 /// </summary>
	public void setId(int id){
		this.id=id;
	}

	/// <summary>
	 ///版本id
	 /// </summary>
	public int  getId(){  
		return id; 
	}

	/// <summary>
	 ///发布日期
	 /// </summary>
	public void setPublishDate(string publishDate){
		this.publishDate=publishDate;
	}

	/// <summary>
	 ///发布日期
	 /// </summary>
	public string  getPublishDate(){  
		return publishDate; 
	}

	/// <summary>
	 ///服务器版本
	 /// </summary>
	public void setSVersion(string sVersion){
		this.sVersion=sVersion;
	}

	/// <summary>
	 ///服务器版本
	 /// </summary>
	public string  getSVersion(){  
		return sVersion; 
	}

	/// <summary>
	 ///客户端版本
	 /// </summary>
	public void setCVersion(string cVersion){
		this.cVersion=cVersion;
	}

	/// <summary>
	 ///客户端版本
	 /// </summary>
	public string  getCVersion(){  
		return cVersion; 
	}

	/// <summary>
	 ///描述
	 /// </summary>
	public void setDescription(string description){
		this.description=description;
	}

	/// <summary>
	 ///描述
	 /// </summary>
	public string  getDescription(){  
		return description; 
	}

	public override string ToString() {
		return "id:" + id + "," + "publishDate:" + publishDate + "," + "sVersion:" + sVersion + "," + "cVersion:" + cVersion + "," + "description:" + description;
	}

}
}