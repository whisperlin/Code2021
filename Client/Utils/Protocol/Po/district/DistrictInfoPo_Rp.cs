using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.district{

/// <summary>
 /// 街区资料
 /// </summary>
public class DistrictInfoPo_Rp  : BasePo{

	public const int cmd = -443216;
	public const string reflectClassName = "com.hbt.protocol.po.district.DistrictInfoPo_Rp";

	public DistrictInfoPo_Rp():base() {
		commandId = -443216;
		encryptTypeDown = 0;
	}

	public DistrictInfoPo_Rp(MemoryStream inputStream){
		commandId = -443216;
		encryptTypeDown = 0;

		short length0 = PackageUtil.DecodeShort(inputStream);//集合长度
		List<com.hbt.protocol.po.district.AreaPo> areas = new List<com.hbt.protocol.po.district.AreaPo>();
		for(int i = 0; i < length0; i++){
			PackageUtil.skipInputStream(inputStream, 4);//读4位
			areas.Add(new com.hbt.protocol.po.district.AreaPo(inputStream));
		}
		this.setAreas(areas);
		this.setStdATotal(PackageUtil.DecodeInteger(inputStream));
		this.setStdBTotal(PackageUtil.DecodeInteger(inputStream));
		this.setStdCTotal(PackageUtil.DecodeInteger(inputStream));
		this.setResATotal(PackageUtil.DecodeInteger(inputStream));
		this.setResBTotal(PackageUtil.DecodeInteger(inputStream));
		this.setResCTotal(PackageUtil.DecodeInteger(inputStream));
		this.setResEgTotal(PackageUtil.DecodeInteger(inputStream));
		this.setResAGenTotal(PackageUtil.DecodeInteger(inputStream));
		this.setResBGenTotal(PackageUtil.DecodeInteger(inputStream));
		this.setResCGenTotal(PackageUtil.DecodeInteger(inputStream));
		this.setResEgGenTotal(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);

		List<com.hbt.protocol.po.district.AreaPo> areas = getAreas();
		short areaslength = (short)(areas == null ? 0 : areas.Count);
		PackageUtil.EncodeShort(outputStream, areaslength);
		for(int i = 0; i < areaslength; i++){
			areas[i].encodeVo(outputStream);
		}
		PackageUtil.EncodeInteger(outputStream, getStdATotal());
		PackageUtil.EncodeInteger(outputStream, getStdBTotal());
		PackageUtil.EncodeInteger(outputStream, getStdCTotal());
		PackageUtil.EncodeInteger(outputStream, getResATotal());
		PackageUtil.EncodeInteger(outputStream, getResBTotal());
		PackageUtil.EncodeInteger(outputStream, getResCTotal());
		PackageUtil.EncodeInteger(outputStream, getResEgTotal());
		PackageUtil.EncodeInteger(outputStream, getResAGenTotal());
		PackageUtil.EncodeInteger(outputStream, getResBGenTotal());
		PackageUtil.EncodeInteger(outputStream, getResCGenTotal());
		PackageUtil.EncodeInteger(outputStream, getResEgGenTotal());
	}

	/// <summary>
	 ///具体街区地块资料
	 /// </summary>
	private List<com.hbt.protocol.po.district.AreaPo> areas; 

	/// <summary>
	 ///总提供生态
	 /// </summary>
	private int stdATotal; 

	/// <summary>
	 ///总提供休闲
	 /// </summary>
	private int stdBTotal; 

	/// <summary>
	 ///总提供文化
	 /// </summary>
	private int stdCTotal; 

	/// <summary>
	 ///总占用环保
	 /// </summary>
	private int resATotal; 

	/// <summary>
	 ///总占用娱乐
	 /// </summary>
	private int resBTotal; 

	/// <summary>
	 ///总占用教育
	 /// </summary>
	private int resCTotal; 

	/// <summary>
	 ///总占用电力
	 /// </summary>
	private int resEgTotal; 

	/// <summary>
	 ///总提供环保
	 /// </summary>
	private int resAGenTotal; 

	/// <summary>
	 ///总提供娱乐
	 /// </summary>
	private int resBGenTotal; 

	/// <summary>
	 ///总提供教育
	 /// </summary>
	private int resCGenTotal; 

	/// <summary>
	 ///总提供电力
	 /// </summary>
	private int resEgGenTotal; 

	/// <summary>
	 ///具体街区地块资料
	 /// </summary>
	public void setAreas(List<com.hbt.protocol.po.district.AreaPo> areas){
		this.areas=areas;
	}

	/// <summary>
	 ///具体街区地块资料
	 /// </summary>
	public List<com.hbt.protocol.po.district.AreaPo> getAreas(){  
		return areas; 
	}

	/// <summary>
	 ///总提供生态
	 /// </summary>
	public void setStdATotal(int stdATotal){
		this.stdATotal=stdATotal;
	}

	/// <summary>
	 ///总提供生态
	 /// </summary>
	public int  getStdATotal(){  
		return stdATotal; 
	}

	/// <summary>
	 ///总提供休闲
	 /// </summary>
	public void setStdBTotal(int stdBTotal){
		this.stdBTotal=stdBTotal;
	}

	/// <summary>
	 ///总提供休闲
	 /// </summary>
	public int  getStdBTotal(){  
		return stdBTotal; 
	}

	/// <summary>
	 ///总提供文化
	 /// </summary>
	public void setStdCTotal(int stdCTotal){
		this.stdCTotal=stdCTotal;
	}

	/// <summary>
	 ///总提供文化
	 /// </summary>
	public int  getStdCTotal(){  
		return stdCTotal; 
	}

	/// <summary>
	 ///总占用环保
	 /// </summary>
	public void setResATotal(int resATotal){
		this.resATotal=resATotal;
	}

	/// <summary>
	 ///总占用环保
	 /// </summary>
	public int  getResATotal(){  
		return resATotal; 
	}

	/// <summary>
	 ///总占用娱乐
	 /// </summary>
	public void setResBTotal(int resBTotal){
		this.resBTotal=resBTotal;
	}

	/// <summary>
	 ///总占用娱乐
	 /// </summary>
	public int  getResBTotal(){  
		return resBTotal; 
	}

	/// <summary>
	 ///总占用教育
	 /// </summary>
	public void setResCTotal(int resCTotal){
		this.resCTotal=resCTotal;
	}

	/// <summary>
	 ///总占用教育
	 /// </summary>
	public int  getResCTotal(){  
		return resCTotal; 
	}

	/// <summary>
	 ///总占用电力
	 /// </summary>
	public void setResEgTotal(int resEgTotal){
		this.resEgTotal=resEgTotal;
	}

	/// <summary>
	 ///总占用电力
	 /// </summary>
	public int  getResEgTotal(){  
		return resEgTotal; 
	}

	/// <summary>
	 ///总提供环保
	 /// </summary>
	public void setResAGenTotal(int resAGenTotal){
		this.resAGenTotal=resAGenTotal;
	}

	/// <summary>
	 ///总提供环保
	 /// </summary>
	public int  getResAGenTotal(){  
		return resAGenTotal; 
	}

	/// <summary>
	 ///总提供娱乐
	 /// </summary>
	public void setResBGenTotal(int resBGenTotal){
		this.resBGenTotal=resBGenTotal;
	}

	/// <summary>
	 ///总提供娱乐
	 /// </summary>
	public int  getResBGenTotal(){  
		return resBGenTotal; 
	}

	/// <summary>
	 ///总提供教育
	 /// </summary>
	public void setResCGenTotal(int resCGenTotal){
		this.resCGenTotal=resCGenTotal;
	}

	/// <summary>
	 ///总提供教育
	 /// </summary>
	public int  getResCGenTotal(){  
		return resCGenTotal; 
	}

	/// <summary>
	 ///总提供电力
	 /// </summary>
	public void setResEgGenTotal(int resEgGenTotal){
		this.resEgGenTotal=resEgGenTotal;
	}

	/// <summary>
	 ///总提供电力
	 /// </summary>
	public int  getResEgGenTotal(){  
		return resEgGenTotal; 
	}

	public override string ToString() {
		return "areas size:" + areas.Count + "," + "stdATotal:" + stdATotal + "," + "stdBTotal:" + stdBTotal + "," + "stdCTotal:" + stdCTotal + "," + "resATotal:" + resATotal + "," + "resBTotal:" + resBTotal + "," + "resCTotal:" + resCTotal + "," + "resEgTotal:" + resEgTotal + "," + "resAGenTotal:" + resAGenTotal + "," + "resBGenTotal:" + resBGenTotal + "," + "resCGenTotal:" + resCGenTotal + "," + "resEgGenTotal:" + resEgGenTotal;
	}

}
}