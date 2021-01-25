using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.house{

/// <summary>
 /// 宠物
 /// </summary>
public class PetPo : BasePo{

	public const int cmd = 312156;
	public const string reflectClassName = "com.hbt.protocol.po.house.PetPo";

	public PetPo():base() {
		commandId = 312156;
		encryptTypeUp = 0;
	}

	public PetPo(MemoryStream inputStream){
		commandId = 312156;
		encryptTypeUp = 0;
		this.setPetId(PackageUtil.DecodeInteger(inputStream));
		this.setCid(PackageUtil.DecodeInteger(inputStream));
		this.setLevel(PackageUtil.DecodeInteger(inputStream));
		this.setStarLv(PackageUtil.DecodeInteger(inputStream));
		this.setOcId(PackageUtil.DecodeInteger(inputStream));
		this.setHpMax(PackageUtil.DecodeInteger(inputStream));
		this.setAtk(PackageUtil.DecodeFloat(inputStream));
		this.setMag(PackageUtil.DecodeFloat(inputStream));
		this.setDf(PackageUtil.DecodeFloat(inputStream));
		this.setMdf(PackageUtil.DecodeFloat(inputStream));
		this.setRange(PackageUtil.DecodeFloat(inputStream));
		this.setAtkSpeed(PackageUtil.DecodeFloat(inputStream));
		this.setCritical(PackageUtil.DecodeFloat(inputStream));
		this.setCriticalRate(PackageUtil.DecodeFloat(inputStream));
		this.setReductionDf(PackageUtil.DecodeFloat(inputStream));
		this.setReductionMdf(PackageUtil.DecodeFloat(inputStream));
		this.setPower(PackageUtil.DecodeInteger(inputStream));

		short length0 = PackageUtil.DecodeShort(inputStream);//集合长度
		List<int> gifts = new List<int>();
		for(int i = 0; i < length0; i++){
			gifts.Add(PackageUtil.DecodeInteger(inputStream));
		}
		this.setGifts(gifts);
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getPetId());
		PackageUtil.EncodeInteger(outputStream, getCid());
		PackageUtil.EncodeInteger(outputStream, getLevel());
		PackageUtil.EncodeInteger(outputStream, getStarLv());
		PackageUtil.EncodeInteger(outputStream, getOcId());
		PackageUtil.EncodeInteger(outputStream, getHpMax());
		PackageUtil.EncodeFloat(outputStream, getAtk());
		PackageUtil.EncodeFloat(outputStream, getMag());
		PackageUtil.EncodeFloat(outputStream, getDf());
		PackageUtil.EncodeFloat(outputStream, getMdf());
		PackageUtil.EncodeFloat(outputStream, getRange());
		PackageUtil.EncodeFloat(outputStream, getAtkSpeed());
		PackageUtil.EncodeFloat(outputStream, getCritical());
		PackageUtil.EncodeFloat(outputStream, getCriticalRate());
		PackageUtil.EncodeFloat(outputStream, getReductionDf());
		PackageUtil.EncodeFloat(outputStream, getReductionMdf());
		PackageUtil.EncodeInteger(outputStream, getPower());

		List<int> gifts = getGifts();
		short giftslength = (short)(gifts == null ? 0 : gifts.Count);
		PackageUtil.EncodeShort(outputStream, giftslength);
		for(int i = 0; i < giftslength; i++){
			PackageUtil.EncodeInteger(outputStream, gifts[i]);
		}
	}

	/// <summary>
	 /// 宠物ID
	 /// </summary>
	private int petId; 

	/// <summary>
	 /// 宠物角色ID
	 /// </summary>
	private int cid; 

	/// <summary>
	 /// 宠物等级
	 /// </summary>
	private int level; 

	/// <summary>
	 /// 宠物星级
	 /// </summary>
	private int starLv; 

	/// <summary>
	 /// 角色职业ID
	 /// </summary>
	private int ocId; 

	/// <summary>
	 /// 最大生命值
	 /// </summary>
	private int hpMax; 

	/// <summary>
	 /// 力量
	 /// </summary>
	private float atk; 

	/// <summary>
	 /// 智力
	 /// </summary>
	private float mag; 

	/// <summary>
	 /// 防御
	 /// </summary>
	private float df; 

	/// <summary>
	 /// 精神
	 /// </summary>
	private float mdf; 

	/// <summary>
	 /// 射程
	 /// </summary>
	private float range; 

	/// <summary>
	 /// 攻速
	 /// </summary>
	private float atkSpeed; 

	/// <summary>
	 /// 暴击
	 /// </summary>
	private float critical; 

	/// <summary>
	 /// 实际暴击率
	 /// </summary>
	private float criticalRate; 

	/// <summary>
	 /// 防御减免系数
	 /// </summary>
	private float reductionDf; 

	/// <summary>
	 /// 魔法防御减免系数
	 /// </summary>
	private float reductionMdf; 

	/// <summary>
	 /// 战斗力
	 /// </summary>
	private int power; 

	/// <summary>
	 /// 被动技能
	 /// </summary>
	private List<int> gifts; 

	/// <summary>
	 /// 宠物ID
	 /// </summary>
	public void setPetId(int petId){
		this.petId=petId;
	}

	/// <summary>
	 ///宠物ID
	 /// </summary>
	public int  getPetId(){  
		return petId; 
	}

	/// <summary>
	 /// 宠物角色ID
	 /// </summary>
	public void setCid(int cid){
		this.cid=cid;
	}

	/// <summary>
	 ///宠物角色ID
	 /// </summary>
	public int  getCid(){  
		return cid; 
	}

	/// <summary>
	 /// 宠物等级
	 /// </summary>
	public void setLevel(int level){
		this.level=level;
	}

	/// <summary>
	 ///宠物等级
	 /// </summary>
	public int  getLevel(){  
		return level; 
	}

	/// <summary>
	 /// 宠物星级
	 /// </summary>
	public void setStarLv(int starLv){
		this.starLv=starLv;
	}

	/// <summary>
	 ///宠物星级
	 /// </summary>
	public int  getStarLv(){  
		return starLv; 
	}

	/// <summary>
	 /// 角色职业ID
	 /// </summary>
	public void setOcId(int ocId){
		this.ocId=ocId;
	}

	/// <summary>
	 ///角色职业ID
	 /// </summary>
	public int  getOcId(){  
		return ocId; 
	}

	/// <summary>
	 /// 最大生命值
	 /// </summary>
	public void setHpMax(int hpMax){
		this.hpMax=hpMax;
	}

	/// <summary>
	 ///最大生命值
	 /// </summary>
	public int  getHpMax(){  
		return hpMax; 
	}

	/// <summary>
	 /// 力量
	 /// </summary>
	public void setAtk(float atk){
		this.atk=atk;
	}

	/// <summary>
	 ///力量
	 /// </summary>
	public float  getAtk(){  
		return atk; 
	}

	/// <summary>
	 /// 智力
	 /// </summary>
	public void setMag(float mag){
		this.mag=mag;
	}

	/// <summary>
	 ///智力
	 /// </summary>
	public float  getMag(){  
		return mag; 
	}

	/// <summary>
	 /// 防御
	 /// </summary>
	public void setDf(float df){
		this.df=df;
	}

	/// <summary>
	 ///防御
	 /// </summary>
	public float  getDf(){  
		return df; 
	}

	/// <summary>
	 /// 精神
	 /// </summary>
	public void setMdf(float mdf){
		this.mdf=mdf;
	}

	/// <summary>
	 ///精神
	 /// </summary>
	public float  getMdf(){  
		return mdf; 
	}

	/// <summary>
	 /// 射程
	 /// </summary>
	public void setRange(float range){
		this.range=range;
	}

	/// <summary>
	 ///射程
	 /// </summary>
	public float  getRange(){  
		return range; 
	}

	/// <summary>
	 /// 攻速
	 /// </summary>
	public void setAtkSpeed(float atkSpeed){
		this.atkSpeed=atkSpeed;
	}

	/// <summary>
	 ///攻速
	 /// </summary>
	public float  getAtkSpeed(){  
		return atkSpeed; 
	}

	/// <summary>
	 /// 暴击
	 /// </summary>
	public void setCritical(float critical){
		this.critical=critical;
	}

	/// <summary>
	 ///暴击
	 /// </summary>
	public float  getCritical(){  
		return critical; 
	}

	/// <summary>
	 /// 实际暴击率
	 /// </summary>
	public void setCriticalRate(float criticalRate){
		this.criticalRate=criticalRate;
	}

	/// <summary>
	 ///实际暴击率
	 /// </summary>
	public float  getCriticalRate(){  
		return criticalRate; 
	}

	/// <summary>
	 /// 防御减免系数
	 /// </summary>
	public void setReductionDf(float reductionDf){
		this.reductionDf=reductionDf;
	}

	/// <summary>
	 ///防御减免系数
	 /// </summary>
	public float  getReductionDf(){  
		return reductionDf; 
	}

	/// <summary>
	 /// 魔法防御减免系数
	 /// </summary>
	public void setReductionMdf(float reductionMdf){
		this.reductionMdf=reductionMdf;
	}

	/// <summary>
	 ///魔法防御减免系数
	 /// </summary>
	public float  getReductionMdf(){  
		return reductionMdf; 
	}

	/// <summary>
	 /// 战斗力
	 /// </summary>
	public void setPower(int power){
		this.power=power;
	}

	/// <summary>
	 ///战斗力
	 /// </summary>
	public int  getPower(){  
		return power; 
	}

	/// <summary>
	 /// 被动技能
	 /// </summary>
	public void setGifts(List<int> gifts){
		this.gifts=gifts;
	}

	/// <summary>
	 ///被动技能
	 /// </summary>
	public List<int> getGifts(){  
		return gifts; 
	}

	public override string ToString() {
		return "petId:" + petId + "," + "cid:" + cid + "," + "level:" + level + "," + "starLv:" + starLv + "," + "ocId:" + ocId + "," + "hpMax:" + hpMax + "," + "atk:" + atk + "," + "mag:" + mag + "," + "df:" + df + "," + "mdf:" + mdf + "," + "range:" + range + "," + "atkSpeed:" + atkSpeed + "," + "critical:" + critical + "," + "criticalRate:" + criticalRate + "," + "reductionDf:" + reductionDf + "," + "reductionMdf:" + reductionMdf + "," + "power:" + power + "," + "gifts size:" + gifts.Count;
	}

}
}