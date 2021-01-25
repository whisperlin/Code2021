using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.town{

/// <summary>
 /// 激活配方
 /// </summary>
public class ActiveFormulaPo_Rp  : BasePo{

	public const int cmd = -246616;
	public const string reflectClassName = "com.hbt.protocol.po.town.ActiveFormulaPo_Rp";

	public ActiveFormulaPo_Rp():base() {
		commandId = -246616;
		encryptTypeDown = 0;
	}

	public ActiveFormulaPo_Rp(MemoryStream inputStream){
		commandId = -246616;
		encryptTypeDown = 0;
		this.setResult(PackageUtil.DecodeInteger(inputStream));
		this.setId(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getResult());
		PackageUtil.EncodeInteger(outputStream, getId());
	}

	/// <summary>
	 ///结果: DefaultConst.COMM_RESULT_*
	 /// </summary>
	private int result; 

	/// <summary>
	 ///配方ID
	 /// </summary>
	private int id; 

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

	/// <summary>
	 ///配方ID
	 /// </summary>
	public void setId(int id){
		this.id=id;
	}

	/// <summary>
	 ///配方ID
	 /// </summary>
	public int  getId(){  
		return id; 
	}

	public override string ToString() {
		return "result:" + result + "," + "id:" + id;
	}

}
}