using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.chapter{

/// <summary>
 /// 关卡结束包
 /// </summary>
public class ChapterEndPo_Rp  : BasePo{

	public const int cmd = -770912;
	public const string reflectClassName = "com.hbt.protocol.po.chapter.ChapterEndPo_Rp";

	public ChapterEndPo_Rp():base() {
		commandId = -770912;
		encryptTypeDown = 0;
	}

	public ChapterEndPo_Rp(MemoryStream inputStream){
		commandId = -770912;
		encryptTypeDown = 0;
		this.setExp(PackageUtil.DecodeInteger(inputStream));
		this.setCoin(PackageUtil.DecodeInteger(inputStream));
		this.setDiamond(PackageUtil.DecodeInteger(inputStream));

		short length0 = PackageUtil.DecodeShort(inputStream);//集合长度
		List<com.hbt.protocol.po.item.ItemPo> items = new List<com.hbt.protocol.po.item.ItemPo>();
		for(int i = 0; i < length0; i++){
			PackageUtil.skipInputStream(inputStream, 4);//读4位
			items.Add(new com.hbt.protocol.po.item.ItemPo(inputStream));
		}
		this.setItems(items);
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getExp());
		PackageUtil.EncodeInteger(outputStream, getCoin());
		PackageUtil.EncodeInteger(outputStream, getDiamond());

		List<com.hbt.protocol.po.item.ItemPo> items = getItems();
		short itemslength = (short)(items == null ? 0 : items.Count);
		PackageUtil.EncodeShort(outputStream, itemslength);
		for(int i = 0; i < itemslength; i++){
			items[i].encodeVo(outputStream);
		}
	}

	/// <summary>
	 ///结算获得的声望
	 /// </summary>
	private int exp; 

	/// <summary>
	 ///结算获得的金币
	 /// </summary>
	private int coin; 

	/// <summary>
	 ///结算获得的钻石
	 /// </summary>
	private int diamond; 

	/// <summary>
	 ///道具列表
	 /// </summary>
	private List<com.hbt.protocol.po.item.ItemPo> items; 

	/// <summary>
	 ///结算获得的声望
	 /// </summary>
	public void setExp(int exp){
		this.exp=exp;
	}

	/// <summary>
	 ///结算获得的声望
	 /// </summary>
	public int  getExp(){  
		return exp; 
	}

	/// <summary>
	 ///结算获得的金币
	 /// </summary>
	public void setCoin(int coin){
		this.coin=coin;
	}

	/// <summary>
	 ///结算获得的金币
	 /// </summary>
	public int  getCoin(){  
		return coin; 
	}

	/// <summary>
	 ///结算获得的钻石
	 /// </summary>
	public void setDiamond(int diamond){
		this.diamond=diamond;
	}

	/// <summary>
	 ///结算获得的钻石
	 /// </summary>
	public int  getDiamond(){  
		return diamond; 
	}

	/// <summary>
	 ///道具列表
	 /// </summary>
	public void setItems(List<com.hbt.protocol.po.item.ItemPo> items){
		this.items=items;
	}

	/// <summary>
	 ///道具列表
	 /// </summary>
	public List<com.hbt.protocol.po.item.ItemPo> getItems(){  
		return items; 
	}

	public override string ToString() {
		return "exp:" + exp + "," + "coin:" + coin + "," + "diamond:" + diamond + "," + "items size:" + items.Count;
	}

}
}