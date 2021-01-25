using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po{

/// <summary>
 /// 心跳包
 /// </summary>
public class HeartbeatPo_Rp  : BasePo{

	public const int cmd = -2;
	public const string reflectClassName = "com.hbt.protocol.po.HeartbeatPo_Rp";

	public HeartbeatPo_Rp():base() {
		commandId = -2;
		encryptTypeDown = 0;
	}

	public HeartbeatPo_Rp(MemoryStream inputStream){
		commandId = -2;
		encryptTypeDown = 0;
		this.setUnreadMailCount(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getUnreadMailCount());
	}

	/// <summary>
	 ///未读邮件数
	 /// </summary>
	private int unreadMailCount; 

	/// <summary>
	 ///未读邮件数
	 /// </summary>
	public void setUnreadMailCount(int unreadMailCount){
		this.unreadMailCount=unreadMailCount;
	}

	/// <summary>
	 ///未读邮件数
	 /// </summary>
	public int  getUnreadMailCount(){  
		return unreadMailCount; 
	}

	public override string ToString() {
		return "unreadMailCount:" + unreadMailCount;
	}

}
}