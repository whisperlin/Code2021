using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.player{

/// <summary>
 /// 改名
 /// </summary>
public class RenamePo : BasePo{

	public const int cmd = 181073;
	public const string reflectClassName = "com.hbt.protocol.po.player.RenamePo";

	public RenamePo():base() {
		commandId = 181073;
		encryptTypeUp = 0;
	}

	public RenamePo(MemoryStream inputStream){
		commandId = 181073;
		encryptTypeUp = 0;
		this.setNick(PackageUtil.DecodeString(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeString(outputStream, getNick());
	}

	/// <summary>
	 /// 昵称
	 /// </summary>
	private string nick; 

	/// <summary>
	 /// 昵称
	 /// </summary>
	public void setNick(string nick){
		this.nick=nick;
	}

	/// <summary>
	 ///昵称
	 /// </summary>
	public string  getNick(){  
		return nick; 
	}

	public override string ToString() {
		return "nick:" + nick;
	}

}
}