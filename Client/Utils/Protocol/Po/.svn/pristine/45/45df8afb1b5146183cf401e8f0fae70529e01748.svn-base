using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.battle{

/// <summary>
 /// 广播motion
 /// </summary>
public class BroadcastMotionPo : BasePo{

	public const int cmd = 705365;
	public const string reflectClassName = "com.hbt.protocol.po.battle.BroadcastMotionPo";

	public BroadcastMotionPo():base() {
		commandId = 705365;
		encryptTypeUp = 0;
	}

	public BroadcastMotionPo(MemoryStream inputStream){
		commandId = 705365;
		encryptTypeUp = 0;

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

		List<com.hbt.protocol.po.battle.MotionPo> motions = getMotions();
		short motionslength = (short)(motions == null ? 0 : motions.Count);
		PackageUtil.EncodeShort(outputStream, motionslength);
		for(int i = 0; i < motionslength; i++){
			motions[i].encodeVo(outputStream);
		}
	}

	/// <summary>
	 /// motion列表
	 /// </summary>
	private List<com.hbt.protocol.po.battle.MotionPo> motions; 

	/// <summary>
	 /// motion列表
	 /// </summary>
	public void setMotions(List<com.hbt.protocol.po.battle.MotionPo> motions){
		this.motions=motions;
	}

	/// <summary>
	 ///motion列表
	 /// </summary>
	public List<com.hbt.protocol.po.battle.MotionPo> getMotions(){  
		return motions; 
	}

	public override string ToString() {
		return "motions size:" + motions.Count;
	}

}
}