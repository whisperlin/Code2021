using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.item{

/// <summary>
 /// 道具列表
 /// </summary>
public class ItemListPo_Rp  : BasePo{

	public const int cmd = -377680;
	public const string reflectClassName = "com.hbt.protocol.po.item.ItemListPo_Rp";

	public ItemListPo_Rp():base() {
		commandId = -377680;
		encryptTypeDown = 0;
	}

	public ItemListPo_Rp(MemoryStream inputStream){
		commandId = -377680;
		encryptTypeDown = 0;

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

		List<com.hbt.protocol.po.item.ItemPo> items = getItems();
		short itemslength = (short)(items == null ? 0 : items.Count);
		PackageUtil.EncodeShort(outputStream, itemslength);
		for(int i = 0; i < itemslength; i++){
			items[i].encodeVo(outputStream);
		}
	}

	/// <summary>
	 ///道具列表
	 /// </summary>
	private List<com.hbt.protocol.po.item.ItemPo> items; 

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
		return "items size:" + items.Count;
	}

}
}