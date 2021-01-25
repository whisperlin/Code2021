using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.chapter{

/// <summary>
 /// 执行地图元素对话框（如宝箱，NPC等）
 /// </summary>
public class ExcuteWalkPo : BasePo{

	public const int cmd = 770909;
	public const string reflectClassName = "com.hbt.protocol.po.chapter.ExcuteWalkPo";

	public ExcuteWalkPo():base() {
		commandId = 770909;
		encryptTypeUp = 0;
	}

	public ExcuteWalkPo(MemoryStream inputStream){
		commandId = 770909;
		encryptTypeUp = 0;
		this.setOrd(PackageUtil.DecodeInteger(inputStream));
		this.setMapid(PackageUtil.DecodeInteger(inputStream));
		this.setUseFood(PackageUtil.DecodeInteger(inputStream));
		this.setCurrFood(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getOrd());
		PackageUtil.EncodeInteger(outputStream, getMapid());
		PackageUtil.EncodeInteger(outputStream, getUseFood());
		PackageUtil.EncodeInteger(outputStream, getCurrFood());
	}

	/// <summary>
	 /// 当前步数
	 /// </summary>
	private int ord; 

	/// <summary>
	 /// 地图唯一ID
	 /// </summary>
	private int mapid; 

	/// <summary>
	 /// 当前食物量
	 /// </summary>
	private int useFood; 

	/// <summary>
	 /// 当前食物量(扣前的)
	 /// </summary>
	private int currFood; 

	/// <summary>
	 /// 当前步数
	 /// </summary>
	public void setOrd(int ord){
		this.ord=ord;
	}

	/// <summary>
	 ///当前步数
	 /// </summary>
	public int  getOrd(){  
		return ord; 
	}

	/// <summary>
	 /// 地图唯一ID
	 /// </summary>
	public void setMapid(int mapid){
		this.mapid=mapid;
	}

	/// <summary>
	 ///地图唯一ID
	 /// </summary>
	public int  getMapid(){  
		return mapid; 
	}

	/// <summary>
	 /// 当前食物量
	 /// </summary>
	public void setUseFood(int useFood){
		this.useFood=useFood;
	}

	/// <summary>
	 ///当前食物量
	 /// </summary>
	public int  getUseFood(){  
		return useFood; 
	}

	/// <summary>
	 /// 当前食物量(扣前的)
	 /// </summary>
	public void setCurrFood(int currFood){
		this.currFood=currFood;
	}

	/// <summary>
	 ///当前食物量(扣前的)
	 /// </summary>
	public int  getCurrFood(){  
		return currFood; 
	}

	public override string ToString() {
		return "ord:" + ord + "," + "mapid:" + mapid + "," + "useFood:" + useFood + "," + "currFood:" + currFood;
	}

}
}