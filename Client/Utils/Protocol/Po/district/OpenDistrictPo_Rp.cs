using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.district{

/// <summary>
 /// 打开大街区
 /// </summary>
public class OpenDistrictPo_Rp  : BasePo{

	public const int cmd = -443219;
	public const string reflectClassName = "com.hbt.protocol.po.district.OpenDistrictPo_Rp";

	public OpenDistrictPo_Rp():base() {
		commandId = -443219;
		encryptTypeDown = 0;
	}

	public OpenDistrictPo_Rp(MemoryStream inputStream){
		commandId = -443219;
		encryptTypeDown = 0;
		this.setDistrictId(PackageUtil.DecodeInteger(inputStream));
		this.setResult(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getDistrictId());
		PackageUtil.EncodeInteger(outputStream, getResult());
	}

	/// <summary>
	 ///大街区ID（1~8）
	 /// </summary>
	private int districtId; 

	/// <summary>
	 ///结果: DefaultConst.COMM_RESULT_*
	 /// </summary>
	private int result; 

	/// <summary>
	 ///大街区ID（1~8）
	 /// </summary>
	public void setDistrictId(int districtId){
		this.districtId=districtId;
	}

	/// <summary>
	 ///大街区ID（1~8）
	 /// </summary>
	public int  getDistrictId(){  
		return districtId; 
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
		return "districtId:" + districtId + "," + "result:" + result;
	}

}
}