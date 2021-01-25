using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.player{

/// <summary>
 /// 改名
 /// </summary>
public class RenamePo_Rp  : BasePo{

	public const int cmd = -181073;
	public const string reflectClassName = "com.hbt.protocol.po.player.RenamePo_Rp";

	public RenamePo_Rp():base() {
		commandId = -181073;
		encryptTypeDown = 0;
	}

	public RenamePo_Rp(MemoryStream inputStream){
		commandId = -181073;
		encryptTypeDown = 0;
		this.setResult(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getResult());
	}

	/// <summary>
	 ///成功与否: PlayerConst.RENAME_RESULT_*
	 /// </summary>
	private int result; 

	/// <summary>
	 ///成功与否: PlayerConst.RENAME_RESULT_*
	 /// </summary>
	public void setResult(int result){
		this.result=result;
	}

	/// <summary>
	 ///成功与否: PlayerConst.RENAME_RESULT_*
	 /// </summary>
	public int  getResult(){  
		return result; 
	}

	public override string ToString() {
		return "result:" + result;
	}

}
}