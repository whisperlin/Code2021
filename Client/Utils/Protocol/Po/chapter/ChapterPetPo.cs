using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.chapter{

/// <summary>
 /// 宠物属性
 /// </summary>
public class ChapterPetPo : BasePo{

	public const int cmd = 770913;
	public const string reflectClassName = "com.hbt.protocol.po.chapter.ChapterPetPo";

	public ChapterPetPo():base() {
		commandId = 770913;
		encryptTypeUp = 0;
	}

	public ChapterPetPo(MemoryStream inputStream){
		commandId = 770913;
		encryptTypeUp = 0;
		this.setPetId(PackageUtil.DecodeInteger(inputStream));
		this.setCharacterId(PackageUtil.DecodeInteger(inputStream));
		this.setHp(PackageUtil.DecodeInteger(inputStream));
		this.setMaxHp(PackageUtil.DecodeInteger(inputStream));
		this.setStatus(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getPetId());
		PackageUtil.EncodeInteger(outputStream, getCharacterId());
		PackageUtil.EncodeInteger(outputStream, getHp());
		PackageUtil.EncodeInteger(outputStream, getMaxHp());
		PackageUtil.EncodeInteger(outputStream, getStatus());
	}

	/// <summary>
	 /// 宠物ID（对应玩家）
	 /// </summary>
	private int petId; 

	/// <summary>
	 /// 角色ID
	 /// </summary>
	private int characterId; 

	/// <summary>
	 /// 当前血量
	 /// </summary>
	private int hp; 

	/// <summary>
	 /// 最大血量
	 /// </summary>
	private int maxHp; 

	/// <summary>
	 /// 角色状态: ChapterConst.PET_STATUS_* 
	 /// </summary>
	private int status; 

	/// <summary>
	 /// 宠物ID（对应玩家）
	 /// </summary>
	public void setPetId(int petId){
		this.petId=petId;
	}

	/// <summary>
	 ///宠物ID（对应玩家）
	 /// </summary>
	public int  getPetId(){  
		return petId; 
	}

	/// <summary>
	 /// 角色ID
	 /// </summary>
	public void setCharacterId(int characterId){
		this.characterId=characterId;
	}

	/// <summary>
	 ///角色ID
	 /// </summary>
	public int  getCharacterId(){  
		return characterId; 
	}

	/// <summary>
	 /// 当前血量
	 /// </summary>
	public void setHp(int hp){
		this.hp=hp;
	}

	/// <summary>
	 ///当前血量
	 /// </summary>
	public int  getHp(){  
		return hp; 
	}

	/// <summary>
	 /// 最大血量
	 /// </summary>
	public void setMaxHp(int maxHp){
		this.maxHp=maxHp;
	}

	/// <summary>
	 ///最大血量
	 /// </summary>
	public int  getMaxHp(){  
		return maxHp; 
	}

	/// <summary>
	 /// 角色状态: ChapterConst.PET_STATUS_* 
	 /// </summary>
	public void setStatus(int status){
		this.status=status;
	}

	/// <summary>
	 ///角色状态: ChapterConst.PET_STATUS_* 
	 /// </summary>
	public int  getStatus(){  
		return status; 
	}

	public override string ToString() {
		return "petId:" + petId + "," + "characterId:" + characterId + "," + "hp:" + hp + "," + "maxHp:" + maxHp + "," + "status:" + status;
	}

}
}