using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po{

/// <summary>
 /// 异常通知
 /// </summary>
public class ExcptionAdvicePo : BasePo{

	public const int cmd = 999;
	public const string reflectClassName = "com.hbt.protocol.po.ExcptionAdvicePo";

	public ExcptionAdvicePo():base() {
		commandId = 999;
		encryptTypeUp = 0;
	}

	public ExcptionAdvicePo(MemoryStream inputStream){
		commandId = 999;
		encryptTypeUp = 0;
		this.setExcptionId(PackageUtil.DecodeInteger(inputStream));
		this.setType(PackageUtil.DecodeInteger(inputStream));
		this.setExcptionMsg(PackageUtil.DecodeString(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getExcptionId());
		PackageUtil.EncodeInteger(outputStream, getType());
		PackageUtil.EncodeString(outputStream, getExcptionMsg());
	}

	/// <summary>
	 /// 异常ID
	 /// </summary>
	private int excptionId; 

	/// <summary>
	 /// 类型 1需要刷新页面 2其他
	 /// </summary>
	private int type; 

	/// <summary>
	 /// 异常信息
	 /// </summary>
	private string excptionMsg; 

	/// <summary>
	 /// 异常ID
	 /// </summary>
	public void setExcptionId(int excptionId){
		this.excptionId=excptionId;
	}

	/// <summary>
	 ///异常ID
	 /// </summary>
	public int  getExcptionId(){  
		return excptionId; 
	}

	/// <summary>
	 /// 类型 1需要刷新页面 2其他
	 /// </summary>
	public void setType(int type){
		this.type=type;
	}

	/// <summary>
	 ///类型 1需要刷新页面 2其他
	 /// </summary>
	public int  getType(){  
		return type; 
	}

	/// <summary>
	 /// 异常信息
	 /// </summary>
	public void setExcptionMsg(string excptionMsg){
		this.excptionMsg=excptionMsg;
	}

	/// <summary>
	 ///异常信息
	 /// </summary>
	public string  getExcptionMsg(){  
		return excptionMsg; 
	}

	public override string ToString() {
		return "excptionId:" + excptionId + "," + "type:" + type + "," + "excptionMsg:" + excptionMsg;
	}

}
}