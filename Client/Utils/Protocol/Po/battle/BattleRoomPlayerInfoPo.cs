using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.battle{

/// <summary>
 /// 广播进入战斗房间的玩家信息
 /// </summary>
public class BattleRoomPlayerInfoPo : BasePo{

	public const int cmd = 705361;
	public const string reflectClassName = "com.hbt.protocol.po.battle.BattleRoomPlayerInfoPo";

	public BattleRoomPlayerInfoPo():base() {
		commandId = 705361;
		encryptTypeUp = 0;
	}

	public BattleRoomPlayerInfoPo(MemoryStream inputStream){
		commandId = 705361;
		encryptTypeUp = 0;
		this.setSeatId(PackageUtil.DecodeShort(inputStream));
		this.setCharacterId(PackageUtil.DecodeInteger(inputStream));
		this.setStand(PackageUtil.DecodeInteger(inputStream));
		this.setSkillId(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeShort(outputStream, getSeatId());
		PackageUtil.EncodeInteger(outputStream, getCharacterId());
		PackageUtil.EncodeInteger(outputStream, getStand());
		PackageUtil.EncodeInteger(outputStream, getSkillId());
	}

	/// <summary>
	 /// 座位id
	 /// </summary>
	private short seatId; 

	/// <summary>
	 /// 角色id
	 /// </summary>
	private int characterId; 

	/// <summary>
	 /// 角色立场
	 /// </summary>
	private int stand; 

	/// <summary>
	 /// 角色技能ID
	 /// </summary>
	private int skillId; 

	/// <summary>
	 /// 座位id
	 /// </summary>
	public void setSeatId(short seatId){
		this.seatId=seatId;
	}

	/// <summary>
	 ///座位id
	 /// </summary>
	public short  getSeatId(){  
		return seatId; 
	}

	/// <summary>
	 /// 角色id
	 /// </summary>
	public void setCharacterId(int characterId){
		this.characterId=characterId;
	}

	/// <summary>
	 ///角色id
	 /// </summary>
	public int  getCharacterId(){  
		return characterId; 
	}

	/// <summary>
	 /// 角色立场
	 /// </summary>
	public void setStand(int stand){
		this.stand=stand;
	}

	/// <summary>
	 ///角色立场
	 /// </summary>
	public int  getStand(){  
		return stand; 
	}

	/// <summary>
	 /// 角色技能ID
	 /// </summary>
	public void setSkillId(int skillId){
		this.skillId=skillId;
	}

	/// <summary>
	 ///角色技能ID
	 /// </summary>
	public int  getSkillId(){  
		return skillId; 
	}

	public override string ToString() {
		return "seatId:" + seatId + "," + "characterId:" + characterId + "," + "stand:" + stand + "," + "skillId:" + skillId;
	}

}
}