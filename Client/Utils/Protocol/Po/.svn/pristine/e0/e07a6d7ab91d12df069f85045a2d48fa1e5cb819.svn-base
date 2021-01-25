using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.chapter{

/// <summary>
 /// 获取地图状态数据
 /// </summary>
public class GetMapStatusPo_Rp  : BasePo{

	public const int cmd = -770903;
	public const string reflectClassName = "com.hbt.protocol.po.chapter.GetMapStatusPo_Rp";

	public GetMapStatusPo_Rp():base() {
		commandId = -770903;
		encryptTypeDown = 0;
	}

	public GetMapStatusPo_Rp(MemoryStream inputStream){
		commandId = -770903;
		encryptTypeDown = 0;
		this.setChapterId(PackageUtil.DecodeInteger(inputStream));
		this.setRemainFood(PackageUtil.DecodeInteger(inputStream));

		short length0 = PackageUtil.DecodeShort(inputStream);//集合长度
		List<com.hbt.protocol.po.chapter.MapStatusPo> items = new List<com.hbt.protocol.po.chapter.MapStatusPo>();
		for(int i = 0; i < length0; i++){
			PackageUtil.skipInputStream(inputStream, 4);//读4位
			items.Add(new com.hbt.protocol.po.chapter.MapStatusPo(inputStream));
		}
		this.setItems(items);

		short length1 = PackageUtil.DecodeShort(inputStream);//集合长度
		List<com.hbt.protocol.po.chapter.ChapterEventPo> chapterEvent = new List<com.hbt.protocol.po.chapter.ChapterEventPo>();
		for(int i = 0; i < length1; i++){
			PackageUtil.skipInputStream(inputStream, 4);//读4位
			chapterEvent.Add(new com.hbt.protocol.po.chapter.ChapterEventPo(inputStream));
		}
		this.setChapterEvent(chapterEvent);
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getChapterId());
		PackageUtil.EncodeInteger(outputStream, getRemainFood());

		List<com.hbt.protocol.po.chapter.MapStatusPo> items = getItems();
		short itemslength = (short)(items == null ? 0 : items.Count);
		PackageUtil.EncodeShort(outputStream, itemslength);
		for(int i = 0; i < itemslength; i++){
			items[i].encodeVo(outputStream);
		}

		List<com.hbt.protocol.po.chapter.ChapterEventPo> chapterEvent = getChapterEvent();
		short chapterEventlength = (short)(chapterEvent == null ? 0 : chapterEvent.Count);
		PackageUtil.EncodeShort(outputStream, chapterEventlength);
		for(int i = 0; i < chapterEventlength; i++){
			chapterEvent[i].encodeVo(outputStream);
		}
	}

	/// <summary>
	 ///关卡ID
	 /// </summary>
	private int chapterId; 

	/// <summary>
	 ///当前剩余食物
	 /// </summary>
	private int remainFood; 

	/// <summary>
	 ///地图状态数据
	 /// </summary>
	private List<com.hbt.protocol.po.chapter.MapStatusPo> items; 

	/// <summary>
	 ///关卡事件触发数量
	 /// </summary>
	private List<com.hbt.protocol.po.chapter.ChapterEventPo> chapterEvent; 

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
	 ///当前剩余食物
	 /// </summary>
	public void setRemainFood(int remainFood){
		this.remainFood=remainFood;
	}

	/// <summary>
	 ///当前剩余食物
	 /// </summary>
	public int  getRemainFood(){  
		return remainFood; 
	}

	/// <summary>
	 ///地图状态数据
	 /// </summary>
	public void setItems(List<com.hbt.protocol.po.chapter.MapStatusPo> items){
		this.items=items;
	}

	/// <summary>
	 ///地图状态数据
	 /// </summary>
	public List<com.hbt.protocol.po.chapter.MapStatusPo> getItems(){  
		return items; 
	}

	/// <summary>
	 ///关卡事件触发数量
	 /// </summary>
	public void setChapterEvent(List<com.hbt.protocol.po.chapter.ChapterEventPo> chapterEvent){
		this.chapterEvent=chapterEvent;
	}

	/// <summary>
	 ///关卡事件触发数量
	 /// </summary>
	public List<com.hbt.protocol.po.chapter.ChapterEventPo> getChapterEvent(){  
		return chapterEvent; 
	}

	public override string ToString() {
		return "chapterId:" + chapterId + "," + "remainFood:" + remainFood + "," + "items size:" + items.Count + "," + "chapterEvent size:" + chapterEvent.Count;
	}

}
}