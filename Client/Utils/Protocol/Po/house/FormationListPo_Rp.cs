using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.house{

/// <summary>
 /// 阵型列表
 /// </summary>
public class FormationListPo_Rp  : BasePo{

	public const int cmd = -312151;
	public const string reflectClassName = "com.hbt.protocol.po.house.FormationListPo_Rp";

	public FormationListPo_Rp():base() {
		commandId = -312151;
		encryptTypeDown = 0;
	}

	public FormationListPo_Rp(MemoryStream inputStream){
		commandId = -312151;
		encryptTypeDown = 0;

		short length0 = PackageUtil.DecodeShort(inputStream);//集合长度
		List<com.hbt.protocol.po.house.FormationSeatPo> seats = new List<com.hbt.protocol.po.house.FormationSeatPo>();
		for(int i = 0; i < length0; i++){
			PackageUtil.skipInputStream(inputStream, 4);//读4位
			seats.Add(new com.hbt.protocol.po.house.FormationSeatPo(inputStream));
		}
		this.setSeats(seats);
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);

		List<com.hbt.protocol.po.house.FormationSeatPo> seats = getSeats();
		short seatslength = (short)(seats == null ? 0 : seats.Count);
		PackageUtil.EncodeShort(outputStream, seatslength);
		for(int i = 0; i < seatslength; i++){
			seats[i].encodeVo(outputStream);
		}
	}

	/// <summary>
	 ///阵型站位列表
	 /// </summary>
	private List<com.hbt.protocol.po.house.FormationSeatPo> seats; 

	/// <summary>
	 ///阵型站位列表
	 /// </summary>
	public void setSeats(List<com.hbt.protocol.po.house.FormationSeatPo> seats){
		this.seats=seats;
	}

	/// <summary>
	 ///阵型站位列表
	 /// </summary>
	public List<com.hbt.protocol.po.house.FormationSeatPo> getSeats(){  
		return seats; 
	}

	public override string ToString() {
		return "seats size:" + seats.Count;
	}

}
}