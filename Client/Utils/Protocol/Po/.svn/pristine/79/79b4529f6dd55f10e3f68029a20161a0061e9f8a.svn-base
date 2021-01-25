using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.district{

/// <summary>
 /// 打开小区域
 /// </summary>
public class OpenAreaPo_Rp  : BasePo{

	public const int cmd = -443220;
	public const string reflectClassName = "com.hbt.protocol.po.district.OpenAreaPo_Rp";

	public OpenAreaPo_Rp():base() {
		commandId = -443220;
		encryptTypeDown = 0;
	}

	public OpenAreaPo_Rp(MemoryStream inputStream){
		commandId = -443220;
		encryptTypeDown = 0;
		this.setId(PackageUtil.DecodeInteger(inputStream));
		this.setResult(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getId());
		PackageUtil.EncodeInteger(outputStream, getResult());
	}

	/// <summary>
	 ///唯一ID
	 /// </summary>
	private int id; 

	/// <summary>
	 ///结果: DefaultConst.COMM_RESULT_*
	 /// </summary>
	private int result; 

	/// <summary>
	 ///唯一ID
	 /// </summary>
	public void setId(int id){
		this.id=id;
	}

	/// <summary>
	 ///唯一ID
	 /// </summary>
	public int  getId(){  
		return id; 
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

	public override string ToString() {
		return "id:" + id + "," + "result:" + result;
	}

}
}