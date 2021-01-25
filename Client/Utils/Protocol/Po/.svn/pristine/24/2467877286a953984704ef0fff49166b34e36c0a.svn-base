using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.town{

/// <summary>
 /// 食品加工厂信息
 /// </summary>
public class FormulaInfoPo : BasePo{

	public const int cmd = 246615;
	public const string reflectClassName = "com.hbt.protocol.po.town.FormulaInfoPo";

	public FormulaInfoPo():base() {
		commandId = 246615;
		encryptTypeUp = 0;
	}

	public FormulaInfoPo(MemoryStream inputStream){
		commandId = 246615;
		encryptTypeUp = 0;
		this.setNouse(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getNouse());
	}

	/// <summary>
	 /// 占位
	 /// </summary>
	private int nouse; 

	/// <summary>
	 /// 占位
	 /// </summary>
	public void setNouse(int nouse){
		this.nouse=nouse;
	}

	/// <summary>
	 ///占位
	 /// </summary>
	public int  getNouse(){  
		return nouse; 
	}

	public override string ToString() {
		return "nouse:" + nouse;
	}

}
}