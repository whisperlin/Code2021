using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.town{

/// <summary>
 /// 道具
 /// </summary>
public class ItemPo : BasePo{

	public const int cmd = 246613;
	public const string reflectClassName = "com.hbt.protocol.po.town.ItemPo";

	public ItemPo():base() {
		commandId = 246613;
		encryptTypeUp = 0;
	}

	public ItemPo(MemoryStream inputStream){
		commandId = 246613;
		encryptTypeUp = 0;
		this.setUuid(PackageUtil.DecodeLong(inputStream));
		this.setItemId(PackageUtil.DecodeInteger(inputStream));
		this.setLevel(PackageUtil.DecodeInteger(inputStream));
		this.setCount(PackageUtil.DecodeInteger(inputStream));
		this.setExpire(PackageUtil.DecodeInteger(inputStream));
		this.setEqId(PackageUtil.DecodeInteger(inputStream));
		this.setExtId(PackageUtil.DecodeInteger(inputStream));
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeLong(outputStream, getUuid());
		PackageUtil.EncodeInteger(outputStream, getItemId());
		PackageUtil.EncodeInteger(outputStream, getLevel());
		PackageUtil.EncodeInteger(outputStream, getCount());
		PackageUtil.EncodeInteger(outputStream, getExpire());
		PackageUtil.EncodeInteger(outputStream, getEqId());
		PackageUtil.EncodeInteger(outputStream, getExtId());
	}

	/// <summary>
	 /// 唯一ID
	 /// </summary>
	private ulong uuid; 

	/// <summary>
	 /// 物品ID
	 /// </summary>
	private int itemId; 

	/// <summary>
	 /// 等级
	 /// </summary>
	private int level; 

	/// <summary>
	 /// 堆叠数
	 /// </summary>
	private int count; 

	/// <summary>
	 /// 有效时间(分钟)
	 /// </summary>
	private int expire; 

	/// <summary>
	 /// 装备ID（专门为装备类反向标记，-1为未装备，也为建筑反向标志）
	 /// </summary>
	private int eqId; 

	/// <summary>
	 /// 扩展ID
	 /// </summary>
	private int extId; 

	/// <summary>
	 /// 唯一ID
	 /// </summary>
	public void setUuid(ulong uuid){
		this.uuid=uuid;
	}

	/// <summary>
	 ///唯一ID
	 /// </summary>
	public ulong  getUuid(){  
		return uuid; 
	}

	/// <summary>
	 /// 物品ID
	 /// </summary>
	public void setItemId(int itemId){
		this.itemId=itemId;
	}

	/// <summary>
	 ///物品ID
	 /// </summary>
	public int  getItemId(){  
		return itemId; 
	}

	/// <summary>
	 /// 等级
	 /// </summary>
	public void setLevel(int level){
		this.level=level;
	}

	/// <summary>
	 ///等级
	 /// </summary>
	public int  getLevel(){  
		return level; 
	}

	/// <summary>
	 /// 堆叠数
	 /// </summary>
	public void setCount(int count){
		this.count=count;
	}

	/// <summary>
	 ///堆叠数
	 /// </summary>
	public int  getCount(){  
		return count; 
	}

	/// <summary>
	 /// 有效时间(分钟)
	 /// </summary>
	public void setExpire(int expire){
		this.expire=expire;
	}

	/// <summary>
	 ///有效时间(分钟)
	 /// </summary>
	public int  getExpire(){  
		return expire; 
	}

	/// <summary>
	 /// 装备ID（专门为装备类反向标记，-1为未装备，也为建筑反向标志）
	 /// </summary>
	public void setEqId(int eqId){
		this.eqId=eqId;
	}

	/// <summary>
	 ///装备ID（专门为装备类反向标记，-1为未装备，也为建筑反向标志）
	 /// </summary>
	public int  getEqId(){  
		return eqId; 
	}

	/// <summary>
	 /// 扩展ID
	 /// </summary>
	public void setExtId(int extId){
		this.extId=extId;
	}

	/// <summary>
	 ///扩展ID
	 /// </summary>
	public int  getExtId(){  
		return extId; 
	}

	public override string ToString() {
		return "uuid:" + uuid + "," + "itemId:" + itemId + "," + "level:" + level + "," + "count:" + count + "," + "expire:" + expire + "," + "eqId:" + eqId + "," + "extId:" + extId;
	}

}
}