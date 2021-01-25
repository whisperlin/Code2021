using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.chapter{

/// <summary>
 /// 执行地图元素对话框（如宝箱，NPC等）
 /// </summary>
public class ExcuteMapDialoguePo_Rp  : BasePo{

	public const int cmd = -770908;
	public const string reflectClassName = "com.hbt.protocol.po.chapter.ExcuteMapDialoguePo_Rp";

	public ExcuteMapDialoguePo_Rp():base() {
		commandId = -770908;
		encryptTypeDown = 0;
	}

	public ExcuteMapDialoguePo_Rp(MemoryStream inputStream){
		commandId = -770908;
		encryptTypeDown = 0;
		this.setResult(PackageUtil.DecodeInteger(inputStream));
		this.setMapSettingId(PackageUtil.DecodeInteger(inputStream));
		this.setMapDialogueId(PackageUtil.DecodeInteger(inputStream));

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
		PackageUtil.EncodeInteger(outputStream, getResult());
		PackageUtil.EncodeInteger(outputStream, getMapSettingId());
		PackageUtil.EncodeInteger(outputStream, getMapDialogueId());

		List<com.hbt.protocol.po.chapter.ChapterEventPo> chapterEvent = getChapterEvent();
		short chapterEventlength = (short)(chapterEvent == null ? 0 : chapterEvent.Count);
		PackageUtil.EncodeShort(outputStream, chapterEventlength);
		for(int i = 0; i < chapterEventlength; i++){
			chapterEvent[i].encodeVo(outputStream);
		}
	}

	/// <summary>
	 ///执行结果：ChapterConst.EXECUTE_RESULT_*
	 /// </summary>
	private int result; 

	/// <summary>
	 ///关卡对应事件ID
	 /// </summary>
	private int mapSettingId; 

	/// <summary>
	 ///事件对应的对白ID
	 /// </summary>
	private int mapDialogueId; 

	/// <summary>
	 ///关卡事件触发列表
	 /// </summary>
	private List<com.hbt.protocol.po.chapter.ChapterEventPo> chapterEvent; 

	/// <summary>
	 ///执行结果：ChapterConst.EXECUTE_RESULT_*
	 /// </summary>
	public void setResult(int result){
		this.result=result;
	}

	/// <summary>
	 ///执行结果：ChapterConst.EXECUTE_RESULT_*
	 /// </summary>
	public int  getResult(){  
		return result; 
	}

	/// <summary>
	 ///关卡对应事件ID
	 /// </summary>
	public void setMapSettingId(int mapSettingId){
		this.mapSettingId=mapSettingId;
	}

	/// <summary>
	 ///关卡对应事件ID
	 /// </summary>
	public int  getMapSettingId(){  
		return mapSettingId; 
	}

	/// <summary>
	 ///事件对应的对白ID
	 /// </summary>
	public void setMapDialogueId(int mapDialogueId){
		this.mapDialogueId=mapDialogueId;
	}

	/// <summary>
	 ///事件对应的对白ID
	 /// </summary>
	public int  getMapDialogueId(){  
		return mapDialogueId; 
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
		return "result:" + result + "," + "mapSettingId:" + mapSettingId + "," + "mapDialogueId:" + mapDialogueId + "," + "chapterEvent size:" + chapterEvent.Count;
	}

}
}