using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.chapter{

/// <summary>
 /// 请求进入关卡
 /// </summary>
public class EnterChapterPo_Rp  : BasePo{

	public const int cmd = -770901;
	public const string reflectClassName = "com.hbt.protocol.po.chapter.EnterChapterPo_Rp";

	public EnterChapterPo_Rp():base() {
		commandId = -770901;
		encryptTypeDown = 0;
	}

	public EnterChapterPo_Rp(MemoryStream inputStream){
		commandId = -770901;
		encryptTypeDown = 0;
		this.setChapterId(PackageUtil.DecodeInteger(inputStream));
		this.setResult(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getChapterId());
		PackageUtil.EncodeInteger(outputStream, getResult());
	}

	/// <summary>
	 ///关卡ID
	 /// </summary>
	private int chapterId; 

	/// <summary>
	 ///结果: ChapterConst.ENTER_RESULT_*
	 /// </summary>
	private int result; 

	/// <summary>
	 ///关卡ID
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

	/// <summary>
	 ///结果: ChapterConst.ENTER_RESULT_*
	 /// </summary>
	public void setResult(int result){
		this.result=result;
	}

	/// <summary>
	 ///结果: ChapterConst.ENTER_RESULT_*
	 /// </summary>
	public int  getResult(){  
		return result; 
	}

	public override string ToString() {
		return "chapterId:" + chapterId + "," + "result:" + result;
	}

}
}