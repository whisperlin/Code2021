using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.chapter{

/// <summary>
 /// 获取地图状态数据
 /// </summary>
public class GetMapStatusPo : BasePo{

	public const int cmd = 770903;
	public const string reflectClassName = "com.hbt.protocol.po.chapter.GetMapStatusPo";

	public GetMapStatusPo():base() {
		commandId = 770903;
		encryptTypeUp = 0;
	}

	public GetMapStatusPo(MemoryStream inputStream){
		commandId = 770903;
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