using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.task{

/// <summary>
 /// 升级居民楼
 /// </summary>
public class GainTaskRewardPo : BasePo{

	public const int cmd = 508755;
	public const string reflectClassName = "com.hbt.protocol.po.task.GainTaskRewardPo";

	public GainTaskRewardPo():base() {
		commandId = 508755;
		encryptTypeUp = 0;
	}

	public GainTaskRewardPo(MemoryStream inputStream){
		commandId = 508755;
		encryptTypeUp = 0;
		this.setTaskId(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getTaskId());
	}

	/// <summary>
	 /// 需要获取的奖励
	 /// </summary>
	private int taskId; 

	/// <summary>
	 /// 需要获取的奖励
	 /// </summary>
	public void setTaskId(int taskId){
		this.taskId=taskId;
	}

	/// <summary>
	 ///需要获取的奖励
	 /// </summary>
	public int  getTaskId(){  
		return taskId; 
	}

	public override string ToString() {
		return "taskId:" + taskId;
	}

}
}