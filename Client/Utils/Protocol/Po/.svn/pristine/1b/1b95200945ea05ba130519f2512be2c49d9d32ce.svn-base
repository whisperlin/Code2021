using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.town{

/// <summary>
 /// 城镇资料
 /// </summary>
public class TownInfoPo_Rp  : BasePo{

	public const int cmd = -246608;
	public const string reflectClassName = "com.hbt.protocol.po.town.TownInfoPo_Rp";

	public TownInfoPo_Rp():base() {
		commandId = -246608;
		encryptTypeDown = 0;
	}

	public TownInfoPo_Rp(MemoryStream inputStream){
		commandId = -246608;
		encryptTypeDown = 0;
		this.setNick(PackageUtil.DecodeString(inputStream));
		this.setAvatarIcon(PackageUtil.DecodeInteger(inputStream));
		this.setPower(PackageUtil.DecodeInteger(inputStream));
		this.setDiamond(PackageUtil.DecodeInteger(inputStream));
		this.setCoin(PackageUtil.DecodeInteger(inputStream));
		this.setFood(PackageUtil.DecodeInteger(inputStream));
		this.setFoodCap(PackageUtil.DecodeInteger(inputStream));
		this.setFoodPpm(PackageUtil.DecodeFloat(inputStream));
		this.setHappy(PackageUtil.DecodeFloat(inputStream));
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
		this.setTownLv(PackageUtil.DecodeInteger(inputStream));
		this.setExp(PackageUtil.DecodeInteger(inputStream));
		this.setFoodLv(PackageUtil.DecodeInteger(inputStream));
		this.setHouseLv(PackageUtil.DecodeInteger(inputStream));
		this.setLandCount(PackageUtil.DecodeInteger(inputStream));
		this.setSeatCount(PackageUtil.DecodeInteger(inputStream));
		this.setLastReapTime(PackageUtil.DecodeLong(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeString(outputStream, getNick());
		PackageUtil.EncodeInteger(outputStream, getAvatarIcon());
		PackageUtil.EncodeInteger(outputStream, getPower());
		PackageUtil.EncodeInteger(outputStream, getDiamond());
		PackageUtil.EncodeInteger(outputStream, getCoin());
		PackageUtil.EncodeInteger(outputStream, getFood());
		PackageUtil.EncodeInteger(outputStream, getFoodCap());
		PackageUtil.EncodeFloat(outputStream, getFoodPpm());
		PackageUtil.EncodeFloat(outputStream, getHappy());
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
		PackageUtil.EncodeInteger(outputStream, getTownLv());
		PackageUtil.EncodeInteger(outputStream, getExp());
		PackageUtil.EncodeInteger(outputStream, getFoodLv());
		PackageUtil.EncodeInteger(outputStream, getHouseLv());
		PackageUtil.EncodeInteger(outputStream, getLandCount());
		PackageUtil.EncodeInteger(outputStream, getSeatCount());
		PackageUtil.EncodeLong(outputStream, getLastReapTime());
	}

	/// <summary>
	 ///名字
	 /// </summary>
	private string nick; 

	/// <summary>
	 ///头像
	 /// </summary>
	private int avatarIcon; 

	/// <summary>
	 ///实力
	 /// </summary>
	private int power; 

	/// <summary>
	 ///持有钻石
	 /// </summary>
	private int diamond; 

	/// <summary>
	 ///持有金币
	 /// </summary>
	private int coin; 

	/// <summary>
	 ///持有食物
	 /// </summary>
	private int food; 

	/// <summary>
	 ///持有食物上限
	 /// </summary>
	private int foodCap; 

	/// <summary>
	 ///食物产量
	 /// </summary>
	private float foodPpm; 

	/// <summary>
	 ///满意度
	 /// </summary>
	private float happy; 

	/// <summary>
	 ///环境
	 /// </summary>
	private int stdA; 

	/// <summary>
	 ///娱乐
	 /// </summary>
	private int stdB; 

	/// <summary>
	 ///文化
	 /// </summary>
	private int stdC; 

	/// <summary>
	 ///环保(已消耗)
	 /// </summary>
	private int resA; 

	/// <summary>
	 ///研究(已消耗)
	 /// </summary>
	private int resB; 

	/// <summary>
	 ///教育(已消耗)
	 /// </summary>
	private int resC; 

	/// <summary>
	 ///电力(已消耗)
	 /// </summary>
	private int resEg; 

	/// <summary>
	 ///环保(产能)
	 /// </summary>
	private int resAGen; 

	/// <summary>
	 ///研究(产能)
	 /// </summary>
	private int resBGen; 

	/// <summary>
	 ///教育(产能)
	 /// </summary>
	private int resCGen; 

	/// <summary>
	 ///电力(产能)
	 /// </summary>
	private int resEgGen; 

	/// <summary>
	 ///城镇等级
	 /// </summary>
	private int townLv; 

	/// <summary>
	 ///城镇声望
	 /// </summary>
	private int exp; 

	/// <summary>
	 ///食物工厂等级
	 /// </summary>
	private int foodLv; 

	/// <summary>
	 ///居民楼等级
	 /// </summary>
	private int houseLv; 

	/// <summary>
	 ///土地数量
	 /// </summary>
	private int landCount; 

	/// <summary>
	 ///出战格子数
	 /// </summary>
	private int seatCount; 

	/// <summary>
	 ///上一次收割粮食时间
	 /// </summary>
	private ulong lastReapTime; 

	/// <summary>
	 ///名字
	 /// </summary>
	public void setNick(string nick){
		this.nick=nick;
	}

	/// <summary>
	 ///名字
	 /// </summary>
	public string  getNick(){  
		return nick; 
	}

	/// <summary>
	 ///头像
	 /// </summary>
	public void setAvatarIcon(int avatarIcon){
		this.avatarIcon=avatarIcon;
	}

	/// <summary>
	 ///头像
	 /// </summary>
	public int  getAvatarIcon(){  
		return avatarIcon; 
	}

	/// <summary>
	 ///实力
	 /// </summary>
	public void setPower(int power){
		this.power=power;
	}

	/// <summary>
	 ///实力
	 /// </summary>
	public int  getPower(){  
		return power; 
	}

	/// <summary>
	 ///持有钻石
	 /// </summary>
	public void setDiamond(int diamond){
		this.diamond=diamond;
	}

	/// <summary>
	 ///持有钻石
	 /// </summary>
	public int  getDiamond(){  
		return diamond; 
	}

	/// <summary>
	 ///持有金币
	 /// </summary>
	public void setCoin(int coin){
		this.coin=coin;
	}

	/// <summary>
	 ///持有金币
	 /// </summary>
	public int  getCoin(){  
		return coin; 
	}

	/// <summary>
	 ///持有食物
	 /// </summary>
	public void setFood(int food){
		this.food=food;
	}

	/// <summary>
	 ///持有食物
	 /// </summary>
	public int  getFood(){  
		return food; 
	}

	/// <summary>
	 ///持有食物上限
	 /// </summary>
	public void setFoodCap(int foodCap){
		this.foodCap=foodCap;
	}

	/// <summary>
	 ///持有食物上限
	 /// </summary>
	public int  getFoodCap(){  
		return foodCap; 
	}

	/// <summary>
	 ///食物产量
	 /// </summary>
	public void setFoodPpm(float foodPpm){
		this.foodPpm=foodPpm;
	}

	/// <summary>
	 ///食物产量
	 /// </summary>
	public float  getFoodPpm(){  
		return foodPpm; 
	}

	/// <summary>
	 ///满意度
	 /// </summary>
	public void setHappy(float happy){
		this.happy=happy;
	}

	/// <summary>
	 ///满意度
	 /// </summary>
	public float  getHappy(){  
		return happy; 
	}

	/// <summary>
	 ///环境
	 /// </summary>
	public void setStdA(int stdA){
		this.stdA=stdA;
	}

	/// <summary>
	 ///环境
	 /// </summary>
	public int  getStdA(){  
		return stdA; 
	}

	/// <summary>
	 ///娱乐
	 /// </summary>
	public void setStdB(int stdB){
		this.stdB=stdB;
	}

	/// <summary>
	 ///娱乐
	 /// </summary>
	public int  getStdB(){  
		return stdB; 
	}

	/// <summary>
	 ///文化
	 /// </summary>
	public void setStdC(int stdC){
		this.stdC=stdC;
	}

	/// <summary>
	 ///文化
	 /// </summary>
	public int  getStdC(){  
		return stdC; 
	}

	/// <summary>
	 ///环保(已消耗)
	 /// </summary>
	public void setResA(int resA){
		this.resA=resA;
	}

	/// <summary>
	 ///环保(已消耗)
	 /// </summary>
	public int  getResA(){  
		return resA; 
	}

	/// <summary>
	 ///研究(已消耗)
	 /// </summary>
	public void setResB(int resB){
		this.resB=resB;
	}

	/// <summary>
	 ///研究(已消耗)
	 /// </summary>
	public int  getResB(){  
		return resB; 
	}

	/// <summary>
	 ///教育(已消耗)
	 /// </summary>
	public void setResC(int resC){
		this.resC=resC;
	}

	/// <summary>
	 ///教育(已消耗)
	 /// </summary>
	public int  getResC(){  
		return resC; 
	}

	/// <summary>
	 ///电力(已消耗)
	 /// </summary>
	public void setResEg(int resEg){
		this.resEg=resEg;
	}

	/// <summary>
	 ///电力(已消耗)
	 /// </summary>
	public int  getResEg(){  
		return resEg; 
	}

	/// <summary>
	 ///环保(产能)
	 /// </summary>
	public void setResAGen(int resAGen){
		this.resAGen=resAGen;
	}

	/// <summary>
	 ///环保(产能)
	 /// </summary>
	public int  getResAGen(){  
		return resAGen; 
	}

	/// <summary>
	 ///研究(产能)
	 /// </summary>
	public void setResBGen(int resBGen){
		this.resBGen=resBGen;
	}

	/// <summary>
	 ///研究(产能)
	 /// </summary>
	public int  getResBGen(){  
		return resBGen; 
	}

	/// <summary>
	 ///教育(产能)
	 /// </summary>
	public void setResCGen(int resCGen){
		this.resCGen=resCGen;
	}

	/// <summary>
	 ///教育(产能)
	 /// </summary>
	public int  getResCGen(){  
		return resCGen; 
	}

	/// <summary>
	 ///电力(产能)
	 /// </summary>
	public void setResEgGen(int resEgGen){
		this.resEgGen=resEgGen;
	}

	/// <summary>
	 ///电力(产能)
	 /// </summary>
	public int  getResEgGen(){  
		return resEgGen; 
	}

	/// <summary>
	 ///城镇等级
	 /// </summary>
	public void setTownLv(int townLv){
		this.townLv=townLv;
	}

	/// <summary>
	 ///城镇等级
	 /// </summary>
	public int  getTownLv(){  
		return townLv; 
	}

	/// <summary>
	 ///城镇声望
	 /// </summary>
	public void setExp(int exp){
		this.exp=exp;
	}

	/// <summary>
	 ///城镇声望
	 /// </summary>
	public int  getExp(){  
		return exp; 
	}

	/// <summary>
	 ///食物工厂等级
	 /// </summary>
	public void setFoodLv(int foodLv){
		this.foodLv=foodLv;
	}

	/// <summary>
	 ///食物工厂等级
	 /// </summary>
	public int  getFoodLv(){  
		return foodLv; 
	}

	/// <summary>
	 ///居民楼等级
	 /// </summary>
	public void setHouseLv(int houseLv){
		this.houseLv=houseLv;
	}

	/// <summary>
	 ///居民楼等级
	 /// </summary>
	public int  getHouseLv(){  
		return houseLv; 
	}

	/// <summary>
	 ///土地数量
	 /// </summary>
	public void setLandCount(int landCount){
		this.landCount=landCount;
	}

	/// <summary>
	 ///土地数量
	 /// </summary>
	public int  getLandCount(){  
		return landCount; 
	}

	/// <summary>
	 ///出战格子数
	 /// </summary>
	public void setSeatCount(int seatCount){
		this.seatCount=seatCount;
	}

	/// <summary>
	 ///出战格子数
	 /// </summary>
	public int  getSeatCount(){  
		return seatCount; 
	}

	/// <summary>
	 ///上一次收割粮食时间
	 /// </summary>
	public void setLastReapTime(ulong lastReapTime){
		this.lastReapTime=lastReapTime;
	}

	/// <summary>
	 ///上一次收割粮食时间
	 /// </summary>
	public ulong  getLastReapTime(){  
		return lastReapTime; 
	}

	public override string ToString() {
		return "nick:" + nick + "," + "avatarIcon:" + avatarIcon + "," + "power:" + power + "," + "diamond:" + diamond + "," + "coin:" + coin + "," + "food:" + food + "," + "foodCap:" + foodCap + "," + "foodPpm:" + foodPpm + "," + "happy:" + happy + "," + "stdA:" + stdA + "," + "stdB:" + stdB + "," + "stdC:" + stdC + "," + "resA:" + resA + "," + "resB:" + resB + "," + "resC:" + resC + "," + "resEg:" + resEg + "," + "resAGen:" + resAGen + "," + "resBGen:" + resBGen + "," + "resCGen:" + resCGen + "," + "resEgGen:" + resEgGen + "," + "townLv:" + townLv + "," + "exp:" + exp + "," + "foodLv:" + foodLv + "," + "houseLv:" + houseLv + "," + "landCount:" + landCount + "," + "seatCount:" + seatCount + "," + "lastReapTime:" + lastReapTime;
	}

}
}