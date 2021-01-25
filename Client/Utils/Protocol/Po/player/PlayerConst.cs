namespace com.hbt.protocol.po.player{

public class PlayerConst{

		/// <summary>
		 ///账号正常
		 /// </summary>
		public const int STATUS_NORMAL = 0; 

		/// <summary>
		 ///登录失败
		 /// </summary>
		public const int STATUS_LOGIN_ERROR = 1; 

		/// <summary>
		 ///账号冻结（机器检测自动冻结）
		 /// </summary>
		public const int STATUS_FROZEN_AUTO = 2; 

		/// <summary>
		 ///账号冻结（操作员手动）
		 /// </summary>
		public const int STATUS_FROZEN_MANUAL = 3; 

		/// <summary>
		 ///账号冻结（欠费）
		 /// </summary>
		public const int STATUS_FROZEN_OWE = 4; 

		/// <summary>
		 ///账号修复中
		 /// </summary>
		public const int STATUS_UNDER_FIX = 10; 

		/// <summary>
		 ///成功改名
		 /// </summary>
		public const int RENAME_RESULT_SUCCESS = 1; 

		/// <summary>
		 ///改名失败—没货币
		 /// </summary>
		public const int RENAME_RESULT_FAIL_NORES = -1; 

		/// <summary>
		 ///改名失败—冷却时间不够
		 /// </summary>
		public const int RENAME_RESULT_FAIL_TIME_CD = -2; 

		/// <summary>
		 ///改名失败—其他
		 /// </summary>
		public const int RENAME_RESULT_FAIL_OTHER = 0; 


}
}