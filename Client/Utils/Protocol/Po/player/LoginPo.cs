using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.player{

/// <summary>
 /// 登录
 /// </summary>
public class LoginPo : BasePo{

	public const int cmd = 181072;
	public const string reflectClassName = "com.hbt.protocol.po.player.LoginPo";

	public LoginPo():base() {
		commandId = 181072;
		encryptTypeUp = 0;
	}

	public LoginPo(MemoryStream inputStream){
		commandId = 181072;
		encryptTypeUp = 0;
		this.setUsername(PackageUtil.DecodeString(inputStream));
		this.setPassword(PackageUtil.DecodeString(inputStream));
		this.setOs(PackageUtil.DecodeString(inputStream));
		this.setPhonemodel(PackageUtil.DecodeString(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeString(outputStream, getUsername());
		PackageUtil.EncodeString(outputStream, getPassword());
		PackageUtil.EncodeString(outputStream, getOs());
		PackageUtil.EncodeString(outputStream, getPhonemodel());
	}

	/// <summary>
	 /// 账号
	 /// </summary>
	private string username; 

	/// <summary>
	 /// 密码
	 /// </summary>
	private string password; 

	/// <summary>
	 /// 系统
	 /// </summary>
	private string os; 

	/// <summary>
	 /// 手机型号
	 /// </summary>
	private string phonemodel; 

	/// <summary>
	 /// 账号
	 /// </summary>
	public void setUsername(string username){
		this.username=username;
	}

	/// <summary>
	 ///账号
	 /// </summary>
	public string  getUsername(){  
		return username; 
	}

	/// <summary>
	 /// 密码
	 /// </summary>
	public void setPassword(string password){
		this.password=password;
	}

	/// <summary>
	 ///密码
	 /// </summary>
	public string  getPassword(){  
		return password; 
	}

	/// <summary>
	 /// 系统
	 /// </summary>
	public void setOs(string os){
		this.os=os;
	}

	/// <summary>
	 ///系统
	 /// </summary>
	public string  getOs(){  
		return os; 
	}

	/// <summary>
	 /// 手机型号
	 /// </summary>
	public void setPhonemodel(string phonemodel){
		this.phonemodel=phonemodel;
	}

	/// <summary>
	 ///手机型号
	 /// </summary>
	public string  getPhonemodel(){  
		return phonemodel; 
	}

	public override string ToString() {
		return "username:" + username + "," + "password:" + password + "," + "os:" + os + "," + "phonemodel:" + phonemodel;
	}

}
}