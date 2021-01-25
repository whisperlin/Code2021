namespace com.hbt.protocol.po{

public class DefaultConst{

		/// <summary>
		 ///成功
		 /// </summary>
		public const int COMM_RESULT_SUCCESS = 1; 

		/// <summary>
		 ///失败
		 /// </summary>
		public const int COMM_RESULT_FAIL = 0; 

		/// <summary>
		 ///失败—当前操作的对应等级不符合
		 /// </summary>
		public const int COMM_RESULT_FAIL_MY_LEVEL = -1; 

		/// <summary>
		 ///失败—当前操作的对应等级已经最高
		 /// </summary>
		public const int COMM_RESULT_FAIL_LEVELMAX = -2; 

		/// <summary>
		 ///失败—城镇等级不足
		 /// </summary>
		public const int COMM_RESULT_FAIL_NEED_TOWN_LEVEL = -3; 

		/// <summary>
		 ///失败—居民楼等级不足
		 /// </summary>
		public const int COMM_RESULT_FAIL_NEED_HOUSE_LEVEL = -4; 

		/// <summary>
		 ///失败—声望不足
		 /// </summary>
		public const int COMM_RESULT_FAIL_NEED_EXP = -5; 

		/// <summary>
		 ///失败—生态不足
		 /// </summary>
		public const int COMM_RESULT_FAIL_NEED_STD_A = -6; 

		/// <summary>
		 ///失败—休闲不足
		 /// </summary>
		public const int COMM_RESULT_FAIL_NEED_STD_B = -7; 

		/// <summary>
		 ///失败—文化不足
		 /// </summary>
		public const int COMM_RESULT_FAIL_NEED_STD_C = -8; 

		/// <summary>
		 ///失败—食物产量不足
		 /// </summary>
		public const int COMM_RESULT_FAIL_NEED_FOOD_PPM = -9; 

		/// <summary>
		 ///失败—占用环保不足
		 /// </summary>
		public const int COMM_RESULT_FAIL_NEED_RES_A = -11; 

		/// <summary>
		 ///失败—占用娱乐不足
		 /// </summary>
		public const int COMM_RESULT_FAIL_NEED_RES_B = -12; 

		/// <summary>
		 ///失败—占用教育不足
		 /// </summary>
		public const int COMM_RESULT_FAIL_NEED_RES_C = -13; 

		/// <summary>
		 ///失败—占用电力不足
		 /// </summary>
		public const int COMM_RESULT_FAIL_NEED_RES_EG = -14; 

		/// <summary>
		 ///失败—提供环保不足
		 /// </summary>
		public const int COMM_RESULT_FAIL_NEED_RES_A_GEN = -15; 

		/// <summary>
		 ///失败—提供娱乐不足
		 /// </summary>
		public const int COMM_RESULT_FAIL_NEED_RES_B_GEN = -16; 

		/// <summary>
		 ///失败—提供教育不足
		 /// </summary>
		public const int COMM_RESULT_FAIL_NEED_RES_C_GEN = -17; 

		/// <summary>
		 ///失败—提供电力不足
		 /// </summary>
		public const int COMM_RESULT_FAIL_NEED_RES_EG_GEN = -18; 

		/// <summary>
		 ///失败—金币不够
		 /// </summary>
		public const int COMM_RESULT_FAIL_NO_COIN = -101; 

		/// <summary>
		 ///失败—钻石不够
		 /// </summary>
		public const int COMM_RESULT_FAIL_NO_DIAMOND = -102; 

		/// <summary>
		 ///失败—城镇等级不满足条件
		 /// </summary>
		public const int COMM_RESULT_FAIL_NO_TOWN_LEVEL = -102; 

		/// <summary>
		 ///失败—居民楼等级不满足条件
		 /// </summary>
		public const int COMM_RESULT_FAIL_NO_HOUSE_LEVEL = -102; 

		/// <summary>
		 ///失败—建筑等级不满足条件
		 /// </summary>
		public const int COMM_RESULT_FAIL_NO_BUILDING_LEVEL = -102; 

		/// <summary>
		 ///失败—装备等级不满足条件
		 /// </summary>
		public const int COMM_RESULT_FAIL_NO_EQUMENT_LEVEL = -102; 

		/// <summary>
		 ///失败—建筑已经被使用
		 /// </summary>
		public const int COMM_RESULT_FAIL_BUILDING_ALREADY_USED = -202; 

		/// <summary>
		 ///失败—装备已经被使用
		 /// </summary>
		public const int COMM_RESULT_FAIL_EQUMENT_ALREADY_USED = -203; 

		/// <summary>
		 ///失败—装备栏已经被使用
		 /// </summary>
		public const int COMM_RESULT_FAIL_EQUMENT_SLOT_ALREADY_USED = -204; 

		/// <summary>
		 ///失败—道具已经被使用
		 /// </summary>
		public const int COMM_RESULT_FAIL_ITEM_ALREADY_USED = -205; 

		/// <summary>
		 ///失败—配方不允许激活（条件未达成）
		 /// </summary>
		public const int COMM_RESULT_FAIL_FORMULA_NOT_ALLOW_ACTIVE = -206; 

		/// <summary>
		 ///失败—配方已经激活
		 /// </summary>
		public const int COMM_RESULT_FAIL_FORMULA_ALREADY_ACTIVE = -207; 

		/// <summary>
		 ///失败—等级已满
		 /// </summary>
		public const int COMM_RESULT_FAIL_FULL_LEVEL = -300; 

		/// <summary>
		 ///失败—金币已满
		 /// </summary>
		public const int COMM_RESULT_FAIL_FULL_COIN = -301; 

		/// <summary>
		 ///失败—钻石已满
		 /// </summary>
		public const int COMM_RESULT_FAIL_FULL_DIAMOND = -302; 

		/// <summary>
		 ///失败—类型错误
		 /// </summary>
		public const int COMM_RESULT_FAIL_TYPE_ERR = -330; 

		/// <summary>
		 ///失败—类型错误-道具
		 /// </summary>
		public const int COMM_RESULT_FAIL_TYPE_ERR_ITEM = -331; 

		/// <summary>
		 ///失败—类型错误-道具
		 /// </summary>
		public const int COMM_RESULT_FAIL_TYPE_ERR_EQUIPMENT = -332; 

		/// <summary>
		 ///失败—类型错误-道具
		 /// </summary>
		public const int COMM_RESULT_FAIL_TYPE_ERR_BUILD = -333; 

		/// <summary>
		 ///失败—类型错误-道具
		 /// </summary>
		public const int COMM_RESULT_FAIL_TYPE_ERR_BUILD_EG = -334; 

		/// <summary>
		 ///失败—类型错误-宠物
		 /// </summary>
		public const int COMM_RESULT_FAIL_TYPE_ERR_PET = -335; 

		/// <summary>
		 ///失败—类型错误-污染食物
		 /// </summary>
		public const int COMM_RESULT_FAIL_TYPE_ERR_CONTAIMINATED = -336; 

		/// <summary>
		 ///失败—没有找到目标
		 /// </summary>
		public const int COMM_RESULT_FAIL_NOT_FOUND_TARGET = -501; 

		/// <summary>
		 ///失败—没有找到关联目标
		 /// </summary>
		public const int COMM_RESULT_FAIL_NOT_FOUND_RELATION = -502; 

		/// <summary>
		 ///失败—战斗地图未找到
		 /// </summary>
		public const int COMM_RESULT_FAIL_NOT_FOUND_CHAPTER = -503; 

		/// <summary>
		 ///失败—没有地图未开启
		 /// </summary>
		public const int COMM_RESULT_FAIL_NOT_OPEN_CHAPTER = -504; 

		/// <summary>
		 ///失败—街区未找到
		 /// </summary>
		public const int COMM_RESULT_FAIL_NOT_FOUND_DISTRICT = -505; 

		/// <summary>
		 ///失败—街区未开启
		 /// </summary>
		public const int COMM_RESULT_FAIL_NOT_OPEN_DISTRICT = -506; 

		/// <summary>
		 ///失败—街区区域未找到
		 /// </summary>
		public const int COMM_RESULT_FAIL_NOT_FOUND_AREA = -507; 

		/// <summary>
		 ///失败—街区区域未开启
		 /// </summary>
		public const int COMM_RESULT_FAIL_NOT_OPEN_AREA = -508; 

		/// <summary>
		 ///失败—建筑物未找到
		 /// </summary>
		public const int COMM_RESULT_FAIL_NOT_FOUND_BUILDING = -509; 

		/// <summary>
		 ///失败—建筑物未开启
		 /// </summary>
		public const int COMM_RESULT_FAIL_NOT_OPEN_BUILDING = -510; 

		/// <summary>
		 ///失败—装备未找到
		 /// </summary>
		public const int COMM_RESULT_FAIL_NOT_FOUND_EQUMENT = -511; 

		/// <summary>
		 ///失败—道具未找到
		 /// </summary>
		public const int COMM_RESULT_FAIL_NOT_FOUND_ITEM = -512; 

		/// <summary>
		 ///失败—房间未找到
		 /// </summary>
		public const int COMM_RESULT_FAIL_NOT_FOUND_ROOM = -513; 

		/// <summary>
		 ///失败—装备栏未找到
		 /// </summary>
		public const int COMM_RESULT_FAIL_NOT_FOUND_EQUMENT_SLOT = -514; 

		/// <summary>
		 ///失败—宠物未找到
		 /// </summary>
		public const int COMM_RESULT_FAIL_NOT_FOUND_PET = -515; 

		/// <summary>
		 ///失败—装备栏未开启
		 /// </summary>
		public const int COMM_RESULT_FAIL_NOT_OPEN_EQUMENT_SLOT = -516; 

		/// <summary>
		 ///失败—配方未找到
		 /// </summary>
		public const int COMM_RESULT_FAIL_NOT_FOUND_FORMULA = -517; 

		/// <summary>
		 ///未设置
		 /// </summary>
		public const int MODULE_ID_UNSET = 0; 

		/// <summary>
		 ///入口
		 /// </summary>
		public const int MODULE_ID_ENTRANCE = 1; 

		/// <summary>
		 ///聊天室
		 /// </summary>
		public const int MODULE_ID_CHAT = 5; 

		/// <summary>
		 ///游戏大厅
		 /// </summary>
		public const int MODULE_ID_LOBBY = 2; 

		/// <summary>
		 ///城镇
		 /// </summary>
		public const int MODULE_ID_TOWN = 3; 

		/// <summary>
		 ///工会
		 /// </summary>
		public const int MODULE_ID_UNION = 7; 

		/// <summary>
		 ///商店
		 /// </summary>
		public const int MODULE_ID_SHOP = 8; 

		/// <summary>
		 ///战斗模块
		 /// </summary>
		public const int MODULE_ID_BATTLE = 10; 


}
}