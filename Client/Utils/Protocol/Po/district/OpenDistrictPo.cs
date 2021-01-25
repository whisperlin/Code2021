using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.district{

/// <summary>
 /// 打开大街区
 /// </summary>
public class OpenDistrictPo : BasePo{

	public const int cmd = 443219;
	public const string reflectClassName = "com.hbt.protocol.po.district.OpenDistrictPo";

	public OpenDistrictPo():base() {
		commandId = 443219;
		encryptTypeUp = 0;
	}

	public OpenDistrictPo(MemoryStream inputStream){
		commandId = 443219;
		encryptTypeUp = 0;
		this.setDistrictId(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getDistrictId());
	}

	/// <summary>
	 /// 大街区ID（1~8）
	 /// </summary>
	private int districtId; 

	/// <summary>
	 /// 大街区ID（1~8）
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

	public override string ToString() {
		return "districtId:" + districtId;
	}

}
}