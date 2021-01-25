using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.chapter{

/// <summary>
 /// 玩家开图路径列表
 /// </summary>
public class WalkHistoryPo : BasePo{

	public const int cmd = 770911;
	public const string reflectClassName = "com.hbt.protocol.po.chapter.WalkHistoryPo";

	public WalkHistoryPo():base() {
		commandId = 770911;
		encryptTypeUp = 0;
	}

	public WalkHistoryPo(MemoryStream inputStream){
		commandId = 770911;
		encryptTypeUp = 0;
		this.setSetp(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getSetp());
	}

	/// <summary>
	 /// 从倒数第几个开始获取. 0则全部获取
	 /// </summary>
	private int setp; 

	/// <summary>
	 /// 从倒数第几个开始获取. 0则全部获取
	 /// </summary>
	public void setSetp(int setp){
		this.setp=setp;
	}

	/// <summary>
	 ///从倒数第几个开始获取. 0则全部获取
	 /// </summary>
	public int  getSetp(){  
		return setp; 
	}

	public override string ToString() {
		return "setp:" + setp;
	}

}
}