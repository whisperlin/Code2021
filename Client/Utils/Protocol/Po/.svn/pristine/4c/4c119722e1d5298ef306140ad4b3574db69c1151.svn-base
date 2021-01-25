using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.chapter{

/// <summary>
 /// 关卡进度情况
 /// </summary>
public class ChapterInfoPo : BasePo{

	public const int cmd = 770900;
	public const string reflectClassName = "com.hbt.protocol.po.chapter.ChapterInfoPo";

	public ChapterInfoPo():base() {
		commandId = 770900;
		encryptTypeUp = 0;
	}

	public ChapterInfoPo(MemoryStream inputStream){
		commandId = 770900;
		encryptTypeUp = 0;
		this.setNouse(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getNouse());
	}

	/// <summary>
	 /// 占位
	 /// </summary>
	private int nouse; 

	/// <summary>
	 /// 占位
	 /// </summary>
	public void setNouse(int nouse){
		this.nouse=nouse;
	}

	/// <summary>
	 ///占位
	 /// </summary>
	public int  getNouse(){  
		return nouse; 
	}

	public override string ToString() {
		return "nouse:" + nouse;
	}

}
}