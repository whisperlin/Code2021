using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.town{

/// <summary>
 /// 单个配方状态
 /// </summary>
public class FormulaPo : BasePo{

	public const int cmd = 246614;
	public const string reflectClassName = "com.hbt.protocol.po.town.FormulaPo";

	public FormulaPo():base() {
		commandId = 246614;
		encryptTypeUp = 0;
	}

	public FormulaPo(MemoryStream inputStream){
		commandId = 246614;
		encryptTypeUp = 0;
		this.setId(PackageUtil.DecodeInteger(inputStream));
		this.setStatus(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getId());
		PackageUtil.EncodeInteger(outputStream, getStatus());
	}

	/// <summary>
	 /// 配方ID
	 /// </summary>
	private int id; 

	/// <summary>
	 /// 开启与激活状态 TownConst.FORMULA_*
	 /// </summary>
	private int status; 

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

	/// <summary>
	 /// 开启与激活状态 TownConst.FORMULA_*
	 /// </summary>
	public void setStatus(int status){
		this.status=status;
	}

	/// <summary>
	 ///开启与激活状态 TownConst.FORMULA_*
	 /// </summary>
	public int  getStatus(){  
		return status; 
	}

	public override string ToString() {
		return "id:" + id + "," + "status:" + status;
	}

}
}