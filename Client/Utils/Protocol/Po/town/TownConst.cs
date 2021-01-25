namespace com.hbt.protocol.po.town{

public class TownConst{

		/// <summary>
		 ///成功升级/建造
		 /// </summary>
		public const int BUILD_RESULT_SUCCESS = 1; 

		/// <summary>
		 ///失败—其他
		 /// </summary>
		public const int BUILD_RESULT_FAIL_OTHER = 0; 

		/// <summary>
		 ///失败—当前等级不符合
		 /// </summary>
		public const int BUILD_RESULT_FAIL_MY_LEVEL = -1; 

		/// <summary>
		 ///失败—等级已经最高
		 /// </summary>
		public const int BUILD_RESULT_FAIL_LEVELMAX = -2; 

		/// <summary>
		 ///失败—城镇等级不足
		 /// </summary>
		public const int BUILD_RESULT_FAIL_NEED_TOWN_LEVEL = -3; 

		/// <summary>
		 ///失败—居民楼等级不足
		 /// </summary>
		public const int BUILD_RESULT_FAIL_NEED_HOUSE_LEVEL = -4; 

		/// <summary>
		 ///失败—声望不足
		 /// </summary>
		public const int BUILD_RESULT_FAIL_NEED_EXP = -5; 

		/// <summary>
		 ///失败—生态不足
		 /// </summary>
		public const int BUILD_RESULT_FAIL_NEED_STD_A = -6; 

		/// <summary>
		 ///失败—休闲不足
		 /// </summary>
		public const int BUILD_RESULT_FAIL_NEED_STD_B = -7; 

		/// <summary>
		 ///失败—文化不足
		 /// </summary>
		public const int BUILD_RESULT_FAIL_NEED_STD_C = -8; 

		/// <summary>
		 ///失败—食物产量不足
		 /// </summary>
		public const int BUILD_RESULT_FAIL_NEED_FOOD_PPM = -9; 

		/// <summary>
		 ///未可见
		 /// </summary>
		public const int FORMULA_INVISIBLE = -1; 

		/// <summary>
		 ///可激活
		 /// </summary>
		public const int FORMULA_ACTIVATABLE = 0; 

		/// <summary>
		 ///已激活
		 /// </summary>
		public const int FORMULA_ACTIVATED = 1; 


}
}