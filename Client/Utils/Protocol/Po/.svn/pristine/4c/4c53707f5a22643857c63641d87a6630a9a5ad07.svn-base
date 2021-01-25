using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.chapter{

/// <summary>
 /// 获取地图地形数据
 /// </summary>
public class GetMapDataPo_Rp  : BasePo{

	public const int cmd = -770902;
	public const string reflectClassName = "com.hbt.protocol.po.chapter.GetMapDataPo_Rp";

	public GetMapDataPo_Rp():base() {
		commandId = -770902;
		encryptTypeDown = 0;
	}

	public GetMapDataPo_Rp(MemoryStream inputStream){
		commandId = -770902;
		encryptTypeDown = 0;
		this.setChapterId(PackageUtil.DecodeInteger(inputStream));
		this.setRowCount(PackageUtil.DecodeInteger(inputStream));
		this.setColCount(PackageUtil.DecodeInteger(inputStream));

		short length0 = PackageUtil.DecodeShort(inputStream);//集合长度
		List<com.hbt.protocol.po.chapter.MapNodePo> items = new List<com.hbt.protocol.po.chapter.MapNodePo>();
		for(int i = 0; i < length0; i++){
			PackageUtil.skipInputStream(inputStream, 4);//读4位
			items.Add(new com.hbt.protocol.po.chapter.MapNodePo(inputStream));
		}
		this.setItems(items);
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getChapterId());
		PackageUtil.EncodeInteger(outputStream, getRowCount());
		PackageUtil.EncodeInteger(outputStream, getColCount());

		List<com.hbt.protocol.po.chapter.MapNodePo> items = getItems();
		short itemslength = (short)(items == null ? 0 : items.Count);
		PackageUtil.EncodeShort(outputStream, itemslength);
		for(int i = 0; i < itemslength; i++){
			items[i].encodeVo(outputStream);
		}
	}

	/// <summary>
	 ///关卡ID
	 /// </summary>
	private int chapterId; 

	/// <summary>
	 ///地图行
	 /// </summary>
	private int rowCount; 

	/// <summary>
	 ///地图列
	 /// </summary>
	private int colCount; 

	/// <summary>
	 ///地图地形数据
	 /// </summary>
	private List<com.hbt.protocol.po.chapter.MapNodePo> items; 

	/// <summary>
	 ///关卡ID
	 /// </summary>
	public void setChapterId(int chapterId){
		this.chapterId=chapterId;
	}

	/// <summary>
	 ///关卡ID
	 /// </summary>
	public int  getChapterId(){  
		return chapterId; 
	}

	/// <summary>
	 ///地图行
	 /// </summary>
	public void setRowCount(int rowCount){
		this.rowCount=rowCount;
	}

	/// <summary>
	 ///地图行
	 /// </summary>
	public int  getRowCount(){  
		return rowCount; 
	}

	/// <summary>
	 ///地图列
	 /// </summary>
	public void setColCount(int colCount){
		this.colCount=colCount;
	}

	/// <summary>
	 ///地图列
	 /// </summary>
	public int  getColCount(){  
		return colCount; 
	}

	/// <summary>
	 ///地图地形数据
	 /// </summary>
	public void setItems(List<com.hbt.protocol.po.chapter.MapNodePo> items){
		this.items=items;
	}

	/// <summary>
	 ///地图地形数据
	 /// </summary>
	public List<com.hbt.protocol.po.chapter.MapNodePo> getItems(){  
		return items; 
	}

	public override string ToString() {
		return "chapterId:" + chapterId + "," + "rowCount:" + rowCount + "," + "colCount:" + colCount + "," + "items size:" + items.Count;
	}

}
}