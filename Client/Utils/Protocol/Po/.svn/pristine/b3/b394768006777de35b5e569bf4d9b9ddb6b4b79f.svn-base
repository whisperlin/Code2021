using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.chapter{

/// <summary>
 /// 关卡进度数据
 /// </summary>
public class ChapterProgressPo : BasePo{

	public const int cmd = 770896;
	public const string reflectClassName = "com.hbt.protocol.po.chapter.ChapterProgressPo";

	public ChapterProgressPo():base() {
		commandId = 770896;
		encryptTypeUp = 0;
	}

	public ChapterProgressPo(MemoryStream inputStream){
		commandId = 770896;
		encryptTypeUp = 0;
		this.setChapterId(PackageUtil.DecodeInteger(inputStream));
		this.setStatus(PackageUtil.DecodeInteger(inputStream));
		this.setPassCount(PackageUtil.DecodeInteger(inputStream));
		this.setSwarmCount(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getChapterId());
		PackageUtil.EncodeInteger(outputStream, getStatus());
		PackageUtil.EncodeInteger(outputStream, getPassCount());
		PackageUtil.EncodeInteger(outputStream, getSwarmCount());
	}

	/// <summary>
	 /// 关卡id
	 /// </summary>
	private int chapterId; 

	/// <summary>
	 /// 开启状态:ChapterConst.PROGRESS_STATUS_*
	 /// </summary>
	private int status; 

	/// <summary>
	 /// 通关次数
	 /// </summary>
	private int passCount; 

	/// <summary>
	 /// 扫荡次数
	 /// </summary>
	private int swarmCount; 

	/// <summary>
	 /// 关卡id
	 /// </summary>
	public void setChapterId(int chapterId){
		this.chapterId=chapterId;
	}

	/// <summary>
	 ///关卡id
	 /// </summary>
	public int  getChapterId(){  
		return chapterId; 
	}

	/// <summary>
	 /// 开启状态:ChapterConst.PROGRESS_STATUS_*
	 /// </summary>
	public void setStatus(int status){
		this.status=status;
	}

	/// <summary>
	 ///开启状态:ChapterConst.PROGRESS_STATUS_*
	 /// </summary>
	public int  getStatus(){  
		return status; 
	}

	/// <summary>
	 /// 通关次数
	 /// </summary>
	public void setPassCount(int passCount){
		this.passCount=passCount;
	}

	/// <summary>
	 ///通关次数
	 /// </summary>
	public int  getPassCount(){  
		return passCount; 
	}

	/// <summary>
	 /// 扫荡次数
	 /// </summary>
	public void setSwarmCount(int swarmCount){
		this.swarmCount=swarmCount;
	}

	/// <summary>
	 ///扫荡次数
	 /// </summary>
	public int  getSwarmCount(){  
		return swarmCount; 
	}

	public override string ToString() {
		return "chapterId:" + chapterId + "," + "status:" + status + "," + "passCount:" + passCount + "," + "swarmCount:" + swarmCount;
	}

}
}