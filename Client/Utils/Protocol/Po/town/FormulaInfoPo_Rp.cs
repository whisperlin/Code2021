using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.town{

/// <summary>
 /// 食品加工厂信息
 /// </summary>
public class FormulaInfoPo_Rp  : BasePo{

	public const int cmd = -246615;
	public const string reflectClassName = "com.hbt.protocol.po.town.FormulaInfoPo_Rp";

	public FormulaInfoPo_Rp():base() {
		commandId = -246615;
		encryptTypeDown = 0;
	}

	public FormulaInfoPo_Rp(MemoryStream inputStream){
		commandId = -246615;
		encryptTypeDown = 0;
		this.setFoodLevel(PackageUtil.DecodeInteger(inputStream));
		this.setFoodPpm(PackageUtil.DecodeFloat(inputStream));
		this.setTechLevel1(PackageUtil.DecodeInteger(inputStream));
		this.setTechLevel2(PackageUtil.DecodeInteger(inputStream));
		this.setTechLevel3(PackageUtil.DecodeInteger(inputStream));

		short length0 = PackageUtil.DecodeShort(inputStream);//集合长度
		List<com.hbt.protocol.po.town.FormulaPo> formulas = new List<com.hbt.protocol.po.town.FormulaPo>();
		for(int i = 0; i < length0; i++){
			PackageUtil.skipInputStream(inputStream, 4);//读4位
			formulas.Add(new com.hbt.protocol.po.town.FormulaPo(inputStream));
		}
		this.setFormulas(formulas);
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getFoodLevel());
		PackageUtil.EncodeFloat(outputStream, getFoodPpm());
		PackageUtil.EncodeInteger(outputStream, getTechLevel1());
		PackageUtil.EncodeInteger(outputStream, getTechLevel2());
		PackageUtil.EncodeInteger(outputStream, getTechLevel3());

		List<com.hbt.protocol.po.town.FormulaPo> formulas = getFormulas();
		short formulaslength = (short)(formulas == null ? 0 : formulas.Count);
		PackageUtil.EncodeShort(outputStream, formulaslength);
		for(int i = 0; i < formulaslength; i++){
			formulas[i].encodeVo(outputStream);
		}
	}

	/// <summary>
	 ///食品工厂等级
	 /// </summary>
	private int foodLevel; 

	/// <summary>
	 ///食品产量
	 /// </summary>
	private float foodPpm; 

	/// <summary>
	 ///水果加工值
	 /// </summary>
	private int techLevel1; 

	/// <summary>
	 ///蔬菜加工值
	 /// </summary>
	private int techLevel2; 

	/// <summary>
	 ///谷物加工值
	 /// </summary>
	private int techLevel3; 

	/// <summary>
	 ///配方列表
	 /// </summary>
	private List<com.hbt.protocol.po.town.FormulaPo> formulas; 

	/// <summary>
	 ///食品工厂等级
	 /// </summary>
	public void setFoodLevel(int foodLevel){
		this.foodLevel=foodLevel;
	}

	/// <summary>
	 ///食品工厂等级
	 /// </summary>
	public int  getFoodLevel(){  
		return foodLevel; 
	}

	/// <summary>
	 ///食品产量
	 /// </summary>
	public void setFoodPpm(float foodPpm){
		this.foodPpm=foodPpm;
	}

	/// <summary>
	 ///食品产量
	 /// </summary>
	public float  getFoodPpm(){  
		return foodPpm; 
	}

	/// <summary>
	 ///水果加工值
	 /// </summary>
	public void setTechLevel1(int techLevel1){
		this.techLevel1=techLevel1;
	}

	/// <summary>
	 ///水果加工值
	 /// </summary>
	public int  getTechLevel1(){  
		return techLevel1; 
	}

	/// <summary>
	 ///蔬菜加工值
	 /// </summary>
	public void setTechLevel2(int techLevel2){
		this.techLevel2=techLevel2;
	}

	/// <summary>
	 ///蔬菜加工值
	 /// </summary>
	public int  getTechLevel2(){  
		return techLevel2; 
	}

	/// <summary>
	 ///谷物加工值
	 /// </summary>
	public void setTechLevel3(int techLevel3){
		this.techLevel3=techLevel3;
	}

	/// <summary>
	 ///谷物加工值
	 /// </summary>
	public int  getTechLevel3(){  
		return techLevel3; 
	}

	/// <summary>
	 ///配方列表
	 /// </summary>
	public void setFormulas(List<com.hbt.protocol.po.town.FormulaPo> formulas){
		this.formulas=formulas;
	}

	/// <summary>
	 ///配方列表
	 /// </summary>
	public List<com.hbt.protocol.po.town.FormulaPo> getFormulas(){  
		return formulas; 
	}

	public override string ToString() {
		return "foodLevel:" + foodLevel + "," + "foodPpm:" + foodPpm + "," + "techLevel1:" + techLevel1 + "," + "techLevel2:" + techLevel2 + "," + "techLevel3:" + techLevel3 + "," + "formulas size:" + formulas.Count;
	}

}
}