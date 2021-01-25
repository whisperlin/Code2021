using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.chapter{

/// <summary>
 /// 道具列表
 /// </summary>
public class ChapterItemListPo : BasePo{

	public const int cmd = 770905;
	public const string reflectClassName = "com.hbt.protocol.po.chapter.ChapterItemListPo";

	public ChapterItemListPo():base() {
		commandId = 770905;
		encryptTypeUp = 0;
	}

	public ChapterItemListPo(MemoryStream inputStream){
		commandId = 770905;
		encryptTypeUp = 0;
		this.setCtype(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getCtype());
	}

	/// <summary>
	 /// 分类ID(传0则显示所有，关卡中道具不用分，暂时无用)
	 /// </summary>
	private int ctype; 

	/// <summary>
	 /// 分类ID(传0则显示所有，关卡中道具不用分，暂时无用)
	 /// </summary>
	public void setCtype(int ctype){
		this.ctype=ctype;
	}

	/// <summary>
	 ///分类ID(传0则显示所有，关卡中道具不用分，暂时无用)
	 /// </summary>
	public int  getCtype(){  
		return ctype; 
	}

	public override string ToString() {
		return "ctype:" + ctype;
	}

}
}