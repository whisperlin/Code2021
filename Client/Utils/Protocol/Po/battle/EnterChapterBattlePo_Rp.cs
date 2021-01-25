using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.battle{

/// <summary>
 /// 进入冒险关卡战斗房间
 /// </summary>
public class EnterChapterBattlePo_Rp  : BasePo{

	public const int cmd = -705364;
	public const string reflectClassName = "com.hbt.protocol.po.battle.EnterChapterBattlePo_Rp";

	public EnterChapterBattlePo_Rp():base() {
		commandId = -705364;
		encryptTypeDown = 0;
	}

	public EnterChapterBattlePo_Rp(MemoryStream inputStream){
		commandId = -705364;
		encryptTypeDown = 0;
		this.setMapSettingId(PackageUtil.DecodeInteger(inputStream));
		this.setResult(PackageUtil.DecodeInteger(inputStream));
		this.setMotionsCount(PackageUtil.DecodeInteger(inputStream));
		this.setPlayId(PackageUtil.DecodeString(inputStream));
		this.setDiscription(PackageUtil.DecodeString(inputStream));

		short length0 = PackageUtil.DecodeShort(inputStream);//集合长度
		List<com.hbt.protocol.po.battle.BattleRoomPlayerInfoPo> battleRoomPlayerList = new List<com.hbt.protocol.po.battle.BattleRoomPlayerInfoPo>();
		for(int i = 0; i < length0; i++){
			PackageUtil.skipInputStream(inputStream, 4);//读4位
			battleRoomPlayerList.Add(new com.hbt.protocol.po.battle.BattleRoomPlayerInfoPo(inputStream));
		}
		this.setBattleRoomPlayerList(battleRoomPlayerList);

		short length1 = PackageUtil.DecodeShort(inputStream);//集合长度
		List<com.hbt.protocol.po.chapter.ChapterEventPo> chapterEvent = new List<com.hbt.protocol.po.chapter.ChapterEventPo>();
		for(int i = 0; i < length1; i++){
			PackageUtil.skipInputStream(inputStream, 4);//读4位
			chapterEvent.Add(new com.hbt.protocol.po.chapter.ChapterEventPo(inputStream));
		}
		this.setChapterEvent(chapterEvent);
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getMapSettingId());
		PackageUtil.EncodeInteger(outputStream, getResult());
		PackageUtil.EncodeInteger(outputStream, getMotionsCount());
		PackageUtil.EncodeString(outputStream, getPlayId());
		PackageUtil.EncodeString(outputStream, getDiscription());

		List<com.hbt.protocol.po.battle.BattleRoomPlayerInfoPo> battleRoomPlayerList = getBattleRoomPlayerList();
		short battleRoomPlayerListlength = (short)(battleRoomPlayerList == null ? 0 : battleRoomPlayerList.Count);
		PackageUtil.EncodeShort(outputStream, battleRoomPlayerListlength);
		for(int i = 0; i < battleRoomPlayerListlength; i++){
			battleRoomPlayerList[i].encodeVo(outputStream);
		}

		List<com.hbt.protocol.po.chapter.ChapterEventPo> chapterEvent = getChapterEvent();
		short chapterEventlength = (short)(chapterEvent == null ? 0 : chapterEvent.Count);
		PackageUtil.EncodeShort(outputStream, chapterEventlength);
		for(int i = 0; i < chapterEventlength; i++){
			chapterEvent[i].encodeVo(outputStream);
		}
	}

	/// <summary>
	 ///关卡对应事件ID
	 /// </summary>
	private int mapSettingId; 

	/// <summary>
	 ///战斗结果:0.平局 1.红方胜利 2.蓝方胜利 -1.还没分出胜负
	 /// </summary>
	private int result; 

	/// <summary>
	 ///有多少动作脚本
	 /// </summary>
	private int motionsCount; 

	/// <summary>
	 ///录像ID
	 /// </summary>
	private string playId; 

	/// <summary>
	 ///返回值消息
	 /// </summary>
	private string discription; 

	/// <summary>
	 ///战斗房间玩家信息
	 /// </summary>
	private List<com.hbt.protocol.po.battle.BattleRoomPlayerInfoPo> battleRoomPlayerList; 

	/// <summary>
	 ///关卡事件触发列表
	 /// </summary>
	private List<com.hbt.protocol.po.chapter.ChapterEventPo> chapterEvent; 

	/// <summary>
	 ///关卡对应事件ID
	 /// </summary>
	public void setMapSettingId(int mapSettingId){
		this.mapSettingId=mapSettingId;
	}

	/// <summary>
	 ///关卡对应事件ID
	 /// </summary>
	public int  getMapSettingId(){  
		return mapSettingId; 
	}

	/// <summary>
	 ///战斗结果:0.平局 1.红方胜利 2.蓝方胜利 -1.还没分出胜负
	 /// </summary>
	public void setResult(int result){
		this.result=result;
	}

	/// <summary>
	 ///战斗结果:0.平局 1.红方胜利 2.蓝方胜利 -1.还没分出胜负
	 /// </summary>
	public int  getResult(){  
		return result; 
	}

	/// <summary>
	 ///有多少动作脚本
	 /// </summary>
	public void setMotionsCount(int motionsCount){
		this.motionsCount=motionsCount;
	}

	/// <summary>
	 ///有多少动作脚本
	 /// </summary>
	public int  getMotionsCount(){  
		return motionsCount; 
	}

	/// <summary>
	 ///录像ID
	 /// </summary>
	public void setPlayId(string playId){
		this.playId=playId;
	}

	/// <summary>
	 ///录像ID
	 /// </summary>
	public string  getPlayId(){  
		return playId; 
	}

	/// <summary>
	 ///返回值消息
	 /// </summary>
	public void setDiscription(string discription){
		this.discription=discription;
	}

	/// <summary>
	 ///返回值消息
	 /// </summary>
	public string  getDiscription(){  
		return discription; 
	}

	/// <summary>
	 ///战斗房间玩家信息
	 /// </summary>
	public void setBattleRoomPlayerList(List<com.hbt.protocol.po.battle.BattleRoomPlayerInfoPo> battleRoomPlayerList){
		this.battleRoomPlayerList=battleRoomPlayerList;
	}

	/// <summary>
	 ///战斗房间玩家信息
	 /// </summary>
	public List<com.hbt.protocol.po.battle.BattleRoomPlayerInfoPo> getBattleRoomPlayerList(){  
		return battleRoomPlayerList; 
	}

	/// <summary>
	 ///关卡事件触发列表
	 /// </summary>
	public void setChapterEvent(List<com.hbt.protocol.po.chapter.ChapterEventPo> chapterEvent){
		this.chapterEvent=chapterEvent;
	}

	/// <summary>
	 ///关卡事件触发列表
	 /// </summary>
	public List<com.hbt.protocol.po.chapter.ChapterEventPo> getChapterEvent(){  
		return chapterEvent; 
	}

	public override string ToString() {
		return "mapSettingId:" + mapSettingId + "," + "result:" + result + "," + "motionsCount:" + motionsCount + "," + "playId:" + playId + "," + "discription:" + discription + "," + "battleRoomPlayerList size:" + battleRoomPlayerList.Count + "," + "chapterEvent size:" + chapterEvent.Count;
	}

}
}