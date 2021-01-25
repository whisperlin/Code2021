using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.town{

/// <summary>
 /// 更换头像
 /// </summary>
public class ChangeAvatarIconPo_Rp  : BasePo{

	public const int cmd = -246612;
	public const string reflectClassName = "com.hbt.protocol.po.town.ChangeAvatarIconPo_Rp";

	public ChangeAvatarIconPo_Rp():base() {
		commandId = -246612;
		encryptTypeDown = 0;
	}

	public ChangeAvatarIconPo_Rp(MemoryStream inputStream){
		commandId = -246612;
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