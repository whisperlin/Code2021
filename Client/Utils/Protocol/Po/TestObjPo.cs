using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po{

/// <summary>
 /// 测试对象
 /// </summary>
public class TestObjPo : BasePo{

	public const int cmd = 998;
	public const string reflectClassName = "com.hbt.protocol.po.TestObjPo";

	public TestObjPo():base() {
		commandId = 998;
		encryptTypeUp = 0;
	}

	public TestObjPo(MemoryStream inputStream){
		commandId = 998;
		encryptTypeUp = 0;
		this.setEchoStr(PackageUtil.DecodeString(inputStream));
		this.setEchoInt(PackageUtil.DecodeInteger(inputStream));
		this.setEchoFloat(PackageUtil.DecodeFloat(inputStream));
		this.setEchoBoolean(PackageUtil.DecodeBoolean(inputStream));
		this.setEchoByte(PackageUtil.DecodeByte(inputStream));
		this.setEchoShort(PackageUtil.DecodeShort(inputStream));
		this.setEchoLong(PackageUtil.DecodeLong(inputStream));
		this.setEchoDouble(PackageUtil.DecodeDouble(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeString(outputStream, getEchoStr());
		PackageUtil.EncodeInteger(outputStream, getEchoInt());
		PackageUtil.EncodeFloat(outputStream, getEchoFloat());
		PackageUtil.EncodeBoolean(outputStream, getEchoBoolean());
		PackageUtil.EncodeByte(outputStream, getEchoByte());
		PackageUtil.EncodeShort(outputStream, getEchoShort());
		PackageUtil.EncodeLong(outputStream, getEchoLong());
		PackageUtil.EncodeDouble(outputStream, getEchoDouble());
	}

	/// <summary>
	 /// 测试字符串
	 /// </summary>
	private string echoStr; 

	/// <summary>
	 /// 测试数字
	 /// </summary>
	private int echoInt; 

	/// <summary>
	 /// 测试单精度浮点
	 /// </summary>
	private float echoFloat; 

	/// <summary>
	 /// 测试布尔值
	 /// </summary>
	private bool echoBoolean; 

	/// <summary>
	 /// 测试字节
	 /// </summary>
	private byte echoByte; 

	/// <summary>
	 /// 测试短整型
	 /// </summary>
	private short echoShort; 

	/// <summary>
	 /// 测试长整型
	 /// </summary>
	private ulong echoLong; 

	/// <summary>
	 /// 测试双精度浮点
	 /// </summary>
	private double echoDouble; 

	/// <summary>
	 /// 测试字符串
	 /// </summary>
	public void setEchoStr(string echoStr){
		this.echoStr=echoStr;
	}

	/// <summary>
	 ///测试字符串
	 /// </summary>
	public string  getEchoStr(){  
		return echoStr; 
	}

	/// <summary>
	 /// 测试数字
	 /// </summary>
	public void setEchoInt(int echoInt){
		this.echoInt=echoInt;
	}

	/// <summary>
	 ///测试数字
	 /// </summary>
	public int  getEchoInt(){  
		return echoInt; 
	}

	/// <summary>
	 /// 测试单精度浮点
	 /// </summary>
	public void setEchoFloat(float echoFloat){
		this.echoFloat=echoFloat;
	}

	/// <summary>
	 ///测试单精度浮点
	 /// </summary>
	public float  getEchoFloat(){  
		return echoFloat; 
	}

	/// <summary>
	 /// 测试布尔值
	 /// </summary>
	public void setEchoBoolean(bool echoBoolean){
		this.echoBoolean=echoBoolean;
	}

	/// <summary>
	 ///测试布尔值
	 /// </summary>
	public bool  getEchoBoolean(){  
		return echoBoolean; 
	}

	/// <summary>
	 /// 测试字节
	 /// </summary>
	public void setEchoByte(byte echoByte){
		this.echoByte=echoByte;
	}

	/// <summary>
	 ///测试字节
	 /// </summary>
	public byte  getEchoByte(){  
		return echoByte; 
	}

	/// <summary>
	 /// 测试短整型
	 /// </summary>
	public void setEchoShort(short echoShort){
		this.echoShort=echoShort;
	}

	/// <summary>
	 ///测试短整型
	 /// </summary>
	public short  getEchoShort(){  
		return echoShort; 
	}

	/// <summary>
	 /// 测试长整型
	 /// </summary>
	public void setEchoLong(ulong echoLong){
		this.echoLong=echoLong;
	}

	/// <summary>
	 ///测试长整型
	 /// </summary>
	public ulong  getEchoLong(){  
		return echoLong; 
	}

	/// <summary>
	 /// 测试双精度浮点
	 /// </summary>
	public void setEchoDouble(double echoDouble){
		this.echoDouble=echoDouble;
	}

	/// <summary>
	 ///测试双精度浮点
	 /// </summary>
	public double  getEchoDouble(){  
		return echoDouble; 
	}

	public override string ToString() {
		return "echoStr:" + echoStr + "," + "echoInt:" + echoInt + "," + "echoFloat:" + echoFloat + "," + "echoBoolean:" + echoBoolean + "," + "echoByte:" + echoByte + "," + "echoShort:" + echoShort + "," + "echoLong:" + echoLong + "," + "echoDouble:" + echoDouble;
	}

}
}