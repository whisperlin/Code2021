using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.chapter{

/// <summary>
 /// 玩家开图点
 /// </summary>
public class WalkPo : BasePo{

	public const int cmd = 770910;
	public const string reflectClassName = "com.hbt.protocol.po.chapter.WalkPo";

	public WalkPo():base() {
		commandId = 770910;
		encryptTypeUp = 0;
	}

	public WalkPo(MemoryStream inputStream){
		commandId = 770910;
		encryptTypeUp = 0;
		this.setOrd(PackageUtil.DecodeInteger(inputStream));
		this.setMapid(PackageUtil.DecodeInteger(inputStream));
		this.setCurrFood(PackageUtil.DecodeInteger(inputStream));
		this.setResult(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getOrd());
		PackageUtil.EncodeInteger(outputStream, getMapid());
		PackageUtil.EncodeInteger(outputStream, getCurrFood());
		PackageUtil.EncodeInteger(outputStream, getResult());
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
	 /// 消耗食物量
	 /// </summary>
	private int currFood; 

	/// <summary>
	 /// 执行结果：ChapterConst.WALK_RESULT_*
	 /// </summary>
	private int result; 

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
	 /// 消耗食物量
	 /// </summary>
	public void setCurrFood(int currFood){
		this.currFood=currFood;
	}

	/// <summary>
	 ///消耗食物量
	 /// </summary>
	public int  getCurrFood(){  
		return currFood; 
	}

	/// <summary>
	 /// 执行结果：ChapterConst.WALK_RESULT_*
	 /// </summary>
	public void setResult(int result){
		this.result=result;
	}

	/// <summary>
	 ///执行结果：ChapterConst.WALK_RESULT_*
	 /// </summary>
	public int  getResult(){  
		return result; 
	}

	public override string ToString() {
		return "ord:" + ord + "," + "mapid:" + mapid + "," + "currFood:" + currFood + "," + "result:" + result;
	}

}
}