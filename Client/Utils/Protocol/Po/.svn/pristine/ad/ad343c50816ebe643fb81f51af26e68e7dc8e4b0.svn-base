using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.chapter{

/// <summary>
 /// 请求进入关卡
 /// </summary>
public class EnterChapterPo : BasePo{

	public const int cmd = 770901;
	public const string reflectClassName = "com.hbt.protocol.po.chapter.EnterChapterPo";

	public EnterChapterPo():base() {
		commandId = 770901;
		encryptTypeUp = 0;
	}

	public EnterChapterPo(MemoryStream inputStream){
		commandId = 770901;
		encryptTypeUp = 0;
		this.setChapterId(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getChapterId());
	}

	/// <summary>
	 /// 关卡ID
	 /// </summary>
	private int chapterId; 

	/// <summary>
	 /// 关卡ID
	 /// </summary>
	public void setChapterId(int chapterId){
		this.chapterId=chapterId;
	}

	/// <summary>
	 ///关卡ID
	 /// </summary>
	public int  getChapterId(){  
		return chapterId; 
	}

	public override string ToString() {
		return "chapterId:" + chapterId;
	}

}
}