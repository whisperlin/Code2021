using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.district{

/// <summary>
 /// 街区资料
 /// </summary>
public class DistrictInfoPo : BasePo{

	public const int cmd = 443216;
	public const string reflectClassName = "com.hbt.protocol.po.district.DistrictInfoPo";

	public DistrictInfoPo():base() {
		commandId = 443216;
		encryptTypeUp = 0;
	}

	public DistrictInfoPo(MemoryStream inputStream){
		commandId = 443216;
		encryptTypeUp = 0;
		this.setDistrictId(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getDistrictId());
	}

	/// <summary>
	 /// 大街区ID（1~8）,输入0则返回所有街区
	 /// </summary>
	private int districtId; 

	/// <summary>
	 /// 大街区ID（1~8）,输入0则返回所有街区
	 /// </summary>
	public void setDistrictId(int districtId){
		this.districtId=districtId;
	}

	/// <summary>
	 ///大街区ID（1~8）,输入0则返回所有街区
	 /// </summary>
	public int  getDistrictId(){  
		return districtId; 
	}

	public override string ToString() {
		return "districtId:" + districtId;
	}

}
}