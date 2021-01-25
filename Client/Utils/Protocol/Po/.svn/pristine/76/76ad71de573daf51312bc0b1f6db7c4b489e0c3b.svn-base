using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.town{

/// <summary>
 /// 激活配方
 /// </summary>
public class ActiveFormulaPo : BasePo{

	public const int cmd = 246616;
	public const string reflectClassName = "com.hbt.protocol.po.town.ActiveFormulaPo";

	public ActiveFormulaPo():base() {
		commandId = 246616;
		encryptTypeUp = 0;
	}

	public ActiveFormulaPo(MemoryStream inputStream){
		commandId = 246616;
		encryptTypeUp = 0;
		this.setId(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getId());
	}

	/// <summary>
	 /// 配方ID
	 /// </summary>
	private int id; 

	/// <summary>
	 /// 配方ID
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
		return "id:" + id;
	}

}
}