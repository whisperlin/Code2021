using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.chapter{

/// <summary>
 /// 关卡任务列表
 /// </summary>
public class ChapterTaskListPo : BasePo{

	public const int cmd = 770917;
	public const string reflectClassName = "com.hbt.protocol.po.chapter.ChapterTaskListPo";

	public ChapterTaskListPo():base() {
		commandId = 770917;
		encryptTypeUp = 0;
	}

	public ChapterTaskListPo(MemoryStream inputStream){
		commandId = 770917;
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