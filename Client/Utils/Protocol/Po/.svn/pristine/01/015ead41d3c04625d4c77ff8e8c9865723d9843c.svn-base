using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.task{

/// <summary>
 /// 获取玩家活跃任务
 /// </summary>
public class TaskListPo_Rp  : BasePo{

	public const int cmd = -508754;
	public const string reflectClassName = "com.hbt.protocol.po.task.TaskListPo_Rp";

	public TaskListPo_Rp():base() {
		commandId = -508754;
		encryptTypeDown = 0;
	}

	public TaskListPo_Rp(MemoryStream inputStream){
		commandId = -508754;
		encryptTypeDown = 0;

		short length0 = PackageUtil.DecodeShort(inputStream);//集合长度
		List<com.hbt.protocol.po.task.TaskPo> formulas = new List<com.hbt.protocol.po.task.TaskPo>();
		for(int i = 0; i < length0; i++){
			PackageUtil.skipInputStream(inputStream, 4);//读4位
			formulas.Add(new com.hbt.protocol.po.task.TaskPo(inputStream));
		}
		this.setFormulas(formulas);
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);

		List<com.hbt.protocol.po.task.TaskPo> formulas = getFormulas();
		short formulaslength = (short)(formulas == null ? 0 : formulas.Count);
		PackageUtil.EncodeShort(outputStream, formulaslength);
		for(int i = 0; i < formulaslength; i++){
			formulas[i].encodeVo(outputStream);
		}
	}

	/// <summary>
	 ///活跃任务
	 /// </summary>
	private List<com.hbt.protocol.po.task.TaskPo> formulas; 

	/// <summary>
	 ///活跃任务
	 /// </summary>
	public void setFormulas(List<com.hbt.protocol.po.task.TaskPo> formulas){
		this.formulas=formulas;
	}

	/// <summary>
	 ///活跃任务
	 /// </summary>
	public List<com.hbt.protocol.po.task.TaskPo> getFormulas(){  
		return formulas; 
	}

	public override string ToString() {
		return "formulas size:" + formulas.Count;
	}

}
}