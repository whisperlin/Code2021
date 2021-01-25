using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.chapter{

/// <summary>
 /// 队伍的各种状态列表
 /// </summary>
public class ChapterPetListPo : BasePo{

	public const int cmd = 770915;
	public const string reflectClassName = "com.hbt.protocol.po.chapter.ChapterPetListPo";

	public ChapterPetListPo():base() {
		commandId = 770915;
		encryptTypeUp = 0;
	}

	public ChapterPetListPo(MemoryStream inputStream){
		commandId = 770915;
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