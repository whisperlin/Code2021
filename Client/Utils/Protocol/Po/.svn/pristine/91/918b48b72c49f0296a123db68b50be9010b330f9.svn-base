using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.town{

/// <summary>
 /// 更换头像
 /// </summary>
public class ChangeAvatarIconPo : BasePo{

	public const int cmd = 246612;
	public const string reflectClassName = "com.hbt.protocol.po.town.ChangeAvatarIconPo";

	public ChangeAvatarIconPo():base() {
		commandId = 246612;
		encryptTypeUp = 0;
	}

	public ChangeAvatarIconPo(MemoryStream inputStream){
		commandId = 246612;
		encryptTypeUp = 0;
		this.setAvatarIcon(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getAvatarIcon());
	}

	/// <summary>
	 /// 头像
	 /// </summary>
	private int avatarIcon; 

	/// <summary>
	 /// 头像
	 /// </summary>
	public void setAvatarIcon(int avatarIcon){
		this.avatarIcon=avatarIcon;
	}

	/// <summary>
	 ///头像
	 /// </summary>
	public int  getAvatarIcon(){  
		return avatarIcon; 
	}

	public override string ToString() {
		return "avatarIcon:" + avatarIcon;
	}

}
}