using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.task{

/// <summary>
 /// 任务
 /// </summary>
public class TaskPo : BasePo{

	public const int cmd = 508752;
	public const string reflectClassName = "com.hbt.protocol.po.task.TaskPo";

	public TaskPo():base() {
		commandId = 508752;
		encryptTypeUp = 0;
	}

	public TaskPo(MemoryStream inputStream){
		commandId = 508752;
		encryptTypeUp = 0;
		this.setTaskId(PackageUtil.DecodeInteger(inputStream));
		this.setStatus(PackageUtil.DecodeInteger(inputStream));
		this.setGainOpenReward(PackageUtil.DecodeBoolean(inputStream));
		this.setGainDoneReward(PackageUtil.DecodeBoolean(inputStream));
		this.setProgressCurrent(PackageUtil.DecodeInteger(inputStream));
		this.setProgressMax(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getTaskId());
		PackageUtil.EncodeInteger(outputStream, getStatus());
		PackageUtil.EncodeBoolean(outputStream, getGainOpenReward());
		PackageUtil.EncodeBoolean(outputStream, getGainDoneReward());
		PackageUtil.EncodeInteger(outputStream, getProgressCurrent());
		PackageUtil.EncodeInteger(outputStream, getProgressMax());
	}

	/// <summary>
	 /// 任务ID
	 /// </summary>
	private int taskId; 

	/// <summary>
	 /// 任务状态
	 /// </summary>
	private int status; 

	/// <summary>
	 /// 任务启动奖励领取情况
	 /// </summary>
	private bool gainOpenReward; 

	/// <summary>
	 /// 任务完成奖励领取情况
	 /// </summary>
	private bool gainDoneReward; 

	/// <summary>
	 /// 当前进度
	 /// </summary>
	private int progressCurrent; 

	/// <summary>
	 /// 进度目标值
	 /// </summary>
	private int progressMax; 

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
	 /// 任务状态
	 /// </summary>
	public void setStatus(int status){
		this.status=status;
	}

	/// <summary>
	 ///任务状态
	 /// </summary>
	public int  getStatus(){  
		return status; 
	}

	/// <summary>
	 /// 任务启动奖励领取情况
	 /// </summary>
	public void setGainOpenReward(bool gainOpenReward){
		this.gainOpenReward=gainOpenReward;
	}

	/// <summary>
	 ///任务启动奖励领取情况
	 /// </summary>
	public bool  getGainOpenReward(){  
		return gainOpenReward; 
	}

	/// <summary>
	 /// 任务完成奖励领取情况
	 /// </summary>
	public void setGainDoneReward(bool gainDoneReward){
		this.gainDoneReward=gainDoneReward;
	}

	/// <summary>
	 ///任务完成奖励领取情况
	 /// </summary>
	public bool  getGainDoneReward(){  
		return gainDoneReward; 
	}

	/// <summary>
	 /// 当前进度
	 /// </summary>
	public void setProgressCurrent(int progressCurrent){
		this.progressCurrent=progressCurrent;
	}

	/// <summary>
	 ///当前进度
	 /// </summary>
	public int  getProgressCurrent(){  
		return progressCurrent; 
	}

	/// <summary>
	 /// 进度目标值
	 /// </summary>
	public void setProgressMax(int progressMax){
		this.progressMax=progressMax;
	}

	/// <summary>
	 ///进度目标值
	 /// </summary>
	public int  getProgressMax(){  
		return progressMax; 
	}

	public override string ToString() {
		return "taskId:" + taskId + "," + "status:" + status + "," + "gainOpenReward:" + gainOpenReward + "," + "gainDoneReward:" + gainDoneReward + "," + "progressCurrent:" + progressCurrent + "," + "progressMax:" + progressMax;
	}

}
}