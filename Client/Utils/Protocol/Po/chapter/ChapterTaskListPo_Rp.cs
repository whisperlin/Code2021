using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.chapter{

/// <summary>
 /// 关卡任务列表
 /// </summary>
public class ChapterTaskListPo_Rp  : BasePo{

	public const int cmd = -770917;
	public const string reflectClassName = "com.hbt.protocol.po.chapter.ChapterTaskListPo_Rp";

	public ChapterTaskListPo_Rp():base() {
		commandId = -770917;
		encryptTypeDown = 0;
	}

	public ChapterTaskListPo_Rp(MemoryStream inputStream){
		commandId = -770917;
		encryptTypeDown = 0;

		short length0 = PackageUtil.DecodeShort(inputStream);//集合长度
		List<com.hbt.protocol.po.chapter.ChapterTaskPo> tasks = new List<com.hbt.protocol.po.chapter.ChapterTaskPo>();
		for(int i = 0; i < length0; i++){
			PackageUtil.skipInputStream(inputStream, 4);//读4位
			tasks.Add(new com.hbt.protocol.po.chapter.ChapterTaskPo(inputStream));
		}
		this.setTasks(tasks);
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);

		List<com.hbt.protocol.po.chapter.ChapterTaskPo> tasks = getTasks();
		short taskslength = (short)(tasks == null ? 0 : tasks.Count);
		PackageUtil.EncodeShort(outputStream, taskslength);
		for(int i = 0; i < taskslength; i++){
			tasks[i].encodeVo(outputStream);
		}
	}

	/// <summary>
	 ///任务状态列表
	 /// </summary>
	private List<com.hbt.protocol.po.chapter.ChapterTaskPo> tasks; 

	/// <summary>
	 ///任务状态列表
	 /// </summary>
	public void setTasks(List<com.hbt.protocol.po.chapter.ChapterTaskPo> tasks){
		this.tasks=tasks;
	}

	/// <summary>
	 ///任务状态列表
	 /// </summary>
	public List<com.hbt.protocol.po.chapter.ChapterTaskPo> getTasks(){  
		return tasks; 
	}

	public override string ToString() {
		return "tasks size:" + tasks.Count;
	}

}
}