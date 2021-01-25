using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.chapter{

/// <summary>
 /// 队伍的各种状态列表
 /// </summary>
public class ChapterPetListPo_Rp  : BasePo{

	public const int cmd = -770915;
	public const string reflectClassName = "com.hbt.protocol.po.chapter.ChapterPetListPo_Rp";

	public ChapterPetListPo_Rp():base() {
		commandId = -770915;
		encryptTypeDown = 0;
	}

	public ChapterPetListPo_Rp(MemoryStream inputStream){
		commandId = -770915;
		encryptTypeDown = 0;
		this.setRemainFood(PackageUtil.DecodeInteger(inputStream));

		short length0 = PackageUtil.DecodeShort(inputStream);//集合长度
		List<com.hbt.protocol.po.chapter.ChapterBufferPo> buffers = new List<com.hbt.protocol.po.chapter.ChapterBufferPo>();
		for(int i = 0; i < length0; i++){
			PackageUtil.skipInputStream(inputStream, 4);//读4位
			buffers.Add(new com.hbt.protocol.po.chapter.ChapterBufferPo(inputStream));
		}
		this.setBuffers(buffers);

		short length1 = PackageUtil.DecodeShort(inputStream);//集合长度
		List<com.hbt.protocol.po.chapter.ChapterPetPo> pets = new List<com.hbt.protocol.po.chapter.ChapterPetPo>();
		for(int i = 0; i < length1; i++){
			PackageUtil.skipInputStream(inputStream, 4);//读4位
			pets.Add(new com.hbt.protocol.po.chapter.ChapterPetPo(inputStream));
		}
		this.setPets(pets);
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getRemainFood());

		List<com.hbt.protocol.po.chapter.ChapterBufferPo> buffers = getBuffers();
		short bufferslength = (short)(buffers == null ? 0 : buffers.Count);
		PackageUtil.EncodeShort(outputStream, bufferslength);
		for(int i = 0; i < bufferslength; i++){
			buffers[i].encodeVo(outputStream);
		}

		List<com.hbt.protocol.po.chapter.ChapterPetPo> pets = getPets();
		short petslength = (short)(pets == null ? 0 : pets.Count);
		PackageUtil.EncodeShort(outputStream, petslength);
		for(int i = 0; i < petslength; i++){
			pets[i].encodeVo(outputStream);
		}
	}

	/// <summary>
	 ///当前剩余食物
	 /// </summary>
	private int remainFood; 

	/// <summary>
	 ///关卡buff列表
	 /// </summary>
	private List<com.hbt.protocol.po.chapter.ChapterBufferPo> buffers; 

	/// <summary>
	 ///宠物状态列表
	 /// </summary>
	private List<com.hbt.protocol.po.chapter.ChapterPetPo> pets; 

	/// <summary>
	 ///当前剩余食物
	 /// </summary>
	public void setRemainFood(int remainFood){
		this.remainFood=remainFood;
	}

	/// <summary>
	 ///当前剩余食物
	 /// </summary>
	public int  getRemainFood(){  
		return remainFood; 
	}

	/// <summary>
	 ///关卡buff列表
	 /// </summary>
	public void setBuffers(List<com.hbt.protocol.po.chapter.ChapterBufferPo> buffers){
		this.buffers=buffers;
	}

	/// <summary>
	 ///关卡buff列表
	 /// </summary>
	public List<com.hbt.protocol.po.chapter.ChapterBufferPo> getBuffers(){  
		return buffers; 
	}

	/// <summary>
	 ///宠物状态列表
	 /// </summary>
	public void setPets(List<com.hbt.protocol.po.chapter.ChapterPetPo> pets){
		this.pets=pets;
	}

	/// <summary>
	 ///宠物状态列表
	 /// </summary>
	public List<com.hbt.protocol.po.chapter.ChapterPetPo> getPets(){  
		return pets; 
	}

	public override string ToString() {
		return "remainFood:" + remainFood + "," + "buffers size:" + buffers.Count + "," + "pets size:" + pets.Count;
	}

}
}