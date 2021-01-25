using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 字段类型枚举
 * 
 * @author Seraph.Yang
 * 
 */
public enum FieldType
{
    /**
	 * 布尔值
	 */
    eBoolean,
    /**
	 * 字符 (1字节)
	 */
    eByte,
    /**
	 * 8位数字 -32767至32767 (2字节)
	 */
    eShort,
    /**
	 * 整形 (4字节)
	 */
    eInt,
    /**
	 * 64位整形 (8字节)
	 */
    eLong,
    /**
	 * 定长字符串 (手动定长度)
	 */
    eFixedStr,
    /**
	 * 不定长字符串 (自动定长度)
	 */
    eStr,
    /**
	 * 浮点
	 */
    eFloat,
    /**
	 * 双精度浮点
	 */
    eDouble,
    /**
	 * 日期类型
	 */
    eDate,
    /**
	 * 时间类型
	 */
    eTime,
    /**
	 * 时间与日期
	 */
    eDateTime,

    eList
}