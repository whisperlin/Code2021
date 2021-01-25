using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.battle{

/// <summary>
 /// 动作脚本帧
 /// </summary>
public class MotionPo : BasePo{

	public const int cmd = 705363;
	public const string reflectClassName = "com.hbt.protocol.po.battle.MotionPo";

	public MotionPo():base() {
		commandId = 705363;
		encryptTypeUp = 0;
	}

	public MotionPo(MemoryStream inputStream){
		commandId = 705363;
		encryptTypeUp = 0;
		this.setType(PackageUtil.DecodeShort(inputStream));
		this.setBeginTime(PackageUtil.DecodeShort(inputStream));
		this.setEndTime(PackageUtil.DecodeShort(inputStream));
		this.setP1(PackageUtil.DecodeShort(inputStream));
		this.setP2(PackageUtil.DecodeShort(inputStream));
		this.setP3(PackageUtil.DecodeShort(inputStream));
		this.setP4(PackageUtil.DecodeShort(inputStream));
		this.setI1(PackageUtil.DecodeInteger(inputStream));
		this.setS1(PackageUtil.DecodeString(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeShort(outputStream, getType());
		PackageUtil.EncodeShort(outputStream, getBeginTime());
		PackageUtil.EncodeShort(outputStream, getEndTime());
		PackageUtil.EncodeShort(outputStream, getP1());
		PackageUtil.EncodeShort(outputStream, getP2());
		PackageUtil.EncodeShort(outputStream, getP3());
		PackageUtil.EncodeShort(outputStream, getP4());
		PackageUtil.EncodeInteger(outputStream, getI1());
		PackageUtil.EncodeString(outputStream, getS1());
	}

	/// <summary>
	 /// 动作脚本类型 BattleConst.MC_*
	 /// </summary>
	private short type; 

	/// <summary>
	 /// 开始帧
	 /// </summary>
	private short beginTime; 

	/// <summary>
	 /// 播放时长
	 /// </summary>
	private short endTime; 

	/// <summary>
	 /// 短整数参数1
	 /// </summary>
	private short p1; 

	/// <summary>
	 /// 短整数参数2
	 /// </summary>
	private short p2; 

	/// <summary>
	 /// 短整数参数3
	 /// </summary>
	private short p3; 

	/// <summary>
	 /// 短整数参数4
	 /// </summary>
	private short p4; 

	/// <summary>
	 /// 整数参数1
	 /// </summary>
	private int i1; 

	/// <summary>
	 /// 字符串参数1
	 /// </summary>
	private string s1; 

	/// <summary>
	 /// 动作脚本类型 BattleConst.MC_*
	 /// </summary>
	public void setType(short type){
		this.type=type;
	}

	/// <summary>
	 ///动作脚本类型 BattleConst.MC_*
	 /// </summary>
	public short  getType(){  
		return type; 
	}

	/// <summary>
	 /// 开始帧
	 /// </summary>
	public void setBeginTime(short beginTime){
		this.beginTime=beginTime;
	}

	/// <summary>
	 ///开始帧
	 /// </summary>
	public short  getBeginTime(){  
		return beginTime; 
	}

	/// <summary>
	 /// 播放时长
	 /// </summary>
	public void setEndTime(short endTime){
		this.endTime=endTime;
	}

	/// <summary>
	 ///播放时长
	 /// </summary>
	public short  getEndTime(){  
		return endTime; 
	}

	/// <summary>
	 /// 短整数参数1
	 /// </summary>
	public void setP1(short p1){
		this.p1=p1;
	}

	/// <summary>
	 ///短整数参数1
	 /// </summary>
	public short  getP1(){  
		return p1; 
	}

	/// <summary>
	 /// 短整数参数2
	 /// </summary>
	public void setP2(short p2){
		this.p2=p2;
	}

	/// <summary>
	 ///短整数参数2
	 /// </summary>
	public short  getP2(){  
		return p2; 
	}

	/// <summary>
	 /// 短整数参数3
	 /// </summary>
	public void setP3(short p3){
		this.p3=p3;
	}

	/// <summary>
	 ///短整数参数3
	 /// </summary>
	public short  getP3(){  
		return p3; 
	}

	/// <summary>
	 /// 短整数参数4
	 /// </summary>
	public void setP4(short p4){
		this.p4=p4;
	}

	/// <summary>
	 ///短整数参数4
	 /// </summary>
	public short  getP4(){  
		return p4; 
	}

	/// <summary>
	 /// 整数参数1
	 /// </summary>
	public void setI1(int i1){
		this.i1=i1;
	}

	/// <summary>
	 ///整数参数1
	 /// </summary>
	public int  getI1(){  
		return i1; 
	}

	/// <summary>
	 /// 字符串参数1
	 /// </summary>
	public void setS1(string s1){
		this.s1=s1;
	}

	/// <summary>
	 ///字符串参数1
	 /// </summary>
	public string  getS1(){  
		return s1; 
	}

	public override string ToString() {
		return "type:" + type + "," + "beginTime:" + beginTime + "," + "endTime:" + endTime + "," + "p1:" + p1 + "," + "p2:" + p2 + "," + "p3:" + p3 + "," + "p4:" + p4 + "," + "i1:" + i1 + "," + "s1:" + s1;
	}

}
}