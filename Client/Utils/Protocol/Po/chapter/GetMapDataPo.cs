using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.chapter{

/// <summary>
 /// 获取地图地形数据
 /// </summary>
public class GetMapDataPo : BasePo{

	public const int cmd = 770902;
	public const string reflectClassName = "com.hbt.protocol.po.chapter.GetMapDataPo";

	public GetMapDataPo():base() {
		commandId = 770902;
		encryptTypeUp = 0;
	}

	public GetMapDataPo(MemoryStream inputStream){
		commandId = 770902;
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