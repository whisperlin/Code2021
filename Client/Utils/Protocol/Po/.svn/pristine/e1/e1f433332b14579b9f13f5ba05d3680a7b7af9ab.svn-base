using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.chapter{

/// <summary>
 /// 冒险关卡任务
 /// </summary>
public class ChapterTaskPo : BasePo{

	public const int cmd = 770916;
	public const string reflectClassName = "com.hbt.protocol.po.chapter.ChapterTaskPo";

	public ChapterTaskPo():base() {
		commandId = 770916;
		encryptTypeUp = 0;
	}

	public ChapterTaskPo(MemoryStream inputStream){
		commandId = 770916;
		encryptTypeUp = 0;
		this.setTaskId(PackageUtil.DecodeInteger(inputStream));
		this.setStatus(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getTaskId());
		PackageUtil.EncodeInteger(outputStream, getStatus());
	}

	/// <summary>
	 /// 任务ID
	 /// </summary>
	private int taskId; 

	/// <summary>
	 /// 任务状态: ChapterConst.TASK_STATUS_*
	 /// </summary>
	private int status; 

	/// <summary>
	 /// 任务ID
	 /// </summary>
	public void setTaskId(int taskId){
		this.taskId=taskId;
	}

	/// <summary>
	 ///任务ID
	 /// </summary>
	public int  getTaskId(){  
		return taskId; 
	}

	/// <summary>
	 /// 任务状态: ChapterConst.TASK_STATUS_*
	 /// </summary>
	public void setStatus(int status){
		this.status=status;
	}

	/// <summary>
	 ///任务状态: ChapterConst.TASK_STATUS_*
	 /// </summary>
	public int  getStatus(){  
		return status; 
	}

	public override string ToString() {
		return "taskId:" + taskId + "," + "status:" + status;
	}

}
}