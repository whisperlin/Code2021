using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.battle{

/// <summary>
 /// 进入战斗房间
 /// </summary>
public class EnterBattlePo : BasePo{

	public const int cmd = 705360;
	public const string reflectClassName = "com.hbt.protocol.po.battle.EnterBattlePo";

	public EnterBattlePo():base() {
		commandId = 705360;
		encryptTypeUp = 0;
	}

	public EnterBattlePo(MemoryStream inputStream){
		commandId = 705360;
		encryptTypeUp = 0;
		this.setTeamId(PackageUtil.DecodeInteger(inputStream));
		this.setBattleId(PackageUtil.DecodeString(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getTeamId());
		PackageUtil.EncodeString(outputStream, getBattleId());
	}

	/// <summary>
	 /// 队伍id
	 /// </summary>
	private int teamId; 

	/// <summary>
	 /// 战斗id
	 /// </summary>
	private string battleId; 

	/// <summary>
	 /// 队伍id
	 /// </summary>
	public void setTeamId(int teamId){
		this.teamId=teamId;
	}

	/// <summary>
	 ///队伍id
	 /// </summary>
	public int  getTeamId(){  
		return teamId; 
	}

	/// <summary>
	 /// 战斗id
	 /// </summary>
	public void setBattleId(string battleId){
		this.battleId=battleId;
	}

	/// <summary>
	 ///战斗id
	 /// </summary>
	public string  getBattleId(){  
		return battleId; 
	}

	public override string ToString() {
		return "teamId:" + teamId + "," + "battleId:" + battleId;
	}

}
}