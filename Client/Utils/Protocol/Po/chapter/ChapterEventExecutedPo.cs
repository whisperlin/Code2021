using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.chapter{

/// <summary>
 /// 关卡事件执行结果
 /// </summary>
public class ChapterEventExecutedPo : BasePo{

	public const int cmd = 770907;
	public const string reflectClassName = "com.hbt.protocol.po.chapter.ChapterEventExecutedPo";

	public ChapterEventExecutedPo():base() {
		commandId = 770907;
		encryptTypeUp = 0;
	}

	public ChapterEventExecutedPo(MemoryStream inputStream){
		commandId = 770907;
		encryptTypeUp = 0;
		this.setKey(PackageUtil.DecodeString(inputStream));
		this.setValue(PackageUtil.DecodeString(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeString(outputStream, getKey());
		PackageUtil.EncodeString(outputStream, getValue());
	}

	/// <summary>
	 /// 键
	 /// </summary>
	private string key; 

	/// <summary>
	 /// 值
	 /// </summary>
	private string value; 

	/// <summary>
	 /// 键
	 /// </summary>
	public void setKey(string key){
		this.key=key;
	}

	/// <summary>
	 ///键
	 /// </summary>
	public string  getKey(){  
		return key; 
	}

	/// <summary>
	 /// 值
	 /// </summary>
	public void setValue(string value){
		this.value=value;
	}

	/// <summary>
	 ///值
	 /// </summary>
	public string  getValue(){  
		return value; 
	}

	public override string ToString() {
		return "key:" + key + "," + "value:" + value;
	}

}
}