using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.chapter{

/// <summary>
 /// 玩家开图路径列表
 /// </summary>
public class WalkHistoryPo_Rp  : BasePo{

	public const int cmd = -770911;
	public const string reflectClassName = "com.hbt.protocol.po.chapter.WalkHistoryPo_Rp";

	public WalkHistoryPo_Rp():base() {
		commandId = -770911;
		encryptTypeDown = 0;
	}

	public WalkHistoryPo_Rp(MemoryStream inputStream){
		commandId = -770911;
		encryptTypeDown = 0;

		short length0 = PackageUtil.DecodeShort(inputStream);//集合长度
		List<com.hbt.protocol.po.chapter.WalkPo> walkList = new List<com.hbt.protocol.po.chapter.WalkPo>();
		for(int i = 0; i < length0; i++){
			PackageUtil.skipInputStream(inputStream, 4);//读4位
			walkList.Add(new com.hbt.protocol.po.chapter.WalkPo(inputStream));
		}
		this.setWalkList(walkList);
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);

		List<com.hbt.protocol.po.chapter.WalkPo> walkList = getWalkList();
		short walkListlength = (short)(walkList == null ? 0 : walkList.Count);
		PackageUtil.EncodeShort(outputStream, walkListlength);
		for(int i = 0; i < walkListlength; i++){
			walkList[i].encodeVo(outputStream);
		}
	}

	/// <summary>
	 ///走的步数
	 /// </summary>
	private List<com.hbt.protocol.po.chapter.WalkPo> walkList; 

	/// <summary>
	 ///走的步数
	 /// </summary>
	public void setWalkList(List<com.hbt.protocol.po.chapter.WalkPo> walkList){
		this.walkList=walkList;
	}

	/// <summary>
	 ///走的步数
	 /// </summary>
	public List<com.hbt.protocol.po.chapter.WalkPo> getWalkList(){  
		return walkList; 
	}

	public override string ToString() {
		return "walkList size:" + walkList.Count;
	}

}
}