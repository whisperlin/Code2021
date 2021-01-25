using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.town{

/// <summary>
 /// 净化食物
 /// </summary>
public class PurifyFoodPo_Rp  : BasePo{

	public const int cmd = -246617;
	public const string reflectClassName = "com.hbt.protocol.po.town.PurifyFoodPo_Rp";

	public PurifyFoodPo_Rp():base() {
		commandId = -246617;
		encryptTypeDown = 0;
	}

	public PurifyFoodPo_Rp(MemoryStream inputStream){
		commandId = -246617;
		encryptTypeDown = 0;
		this.setResult(PackageUtil.DecodeInteger(inputStream));
		this.setItemUuid(PackageUtil.DecodeLong(inputStream));
		this.setOldFood(PackageUtil.DecodeInteger(inputStream));
		this.setOldTechLevel1(PackageUtil.DecodeInteger(inputStream));
		this.setOldTechLevel2(PackageUtil.DecodeInteger(inputStream));
		this.setOldTechLevel3(PackageUtil.DecodeInteger(inputStream));
		this.setAftFood(PackageUtil.DecodeInteger(inputStream));
		this.setAftTechLevel1(PackageUtil.DecodeInteger(inputStream));
		this.setAftTechLevel2(PackageUtil.DecodeInteger(inputStream));
		this.setAftTechLevel3(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getResult());
		PackageUtil.EncodeLong(outputStream, getItemUuid());
		PackageUtil.EncodeInteger(outputStream, getOldFood());
		PackageUtil.EncodeInteger(outputStream, getOldTechLevel1());
		PackageUtil.EncodeInteger(outputStream, getOldTechLevel2());
		PackageUtil.EncodeInteger(outputStream, getOldTechLevel3());
		PackageUtil.EncodeInteger(outputStream, getAftFood());
		PackageUtil.EncodeInteger(outputStream, getAftTechLevel1());
		PackageUtil.EncodeInteger(outputStream, getAftTechLevel2());
		PackageUtil.EncodeInteger(outputStream, getAftTechLevel3());
	}

	/// <summary>
	 ///结果: DefaultConst.COMM_RESULT_*
	 /// </summary>
	private int result; 

	/// <summary>
	 ///道具ID
	 /// </summary>
	private ulong itemUuid; 

	/// <summary>
	 ///净化前食物值
	 /// </summary>
	private int oldFood; 

	/// <summary>
	 ///净化前水果加工值
	 /// </summary>
	private int oldTechLevel1; 

	/// <summary>
	 ///净化前蔬菜加工值
	 /// </summary>
	private int oldTechLevel2; 

	/// <summary>
	 ///净化前谷物加工值
	 /// </summary>
	private int oldTechLevel3; 

	/// <summary>
	 ///净化后食物值
	 /// </summary>
	private int aftFood; 

	/// <summary>
	 ///净化后水果加工值
	 /// </summary>
	private int aftTechLevel1; 

	/// <summary>
	 ///净化后蔬菜加工值
	 /// </summary>
	private int aftTechLevel2; 

	/// <summary>
	 ///净化后谷物加工值
	 /// </summary>
	private int aftTechLevel3; 

	/// <summary>
	 ///结果: DefaultConst.COMM_RESULT_*
	 /// </summary>
	public void setResult(int result){
		this.result=result;
	}

	/// <summary>
	 ///结果: DefaultConst.COMM_RESULT_*
	 /// </summary>
	public int  getResult(){  
		return result; 
	}

	/// <summary>
	 ///道具ID
	 /// </summary>
	public void setItemUuid(ulong itemUuid){
		this.itemUuid=itemUuid;
	}

	/// <summary>
	 ///道具ID
	 /// </summary>
	public ulong  getItemUuid(){  
		return itemUuid; 
	}

	/// <summary>
	 ///净化前食物值
	 /// </summary>
	public void setOldFood(int oldFood){
		this.oldFood=oldFood;
	}

	/// <summary>
	 ///净化前食物值
	 /// </summary>
	public int  getOldFood(){  
		return oldFood; 
	}

	/// <summary>
	 ///净化前水果加工值
	 /// </summary>
	public void setOldTechLevel1(int oldTechLevel1){
		this.oldTechLevel1=oldTechLevel1;
	}

	/// <summary>
	 ///净化前水果加工值
	 /// </summary>
	public int  getOldTechLevel1(){  
		return oldTechLevel1; 
	}

	/// <summary>
	 ///净化前蔬菜加工值
	 /// </summary>
	public void setOldTechLevel2(int oldTechLevel2){
		this.oldTechLevel2=oldTechLevel2;
	}

	/// <summary>
	 ///净化前蔬菜加工值
	 /// </summary>
	public int  getOldTechLevel2(){  
		return oldTechLevel2; 
	}

	/// <summary>
	 ///净化前谷物加工值
	 /// </summary>
	public void setOldTechLevel3(int oldTechLevel3){
		this.oldTechLevel3=oldTechLevel3;
	}

	/// <summary>
	 ///净化前谷物加工值
	 /// </summary>
	public int  getOldTechLevel3(){  
		return oldTechLevel3; 
	}

	/// <summary>
	 ///净化后食物值
	 /// </summary>
	public void setAftFood(int aftFood){
		this.aftFood=aftFood;
	}

	/// <summary>
	 ///净化后食物值
	 /// </summary>
	public int  getAftFood(){  
		return aftFood; 
	}

	/// <summary>
	 ///净化后水果加工值
	 /// </summary>
	public void setAftTechLevel1(int aftTechLevel1){
		this.aftTechLevel1=aftTechLevel1;
	}

	/// <summary>
	 ///净化后水果加工值
	 /// </summary>
	public int  getAftTechLevel1(){  
		return aftTechLevel1; 
	}

	/// <summary>
	 ///净化后蔬菜加工值
	 /// </summary>
	public void setAftTechLevel2(int aftTechLevel2){
		this.aftTechLevel2=aftTechLevel2;
	}

	/// <summary>
	 ///净化后蔬菜加工值
	 /// </summary>
	public int  getAftTechLevel2(){  
		return aftTechLevel2; 
	}

	/// <summary>
	 ///净化后谷物加工值
	 /// </summary>
	public void setAftTechLevel3(int aftTechLevel3){
		this.aftTechLevel3=aftTechLevel3;
	}

	/// <summary>
	 ///净化后谷物加工值
	 /// </summary>
	public int  getAftTechLevel3(){  
		return aftTechLevel3; 
	}

	public override string ToString() {
		return "result:" + result + "," + "itemUuid:" + itemUuid + "," + "oldFood:" + oldFood + "," + "oldTechLevel1:" + oldTechLevel1 + "," + "oldTechLevel2:" + oldTechLevel2 + "," + "oldTechLevel3:" + oldTechLevel3 + "," + "aftFood:" + aftFood + "," + "aftTechLevel1:" + aftTechLevel1 + "," + "aftTechLevel2:" + aftTechLevel2 + "," + "aftTechLevel3:" + aftTechLevel3;
	}

}
}