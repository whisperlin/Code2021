using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.house{

/// <summary>
 /// 阵型站位
 /// </summary>
public class FormationSeatPo : BasePo{

	public const int cmd = 312152;
	public const string reflectClassName = "com.hbt.protocol.po.house.FormationSeatPo";

	public FormationSeatPo():base() {
		commandId = 312152;
		encryptTypeUp = 0;
	}

	public FormationSeatPo(MemoryStream inputStream){
		commandId = 312152;
		encryptTypeUp = 0;
		this.setRoomId(PackageUtil.DecodeInteger(inputStream));
		this.setRow(PackageUtil.DecodeInteger(inputStream));
		this.setCol(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getRoomId());
		PackageUtil.EncodeInteger(outputStream, getRow());
		PackageUtil.EncodeInteger(outputStream, getCol());
	}

	/// <summary>
	 /// 房间ID(对应宠物)
	 /// </summary>
	private int roomId; 

	/// <summary>
	 /// 行
	 /// </summary>
	private int row; 

	/// <summary>
	 /// 列
	 /// </summary>
	private int col; 

	/// <summary>
	 /// 房间ID(对应宠物)
	 /// </summary>
	public void setRoomId(int roomId){
		this.roomId=roomId;
	}

	/// <summary>
	 ///房间ID(对应宠物)
	 /// </summary>
	public int  getRoomId(){  
		return roomId; 
	}

	/// <summary>
	 /// 行
	 /// </summary>
	public void setRow(int row){
		this.row=row;
	}

	/// <summary>
	 ///行
	 /// </summary>
	public int  getRow(){  
		return row; 
	}

	/// <summary>
	 /// 列
	 /// </summary>
	public void setCol(int col){
		this.col=col;
	}

	/// <summary>
	 ///列
	 /// </summary>
	public int  getCol(){  
		return col; 
	}

	public override string ToString() {
		return "roomId:" + roomId + "," + "row:" + row + "," + "col:" + col;
	}

}
}