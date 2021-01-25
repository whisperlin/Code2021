using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.player{

/// <summary>
 /// 登录
 /// </summary>
public class LoginPo_Rp  : BasePo{

	public const int cmd = -181072;
	public const string reflectClassName = "com.hbt.protocol.po.player.LoginPo_Rp";

	public LoginPo_Rp():base() {
		commandId = -181072;
		encryptTypeDown = 0;
	}

	public LoginPo_Rp(MemoryStream inputStream){
		commandId = -181072;
		encryptTypeDown = 0;
		this.setId(PackageUtil.DecodeLong(inputStream));
		this.setShortId(PackageUtil.DecodeInteger(inputStream));
		this.setNick(PackageUtil.DecodeString(inputStream));
		this.setStatus(PackageUtil.DecodeInteger(inputStream));
		this.setUnfreezeTime(PackageUtil.DecodeString(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeLong(outputStream, getId());
		PackageUtil.EncodeInteger(outputStream, getShortId());
		PackageUtil.EncodeString(outputStream, getNick());
		PackageUtil.EncodeInteger(outputStream, getStatus());
		PackageUtil.EncodeString(outputStream, getUnfreezeTime());
	}

	/// <summary>
	 ///长ID
	 /// </summary>
	private ulong id; 

	/// <summary>
	 ///短ID
	 /// </summary>
	private int shortId; 

	/// <summary>
	 ///昵称
	 /// </summary>
	private string nick; 

	/// <summary>
	 ///用户状态
	 /// </summary>
	private int status; 

	/// <summary>
	 ///解封时间
	 /// </summary>
	private string unfreezeTime; 

	/// <summary>
	 ///长ID
	 /// </summary>
	public void setId(ulong id){
		this.id=id;
	}

	/// <summary>
	 ///长ID
	 /// </summary>
	public ulong  getId(){  
		return id; 
	}

	/// <summary>
	 ///短ID
	 /// </summary>
	public void setShortId(int shortId){
		this.shortId=shortId;
	}

	/// <summary>
	 ///短ID
	 /// </summary>
	public int  getShortId(){  
		return shortId; 
	}

	/// <summary>
	 ///昵称
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

	/// <summary>
	 ///用户状态
	 /// </summary>
	public void setStatus(int status){
		this.status=status;
	}

	/// <summary>
	 ///用户状态
	 /// </summary>
	public int  getStatus(){  
		return status; 
	}

	/// <summary>
	 ///解封时间
	 /// </summary>
	public void setUnfreezeTime(string unfreezeTime){
		this.unfreezeTime=unfreezeTime;
	}

	/// <summary>
	 ///解封时间
	 /// </summary>
	public string  getUnfreezeTime(){  
		return unfreezeTime; 
	}

	public override string ToString() {
		return "id:" + id + "," + "shortId:" + shortId + "," + "nick:" + nick + "," + "status:" + status + "," + "unfreezeTime:" + unfreezeTime;
	}

}
}