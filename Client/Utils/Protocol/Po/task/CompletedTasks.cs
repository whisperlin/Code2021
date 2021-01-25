using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.task{

/// <summary>
 /// 获取已经完成的任务ID
 /// </summary>
public class CompletedTasks : BasePo{

	public const int cmd = 508753;
	public const string reflectClassName = "com.hbt.protocol.po.task.CompletedTasks";

	public CompletedTasks():base() {
		commandId = 508753;
		encryptTypeUp = 0;
	}

	public CompletedTasks(MemoryStream inputStream){
		commandId = 508753;
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