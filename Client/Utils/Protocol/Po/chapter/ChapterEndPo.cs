using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.chapter{

/// <summary>
 /// 关卡结束包
 /// </summary>
public class ChapterEndPo : BasePo{

	public const int cmd = 770912;
	public const string reflectClassName = "com.hbt.protocol.po.chapter.ChapterEndPo";

	public ChapterEndPo():base() {
		commandId = 770912;
		encryptTypeUp = 0;
	}

	public ChapterEndPo(MemoryStream inputStream){
		commandId = 770912;
		encryptTypeUp = 0;
		this.setNouse(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getNouse());
	}

	/// <summary>
	 /// 占位参数
	 /// </summary>
	private int nouse; 

	/// <summary>
	 /// 占位参数
	 /// </summary>
	public void setNouse(int nouse){
		this.nouse=nouse;
	}

	/// <summary>
	 ///占位参数
	 /// </summary>
	public int  getNouse(){  
		return nouse; 
	}

	public override string ToString() {
		return "nouse:" + nouse;
	}

}
}