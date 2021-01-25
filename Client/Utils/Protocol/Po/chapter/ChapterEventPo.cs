using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.chapter{

/// <summary>
 /// 关卡事件
 /// </summary>
public class ChapterEventPo : BasePo{

	public const int cmd = 770906;
	public const string reflectClassName = "com.hbt.protocol.po.chapter.ChapterEventPo";

	public ChapterEventPo():base() {
		commandId = 770906;
		encryptTypeUp = 0;
	}

	public ChapterEventPo(MemoryStream inputStream){
		commandId = 770906;
		encryptTypeUp = 0;
		this.setId(PackageUtil.DecodeInteger(inputStream));
		this.setInvokeType(PackageUtil.DecodeInteger(inputStream));
		this.setDialogueId(PackageUtil.DecodeInteger(inputStream));

		short length0 = PackageUtil.DecodeShort(inputStream);//集合长度
		List<com.hbt.protocol.po.chapter.ChapterEventExecutedPo> executed = new List<com.hbt.protocol.po.chapter.ChapterEventExecutedPo>();
		for(int i = 0; i < length0; i++){
			PackageUtil.skipInputStream(inputStream, 4);//读4位
			executed.Add(new com.hbt.protocol.po.chapter.ChapterEventExecutedPo(inputStream));
		}
		this.setExecuted(executed);
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getId());
		PackageUtil.EncodeInteger(outputStream, getInvokeType());
		PackageUtil.EncodeInteger(outputStream, getDialogueId());

		List<com.hbt.protocol.po.chapter.ChapterEventExecutedPo> executed = getExecuted();
		short executedlength = (short)(executed == null ? 0 : executed.Count);
		PackageUtil.EncodeShort(outputStream, executedlength);
		for(int i = 0; i < executedlength; i++){
			executed[i].encodeVo(outputStream);
		}
	}

	/// <summary>
	 /// 事件ID
	 /// </summary>
	private int id; 

	/// <summary>
	 /// 事件类型
	 /// </summary>
	private int invokeType; 

	/// <summary>
	 /// 对白ID,如果不是从对白调用的则为0
	 /// </summary>
	private int dialogueId; 

	/// <summary>
	 /// 执行结果列表
	 /// </summary>
	private List<com.hbt.protocol.po.chapter.ChapterEventExecutedPo> executed; 

	/// <summary>
	 /// 事件ID
	 /// </summary>
	public void setId(int id){
		this.id=id;
	}

	/// <summary>
	 ///事件ID
	 /// </summary>
	public int  getId(){  
		return id; 
	}

	/// <summary>
	 /// 事件类型
	 /// </summary>
	public void setInvokeType(int invokeType){
		this.invokeType=invokeType;
	}

	/// <summary>
	 ///事件类型
	 /// </summary>
	public int  getInvokeType(){  
		return invokeType; 
	}

	/// <summary>
	 /// 对白ID,如果不是从对白调用的则为0
	 /// </summary>
	public void setDialogueId(int dialogueId){
		this.dialogueId=dialogueId;
	}

	/// <summary>
	 ///对白ID,如果不是从对白调用的则为0
	 /// </summary>
	public int  getDialogueId(){  
		return dialogueId; 
	}

	/// <summary>
	 /// 执行结果列表
	 /// </summary>
	public void setExecuted(List<com.hbt.protocol.po.chapter.ChapterEventExecutedPo> executed){
		this.executed=executed;
	}

	/// <summary>
	 ///执行结果列表
	 /// </summary>
	public List<com.hbt.protocol.po.chapter.ChapterEventExecutedPo> getExecuted(){  
		return executed; 
	}

	public override string ToString() {
		return "id:" + id + "," + "invokeType:" + invokeType + "," + "dialogueId:" + dialogueId + "," + "executed size:" + executed.Count;
	}

}
}