using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.task{

/// <summary>
 /// 升级居民楼
 /// </summary>
public class GainTaskRewardPo_Rp  : BasePo{

	public const int cmd = -508755;
	public const string reflectClassName = "com.hbt.protocol.po.task.GainTaskRewardPo_Rp";

	public GainTaskRewardPo_Rp():base() {
		commandId = -508755;
		encryptTypeDown = 0;
	}

	public GainTaskRewardPo_Rp(MemoryStream inputStream){
		commandId = -508755;
		encryptTypeDown = 0;
		this.setTaskId(PackageUtil.DecodeInteger(inputStream));
		this.setStatus(PackageUtil.DecodeInteger(inputStream));
		this.setResult(PackageUtil.DecodeInteger(inputStream));
		this.setRewardId(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getTaskId());
		PackageUtil.EncodeInteger(outputStream, getStatus());
		PackageUtil.EncodeInteger(outputStream, getResult());
		PackageUtil.EncodeInteger(outputStream, getRewardId());
	}

	/// <summary>
	 ///需要获取的奖励
	 /// </summary>
	private int taskId; 

	/// <summary>
	 ///执行后状态
	 /// </summary>
	private int status; 

	/// <summary>
	 ///结果: DefaultConst.COMM_RESULT_* 
	 /// </summary>
	private int result; 

	/// <summary>
	 ///奖励ID
	 /// </summary>
	private int rewardId; 

	/// <summary>
	 ///需要获取的奖励
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

	/// <summary>
	 ///执行后状态
	 /// </summary>
	public void setStatus(int status){
		this.status=status;
	}

	/// <summary>
	 ///执行后状态
	 /// </summary>
	public int  getStatus(){  
		return status; 
	}

	/// <summary>
	 ///结果: DefaultConst.COMM_RESULT_* 
	 /// </summary>
	public void setResult(int result){
		this.result=result;
	}

	/// <summary>
	 ///结果: DefaultConst.COMM_RESULT_* 
	 /// </summary>
	public int  getResult(){  
		return result; 
	}

	/// <summary>
	 ///奖励ID
	 /// </summary>
	public void setRewardId(int rewardId){
		this.rewardId=rewardId;
	}

	/// <summary>
	 ///奖励ID
	 /// </summary>
	public int  getRewardId(){  
		return rewardId; 
	}

	public override string ToString() {
		return "taskId:" + taskId + "," + "status:" + status + "," + "result:" + result + "," + "rewardId:" + rewardId;
	}

}
}