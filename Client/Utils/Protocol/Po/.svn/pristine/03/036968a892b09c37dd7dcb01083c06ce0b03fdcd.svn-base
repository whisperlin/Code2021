using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.house{

/// <summary>
 /// 宠物列表
 /// </summary>
public class PetListPo_Rp  : BasePo{

	public const int cmd = -312155;
	public const string reflectClassName = "com.hbt.protocol.po.house.PetListPo_Rp";

	public PetListPo_Rp():base() {
		commandId = -312155;
		encryptTypeDown = 0;
	}

	public PetListPo_Rp(MemoryStream inputStream){
		commandId = -312155;
		encryptTypeDown = 0;

		short length0 = PackageUtil.DecodeShort(inputStream);//集合长度
		List<com.hbt.protocol.po.house.PetPo> pets = new List<com.hbt.protocol.po.house.PetPo>();
		for(int i = 0; i < length0; i++){
			PackageUtil.skipInputStream(inputStream, 4);//读4位
			pets.Add(new com.hbt.protocol.po.house.PetPo(inputStream));
		}
		this.setPets(pets);
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);

		List<com.hbt.protocol.po.house.PetPo> pets = getPets();
		short petslength = (short)(pets == null ? 0 : pets.Count);
		PackageUtil.EncodeShort(outputStream, petslength);
		for(int i = 0; i < petslength; i++){
			pets[i].encodeVo(outputStream);
		}
	}

	/// <summary>
	 ///宠物列表
	 /// </summary>
	private List<com.hbt.protocol.po.house.PetPo> pets; 

	/// <summary>
	 ///宠物列表
	 /// </summary>
	public void setPets(List<com.hbt.protocol.po.house.PetPo> pets){
		this.pets=pets;
	}

	/// <summary>
	 ///宠物列表
	 /// </summary>
	public List<com.hbt.protocol.po.house.PetPo> getPets(){  
		return pets; 
	}

	public override string ToString() {
		return "pets size:" + pets.Count;
	}

}
}