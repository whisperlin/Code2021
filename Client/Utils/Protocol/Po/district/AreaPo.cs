using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.district{

/// <summary>
 /// 街区-小区域
 /// </summary>
public class AreaPo : BasePo{

	public const int cmd = 443217;
	public const string reflectClassName = "com.hbt.protocol.po.district.AreaPo";

	public AreaPo():base() {
		commandId = 443217;
		encryptTypeUp = 0;
	}

	public AreaPo(MemoryStream inputStream){
		commandId = 443217;
		encryptTypeUp = 0;
		this.setId(PackageUtil.DecodeInteger(inputStream));
		this.setItemId(PackageUtil.DecodeLong(inputStream));
		this.setLevel(PackageUtil.DecodeInteger(inputStream));
		this.setOpened(PackageUtil.DecodeBoolean(inputStream));
		this.setBuilding(PackageUtil.DecodeInteger(inputStream));
		this.setLayout(PackageUtil.DecodeInteger(inputStream));
		this.setStdA(PackageUtil.DecodeInteger(inputStream));
		this.setStdB(PackageUtil.DecodeInteger(inputStream));
		this.setStdC(PackageUtil.DecodeInteger(inputStream));
		this.setResA(PackageUtil.DecodeInteger(inputStream));
		this.setResB(PackageUtil.DecodeInteger(inputStream));
		this.setResC(PackageUtil.DecodeInteger(inputStream));
		this.setResEg(PackageUtil.DecodeInteger(inputStream));
		this.setResAGen(PackageUtil.DecodeInteger(inputStream));
		this.setResBGen(PackageUtil.DecodeInteger(inputStream));
		this.setResCGen(PackageUtil.DecodeInteger(inputStream));
		this.setResEgGen(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getId());
		PackageUtil.EncodeLong(outputStream, getItemId());
		PackageUtil.EncodeInteger(outputStream, getLevel());
		PackageUtil.EncodeBoolean(outputStream, getOpened());
		PackageUtil.EncodeInteger(outputStream, getBuilding());
		PackageUtil.EncodeInteger(outputStream, getLayout());
		PackageUtil.EncodeInteger(outputStream, getStdA());
		PackageUtil.EncodeInteger(outputStream, getStdB());
		PackageUtil.EncodeInteger(outputStream, getStdC());
		PackageUtil.EncodeInteger(outputStream, getResA());
		PackageUtil.EncodeInteger(outputStream, getResB());
		PackageUtil.EncodeInteger(outputStream, getResC());
		PackageUtil.EncodeInteger(outputStream, getResEg());
		PackageUtil.EncodeInteger(outputStream, getResAGen());
		PackageUtil.EncodeInteger(outputStream, getResBGen());
		PackageUtil.EncodeInteger(outputStream, getResCGen());
		PackageUtil.EncodeInteger(outputStream, getResEgGen());
	}

	/// <summary>
	 /// 唯一ID
	 /// </summary>
	private int id; 

	/// <summary>
	 /// 物品ID
	 /// </summary>
	private ulong itemId; 

	/// <summary>
	 /// 建筑等级
	 /// </summary>
	private int level; 

	/// <summary>
	 /// 是否已经打开
	 /// </summary>
	private bool opened; 

	/// <summary>
	 /// 建造
	 /// </summary>
	private int building; 

	/// <summary>
	 /// 摆位，默认0
	 /// </summary>
	private int layout; 

	/// <summary>
	 /// 提供生态
	 /// </summary>
	private int stdA; 

	/// <summary>
	 /// 提供休闲
	 /// </summary>
	private int stdB; 

	/// <summary>
	 /// 提供文化
	 /// </summary>
	private int stdC; 

	/// <summary>
	 /// 占用环保
	 /// </summary>
	private int resA; 

	/// <summary>
	 /// 占用娱乐
	 /// </summary>
	private int resB; 

	/// <summary>
	 /// 占用教育
	 /// </summary>
	private int resC; 

	/// <summary>
	 /// 占用电力
	 /// </summary>
	private int resEg; 

	/// <summary>
	 /// 提供环保
	 /// </summary>
	private int resAGen; 

	/// <summary>
	 /// 提供娱乐
	 /// </summary>
	private int resBGen; 

	/// <summary>
	 /// 提供教育
	 /// </summary>
	private int resCGen; 

	/// <summary>
	 /// 提供电力
	 /// </summary>
	private int resEgGen; 

	/// <summary>
	 /// 唯一ID
	 /// </summary>
	public void setId(int id){
		this.id=id;
	}

	/// <summary>
	 ///唯一ID
	 /// </summary>
	public int  getId(){  
		return id; 
	}

	/// <summary>
	 /// 物品ID
	 /// </summary>
	public void setItemId(ulong itemId){
		this.itemId=itemId;
	}

	/// <summary>
	 ///物品ID
	 /// </summary>
	public ulong  getItemId(){  
		return itemId; 
	}

	/// <summary>
	 /// 建筑等级
	 /// </summary>
	public void setLevel(int level){
		this.level=level;
	}

	/// <summary>
	 ///建筑等级
	 /// </summary>
	public int  getLevel(){  
		return level; 
	}

	/// <summary>
	 /// 是否已经打开
	 /// </summary>
	public void setOpened(bool opened){
		this.opened=opened;
	}

	/// <summary>
	 ///是否已经打开
	 /// </summary>
	public bool  getOpened(){  
		return opened; 
	}

	/// <summary>
	 /// 建造
	 /// </summary>
	public void setBuilding(int building){
		this.building=building;
	}

	/// <summary>
	 ///建造
	 /// </summary>
	public int  getBuilding(){  
		return building; 
	}

	/// <summary>
	 /// 摆位，默认0
	 /// </summary>
	public void setLayout(int layout){
		this.layout=layout;
	}

	/// <summary>
	 ///摆位，默认0
	 /// </summary>
	public int  getLayout(){  
		return layout; 
	}

	/// <summary>
	 /// 提供生态
	 /// </summary>
	public void setStdA(int stdA){
		this.stdA=stdA;
	}

	/// <summary>
	 ///提供生态
	 /// </summary>
	public int  getStdA(){  
		return stdA; 
	}

	/// <summary>
	 /// 提供休闲
	 /// </summary>
	public void setStdB(int stdB){
		this.stdB=stdB;
	}

	/// <summary>
	 ///提供休闲
	 /// </summary>
	public int  getStdB(){  
		return stdB; 
	}

	/// <summary>
	 /// 提供文化
	 /// </summary>
	public void setStdC(int stdC){
		this.stdC=stdC;
	}

	/// <summary>
	 ///提供文化
	 /// </summary>
	public int  getStdC(){  
		return stdC; 
	}

	/// <summary>
	 /// 占用环保
	 /// </summary>
	public void setResA(int resA){
		this.resA=resA;
	}

	/// <summary>
	 ///占用环保
	 /// </summary>
	public int  getResA(){  
		return resA; 
	}

	/// <summary>
	 /// 占用娱乐
	 /// </summary>
	public void setResB(int resB){
		this.resB=resB;
	}

	/// <summary>
	 ///占用娱乐
	 /// </summary>
	public int  getResB(){  
		return resB; 
	}

	/// <summary>
	 /// 占用教育
	 /// </summary>
	public void setResC(int resC){
		this.resC=resC;
	}

	/// <summary>
	 ///占用教育
	 /// </summary>
	public int  getResC(){  
		return resC; 
	}

	/// <summary>
	 /// 占用电力
	 /// </summary>
	public void setResEg(int resEg){
		this.resEg=resEg;
	}

	/// <summary>
	 ///占用电力
	 /// </summary>
	public int  getResEg(){  
		return resEg; 
	}

	/// <summary>
	 /// 提供环保
	 /// </summary>
	public void setResAGen(int resAGen){
		this.resAGen=resAGen;
	}

	/// <summary>
	 ///提供环保
	 /// </summary>
	public int  getResAGen(){  
		return resAGen; 
	}

	/// <summary>
	 /// 提供娱乐
	 /// </summary>
	public void setResBGen(int resBGen){
		this.resBGen=resBGen;
	}

	/// <summary>
	 ///提供娱乐
	 /// </summary>
	public int  getResBGen(){  
		return resBGen; 
	}

	/// <summary>
	 /// 提供教育
	 /// </summary>
	public void setResCGen(int resCGen){
		this.resCGen=resCGen;
	}

	/// <summary>
	 ///提供教育
	 /// </summary>
	public int  getResCGen(){  
		return resCGen; 
	}

	/// <summary>
	 /// 提供电力
	 /// </summary>
	public void setResEgGen(int resEgGen){
		this.resEgGen=resEgGen;
	}

	/// <summary>
	 ///提供电力
	 /// </summary>
	public int  getResEgGen(){  
		return resEgGen; 
	}

	public override string ToString() {
		return "id:" + id + "," + "itemId:" + itemId + "," + "level:" + level + "," + "opened:" + opened + "," + "building:" + building + "," + "layout:" + layout + "," + "stdA:" + stdA + "," + "stdB:" + stdB + "," + "stdC:" + stdC + "," + "resA:" + resA + "," + "resB:" + resB + "," + "resC:" + resC + "," + "resEg:" + resEg + "," + "resAGen:" + resAGen + "," + "resBGen:" + resBGen + "," + "resCGen:" + resCGen + "," + "resEgGen:" + resEgGen;
	}

}
}