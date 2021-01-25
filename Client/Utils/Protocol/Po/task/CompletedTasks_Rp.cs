using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.task{

/// <summary>
 /// 获取已经完成的任务ID
 /// </summary>
public class CompletedTasks_Rp  : BasePo{

	public const int cmd = -508753;
	public const string reflectClassName = "com.hbt.protocol.po.task.CompletedTasks_Rp";

	public CompletedTasks_Rp():base() {
		commandId = -508753;
		encryptTypeDown = 0;
	}

	public CompletedTasks_Rp(MemoryStream inputStream){
		commandId = -508753;
		encryptTypeDown = 0;

		short length0 = PackageUtil.DecodeShort(inputStream);//集合长度
		List<int> tasks = new List<int>();
		for(int i = 0; i < length0; i++){
			tasks.Add(PackageUtil.DecodeInteger(inputStream));
		}
		this.setTasks(tasks);
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);

		List<int> tasks = getTasks();
		short taskslength = (short)(tasks == null ? 0 : tasks.Count);
		PackageUtil.EncodeShort(outputStream, taskslength);
		for(int i = 0; i < taskslength; i++){
			PackageUtil.EncodeInteger(outputStream, tasks[i]);
		}
	}

	/// <summary>
	 ///配方列表
	 /// </summary>
	private List<int> tasks; 

	/// <summary>
	 ///配方列表
	 /// </summary>
	public void setTasks(List<int> tasks){
		this.tasks=tasks;
	}

	/// <summary>
	 ///配方列表
	 /// </summary>
	public List<int> getTasks(){  
		return tasks; 
	}

	public override string ToString() {
		return "tasks size:" + tasks.Count;
	}

}
}