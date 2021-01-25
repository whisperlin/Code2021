using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.chapter{

/// <summary>
 /// 执行地图元素对话框（如宝箱，NPC等）
 /// </summary>
public class ExcuteWalkPo_Rp  : BasePo{

	public const int cmd = -770909;
	public const string reflectClassName = "com.hbt.protocol.po.chapter.ExcuteWalkPo_Rp";

	public ExcuteWalkPo_Rp():base() {
		commandId = -770909;
		encryptTypeDown = 0;
	}

	public ExcuteWalkPo_Rp(MemoryStream inputStream){
		commandId = -770909;
		encryptTypeDown = 0;
		this.setOrd(PackageUtil.DecodeInteger(inputStream));
		this.setMapid(PackageUtil.DecodeInteger(inputStream));
		this.setUseFood(PackageUtil.DecodeInteger(inputStream));
		this.setCurrFood(PackageUtil.DecodeInteger(inputStream));
		this.setResult(PackageUtil.DecodeInteger(inputStream));

		short length0 = PackageUtil.DecodeShort(inputStream);//集合长度
		List<com.hbt.protocol.po.chapter.ChapterEventPo> chapterEvent = new List<com.hbt.protocol.po.chapter.ChapterEventPo>();
		for(int i = 0; i < length0; i++){
			PackageUtil.skipInputStream(inputStream, 4);//读4位
			chapterEvent.Add(new com.hbt.protocol.po.chapter.ChapterEventPo(inputStream));
		}
		this.setChapterEvent(chapterEvent);
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getOrd());
		PackageUtil.EncodeInteger(outputStream, getMapid());
		PackageUtil.EncodeInteger(outputStream, getUseFood());
		PackageUtil.EncodeInteger(outputStream, getCurrFood());
		PackageUtil.EncodeInteger(outputStream, getResult());

		List<com.hbt.protocol.po.chapter.ChapterEventPo> chapterEvent = getChapterEvent();
		short chapterEventlength = (short)(chapterEvent == null ? 0 : chapterEvent.Count);
		PackageUtil.EncodeShort(outputStream, chapterEventlength);
		for(int i = 0; i < chapterEventlength; i++){
			chapterEvent[i].encodeVo(outputStream);
		}
	}

	/// <summary>
	 ///当前步数
	 /// </summary>
	private int ord; 

	/// <summary>
	 ///地图唯一ID
	 /// </summary>
	private int mapid; 

	/// <summary>
	 ///当前食物量
	 /// </summary>
	private int useFood; 

	/// <summary>
	 ///当前食物量
	 /// </summary>
	private int currFood; 

	/// <summary>
	 ///执行结果：ChapterConst.WALK_RESULT_*
	 /// </summary>
	private int result; 

	/// <summary>
	 ///关卡事件触发列表
	 /// </summary>
	private List<com.hbt.protocol.po.chapter.ChapterEventPo> chapterEvent; 

	/// <summary>
	 ///当前步数
	 /// </summary>
	public void setOrd(int ord){
		this.ord=ord;
	}

	/// <summary>
	 ///当前步数
	 /// </summary>
	public int  getOrd(){  
		return ord; 
	}

	/// <summary>
	 ///地图唯一ID
	 /// </summary>
	public void setMapid(int mapid){
		this.mapid=mapid;
	}

	/// <summary>
	 ///地图唯一ID
	 /// </summary>
	public int  getMapid(){  
		return mapid; 
	}

	/// <summary>
	 ///当前食物量
	 /// </summary>
	public void setUseFood(int useFood){
		this.useFood=useFood;
	}

	/// <summary>
	 ///当前食物量
	 /// </summary>
	public int  getUseFood(){  
		return useFood; 
	}

	/// <summary>
	 ///当前食物量
	 /// </summary>
	public void setCurrFood(int currFood){
		this.currFood=currFood;
	}

	/// <summary>
	 ///当前食物量
	 /// </summary>
	public int  getCurrFood(){  
		return currFood; 
	}

	/// <summary>
	 ///执行结果：ChapterConst.WALK_RESULT_*
	 /// </summary>
	public void setResult(int result){
		this.result=result;
	}

	/// <summary>
	 ///执行结果：ChapterConst.WALK_RESULT_*
	 /// </summary>
	public int  getResult(){  
		return result; 
	}

	/// <summary>
	 ///关卡事件触发列表
	 /// </summary>
	public void setChapterEvent(List<com.hbt.protocol.po.chapter.ChapterEventPo> chapterEvent){
		this.chapterEvent=chapterEvent;
	}

	/// <summary>
	 ///关卡事件触发列表
	 /// </summary>
	public List<com.hbt.protocol.po.chapter.ChapterEventPo> getChapterEvent(){  
		return chapterEvent; 
	}

	public override string ToString() {
		return "ord:" + ord + "," + "mapid:" + mapid + "," + "useFood:" + useFood + "," + "currFood:" + currFood + "," + "result:" + result + "," + "chapterEvent size:" + chapterEvent.Count;
	}

}
}