using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.task{

/// <summary>
 /// 获取玩家活跃任务
 /// </summary>
public class TaskListPo : BasePo{

	public const int cmd = 508754;
	public const string reflectClassName = "com.hbt.protocol.po.task.TaskListPo";

	public TaskListPo():base() {
		commandId = 508754;
		encryptTypeUp = 0;
	}

	public TaskListPo(MemoryStream inputStream){
		commandId = 508754;
		encryptTypeUp = 0;
		this.setNouse(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getNouse());
	}

	/// <summary>
	 /// 占位
	 /// </summary>
	private int nouse; 

	/// <summary>
	 /// 占位
	 /// </summary>
	public void setNouse(int nouse){
		this.nouse=nouse;
	}

	/// <summary>
	 ///占位
	 /// </summary>
	public int  getNouse(){  
		return nouse; 
	}

	public override string ToString() {
		return "nouse:" + nouse;
	}

}
}