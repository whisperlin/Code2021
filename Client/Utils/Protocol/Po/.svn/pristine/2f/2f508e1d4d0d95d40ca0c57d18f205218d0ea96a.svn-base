using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.house{

/// <summary>
 /// 调整阵型
 /// </summary>
public class SetFormationPo_Rp  : BasePo{

	public const int cmd = -312153;
	public const string reflectClassName = "com.hbt.protocol.po.house.SetFormationPo_Rp";

	public SetFormationPo_Rp():base() {
		commandId = -312153;
		encryptTypeDown = 0;
	}

	public SetFormationPo_Rp(MemoryStream inputStream){
		commandId = -312153;
		encryptTypeDown = 0;
		this.setResult(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getResult());
	}

	/// <summary>
	 ///结果: DefaultConst.COMM_RESULT_*
	 /// </summary>
	private int result; 

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
		return "result:" + result;
	}

}
}