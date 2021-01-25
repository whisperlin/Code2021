using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po{

/// <summary>
 /// 调试包
 /// </summary>
public class ConfigPo_Rp  : BasePo{

	public const int cmd = -3;
	public const string reflectClassName = "com.hbt.protocol.po.ConfigPo_Rp";

	public ConfigPo_Rp():base() {
		commandId = -3;
		encryptTypeDown = 0;
	}

	public ConfigPo_Rp(MemoryStream inputStream){
		commandId = -3;
		encryptTypeDown = 0;
		this.setDebug(PackageUtil.DecodeBoolean(inputStream));
		this.setUseHeartBeatSystem(PackageUtil.DecodeBoolean(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeBoolean(outputStream, getDebug());
		PackageUtil.EncodeBoolean(outputStream, getUseHeartBeatSystem());
	}

	/// <summary>
	 ///是否启用debug
	 /// </summary>
	private bool debug; 

	/// <summary>
	 ///是否启用心跳包
	 /// </summary>
	private bool useHeartBeatSystem; 

	/// <summary>
	 ///是否启用debug
	 /// </summary>
	public void setDebug(bool debug){
		this.debug=debug;
	}

	/// <summary>
	 ///是否启用debug
	 /// </summary>
	public bool  getDebug(){  
		return debug; 
	}

	/// <summary>
	 ///是否启用心跳包
	 /// </summary>
	public void setUseHeartBeatSystem(bool useHeartBeatSystem){
		this.useHeartBeatSystem=useHeartBeatSystem;
	}

	/// <summary>
	 ///是否启用心跳包
	 /// </summary>
	public bool  getUseHeartBeatSystem(){  
		return useHeartBeatSystem; 
	}

	public override string ToString() {
		return "debug:" + debug + "," + "useHeartBeatSystem:" + useHeartBeatSystem;
	}

}
}