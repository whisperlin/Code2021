using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.house{

/// <summary>
 /// 调整阵型
 /// </summary>
public class SetFormationPo : BasePo{

	public const int cmd = 312153;
	public const string reflectClassName = "com.hbt.protocol.po.house.SetFormationPo";

	public SetFormationPo():base() {
		commandId = 312153;
		encryptTypeUp = 0;
	}

	public SetFormationPo(MemoryStream inputStream){
		commandId = 312153;
		encryptTypeUp = 0;
		this.setPlanId(PackageUtil.DecodeInteger(inputStream));
		this.setFromRoomId(PackageUtil.DecodeInteger(inputStream));
		this.setFromRow(PackageUtil.DecodeInteger(inputStream));
		this.setFromCol(PackageUtil.DecodeInteger(inputStream));
		this.setToRoomId(PackageUtil.DecodeInteger(inputStream));
		this.setToRow(PackageUtil.DecodeInteger(inputStream));
		this.setToCol(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getPlanId());
		PackageUtil.EncodeInteger(outputStream, getFromRoomId());
		PackageUtil.EncodeInteger(outputStream, getFromRow());
		PackageUtil.EncodeInteger(outputStream, getFromCol());
		PackageUtil.EncodeInteger(outputStream, getToRoomId());
		PackageUtil.EncodeInteger(outputStream, getToRow());
		PackageUtil.EncodeInteger(outputStream, getToCol());
	}

	/// <summary>
	 /// 方案ID(默认1)
	 /// </summary>
	private int planId; 

	/// <summary>
	 /// 房间ID(对应宠物)
	 /// </summary>
	private int fromRoomId; 

	/// <summary>
	 /// 行
	 /// </summary>
	private int fromRow; 

	/// <summary>
	 /// 列
	 /// </summary>
	private int fromCol; 

	/// <summary>
	 /// 房间ID(对应宠物)
	 /// </summary>
	private int toRoomId; 

	/// <summary>
	 /// 行
	 /// </summary>
	private int toRow; 

	/// <summary>
	 /// 列
	 /// </summary>
	private int toCol; 

	/// <summary>
	 /// 方案ID(默认1)
	 /// </summary>
	public void setPlanId(int planId){
		this.planId=planId;
	}

	/// <summary>
	 ///方案ID(默认1)
	 /// </summary>
	public int  getPlanId(){  
		return planId; 
	}

	/// <summary>
	 /// 房间ID(对应宠物)
	 /// </summary>
	public void setFromRoomId(int fromRoomId){
		this.fromRoomId=fromRoomId;
	}

	/// <summary>
	 ///房间ID(对应宠物)
	 /// </summary>
	public int  getFromRoomId(){  
		return fromRoomId; 
	}

	/// <summary>
	 /// 行
	 /// </summary>
	public void setFromRow(int fromRow){
		this.fromRow=fromRow;
	}

	/// <summary>
	 ///行
	 /// </summary>
	public int  getFromRow(){  
		return fromRow; 
	}

	/// <summary>
	 /// 列
	 /// </summary>
	public void setFromCol(int fromCol){
		this.fromCol=fromCol;
	}

	/// <summary>
	 ///列
	 /// </summary>
	public int  getFromCol(){  
		return fromCol; 
	}

	/// <summary>
	 /// 房间ID(对应宠物)
	 /// </summary>
	public void setToRoomId(int toRoomId){
		this.toRoomId=toRoomId;
	}

	/// <summary>
	 ///房间ID(对应宠物)
	 /// </summary>
	public int  getToRoomId(){  
		return toRoomId; 
	}

	/// <summary>
	 /// 行
	 /// </summary>
	public void setToRow(int toRow){
		this.toRow=toRow;
	}

	/// <summary>
	 ///行
	 /// </summary>
	public int  getToRow(){  
		return toRow; 
	}

	/// <summary>
	 /// 列
	 /// </summary>
	public void setToCol(int toCol){
		this.toCol=toCol;
	}

	/// <summary>
	 ///列
	 /// </summary>
	public int  getToCol(){  
		return toCol; 
	}

	public override string ToString() {
		return "planId:" + planId + "," + "fromRoomId:" + fromRoomId + "," + "fromRow:" + fromRow + "," + "fromCol:" + fromCol + "," + "toRoomId:" + toRoomId + "," + "toRow:" + toRow + "," + "toCol:" + toCol;
	}

}
}