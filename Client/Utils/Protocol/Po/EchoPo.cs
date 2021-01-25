using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po{

/// <summary>
 /// Echo测试包
 /// </summary>
public class EchoPo : BasePo{

	public const int cmd = 1;
	public const string reflectClassName = "com.hbt.protocol.po.EchoPo";

	public EchoPo():base() {
		commandId = 1;
		encryptTypeUp = 0;
	}

	public EchoPo(MemoryStream inputStream){
		commandId = 1;
		encryptTypeUp = 0;
		this.setEchoStr(PackageUtil.DecodeString(inputStream));
		this.setEchoInt(PackageUtil.DecodeInteger(inputStream));
		this.setEchoFloat(PackageUtil.DecodeFloat(inputStream));
		this.setEchoBoolean(PackageUtil.DecodeBoolean(inputStream));
		this.setEchoByte(PackageUtil.DecodeByte(inputStream));
		this.setEchoShort(PackageUtil.DecodeShort(inputStream));
		this.setEchoLong(PackageUtil.DecodeLong(inputStream));
		this.setEchoDouble(PackageUtil.DecodeDouble(inputStream));

		short length0 = PackageUtil.DecodeShort(inputStream);//集合长度
		List<com.hbt.protocol.po.TestObjPo> echoList = new List<com.hbt.protocol.po.TestObjPo>();
		for(int i = 0; i < length0; i++){
			PackageUtil.skipInputStream(inputStream, 4);//读4位
			echoList.Add(new com.hbt.protocol.po.TestObjPo(inputStream));
		}
		this.setEchoList(echoList);

		short length1 = PackageUtil.DecodeShort(inputStream);//集合长度
		List<int> echoList1 = new List<int>();
		for(int i = 0; i < length1; i++){
			echoList1.Add(PackageUtil.DecodeInteger(inputStream));
		}
		this.setEchoList1(echoList1);

		short length2 = PackageUtil.DecodeShort(inputStream);//集合长度
		List<string> echoList2 = new List<string>();
		for(int i = 0; i < length2; i++){
			echoList2.Add(PackageUtil.DecodeString(inputStream));
		}
		this.setEchoList2(echoList2);
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

		List<com.hbt.protocol.po.TestObjPo> echoList = getEchoList();
		short echoListlength = (short)(echoList == null ? 0 : echoList.Count);
		PackageUtil.EncodeShort(outputStream, echoListlength);
		for(int i = 0; i < echoListlength; i++){
			echoList[i].encodeVo(outputStream);
		}

		List<int> echoList1 = getEchoList1();
		short echoList1length = (short)(echoList1 == null ? 0 : echoList1.Count);
		PackageUtil.EncodeShort(outputStream, echoList1length);
		for(int i = 0; i < echoList1length; i++){
			PackageUtil.EncodeInteger(outputStream, echoList1[i]);
		}

		List<string> echoList2 = getEchoList2();
		short echoList2length = (short)(echoList2 == null ? 0 : echoList2.Count);
		PackageUtil.EncodeShort(outputStream, echoList2length);
		for(int i = 0; i < echoList2length; i++){
			PackageUtil.EncodeString(outputStream, echoList2[i]);
		}
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
	 /// 测试集合整型
	 /// </summary>
	private List<com.hbt.protocol.po.TestObjPo> echoList; 

	/// <summary>
	 /// 
	 /// </summary>
	private List<int> echoList1; 

	/// <summary>
	 /// 
	 /// </summary>
	private List<string> echoList2; 

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

	/// <summary>
	 /// 测试集合整型
	 /// </summary>
	public void setEchoList(List<com.hbt.protocol.po.TestObjPo> echoList){
		this.echoList=echoList;
	}

	/// <summary>
	 ///测试集合整型
	 /// </summary>
	public List<com.hbt.protocol.po.TestObjPo> getEchoList(){  
		return echoList; 
	}

	/// <summary>
	 /// 
	 /// </summary>
	public void setEchoList1(List<int> echoList1){
		this.echoList1=echoList1;
	}

	/// <summary>
	 ///
	 /// </summary>
	public List<int> getEchoList1(){  
		return echoList1; 
	}

	/// <summary>
	 /// 
	 /// </summary>
	public void setEchoList2(List<string> echoList2){
		this.echoList2=echoList2;
	}

	/// <summary>
	 ///
	 /// </summary>
	public List<string> getEchoList2(){  
		return echoList2; 
	}

	public override string ToString() {
		return "echoStr:" + echoStr + "," + "echoInt:" + echoInt + "," + "echoFloat:" + echoFloat + "," + "echoBoolean:" + echoBoolean + "," + "echoByte:" + echoByte + "," + "echoShort:" + echoShort + "," + "echoLong:" + echoLong + "," + "echoDouble:" + echoDouble + "," + "echoList size:" + echoList.Count + "," + "echoList1 size:" + echoList1.Count + "," + "echoList2 size:" + echoList2.Count;
	}

}
}