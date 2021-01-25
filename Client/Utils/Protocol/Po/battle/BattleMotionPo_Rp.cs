using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.battle{

/// <summary>
 /// 获取战斗动画序列
 /// </summary>
public class BattleMotionPo_Rp  : BasePo{

	public const int cmd = -705362;
	public const string reflectClassName = "com.hbt.protocol.po.battle.BattleMotionPo_Rp";

	public BattleMotionPo_Rp():base() {
		commandId = -705362;
		encryptTypeDown = 0;
	}

	public BattleMotionPo_Rp(MemoryStream inputStream){
		commandId = -705362;
		encryptTypeDown = 0;
		this.setPlayId(PackageUtil.DecodeString(inputStream));
		this.setStartOrder(PackageUtil.DecodeInteger(inputStream));
		this.setCount(PackageUtil.DecodeInteger(inputStream));
		this.setRemainCount(PackageUtil.DecodeInteger(inputStream));

		short length0 = PackageUtil.DecodeShort(inputStream);//集合长度
		List<com.hbt.protocol.po.battle.MotionPo> motions = new List<com.hbt.protocol.po.battle.MotionPo>();
		for(int i = 0; i < length0; i++){
			PackageUtil.skipInputStream(inputStream, 4);//读4位
			motions.Add(new com.hbt.protocol.po.battle.MotionPo(inputStream));
		}
		this.setMotions(motions);
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeString(outputStream, getPlayId());
		PackageUtil.EncodeInteger(outputStream, getStartOrder());
		PackageUtil.EncodeInteger(outputStream, getCount());
		PackageUtil.EncodeInteger(outputStream, getRemainCount());

		List<com.hbt.protocol.po.battle.MotionPo> motions = getMotions();
		short motionslength = (short)(motions == null ? 0 : motions.Count);
		PackageUtil.EncodeShort(outputStream, motionslength);
		for(int i = 0; i < motionslength; i++){
			motions[i].encodeVo(outputStream);
		}
	}

	/// <summary>
	 ///战斗id
	 /// </summary>
	private string playId; 

	/// <summary>
	 ///起始Motion位置
	 /// </summary>
	private int startOrder; 

	/// <summary>
	 ///返回了多少个Motion(根据具体位置算)
	 /// </summary>
	private int count; 

	/// <summary>
	 ///还剩余多少个Motion未获取
	 /// </summary>
	private int remainCount; 

	/// <summary>
	 ///动作脚本序列
	 /// </summary>
	private List<com.hbt.protocol.po.battle.MotionPo> motions; 

	/// <summary>
	 ///战斗id
	 /// </summary>
	public void setPlayId(string playId){
		this.playId=playId;
	}

	/// <summary>
	 ///战斗id
	 /// </summary>
	public string  getPlayId(){  
		return playId; 
	}

	/// <summary>
	 ///起始Motion位置
	 /// </summary>
	public void setStartOrder(int startOrder){
		this.startOrder=startOrder;
	}

	/// <summary>
	 ///起始Motion位置
	 /// </summary>
	public int  getStartOrder(){  
		return startOrder; 
	}

	/// <summary>
	 ///返回了多少个Motion(根据具体位置算)
	 /// </summary>
	public void setCount(int count){
		this.count=count;
	}

	/// <summary>
	 ///返回了多少个Motion(根据具体位置算)
	 /// </summary>
	public int  getCount(){  
		return count; 
	}

	/// <summary>
	 ///还剩余多少个Motion未获取
	 /// </summary>
	public void setRemainCount(int remainCount){
		this.remainCount=remainCount;
	}

	/// <summary>
	 ///还剩余多少个Motion未获取
	 /// </summary>
	public int  getRemainCount(){  
		return remainCount; 
	}

	/// <summary>
	 ///动作脚本序列
	 /// </summary>
	public void setMotions(List<com.hbt.protocol.po.battle.MotionPo> motions){
		this.motions=motions;
	}

	/// <summary>
	 ///动作脚本序列
	 /// </summary>
	public List<com.hbt.protocol.po.battle.MotionPo> getMotions(){  
		return motions; 
	}

	public override string ToString() {
		return "playId:" + playId + "," + "startOrder:" + startOrder + "," + "count:" + count + "," + "remainCount:" + remainCount + "," + "motions size:" + motions.Count;
	}

}
}