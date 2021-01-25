using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.house{

/// <summary>
 /// 阵型列表
 /// </summary>
public class FormationListPo : BasePo{

	public const int cmd = 312151;
	public const string reflectClassName = "com.hbt.protocol.po.house.FormationListPo";

	public FormationListPo():base() {
		commandId = 312151;
		encryptTypeUp = 0;
	}

	public FormationListPo(MemoryStream inputStream){
		commandId = 312151;
		encryptTypeUp = 0;
		this.setPlanId(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getPlanId());
	}

	/// <summary>
	 /// 方案ID(默认1)
	 /// </summary>
	private int planId; 

	/// <summary>
	 /// 方案ID(默认1)
	 /// </summary>
	public void setPlanId(int planId){
		this.planId=planId;
	}

	/// <summary>
	 ///方案ID(默认1)
	 /// </summary>
	public int  getPlanId(){  
		return planId; 
	}

	public override string ToString() {
		return "planId:" + planId;
	}

}
}