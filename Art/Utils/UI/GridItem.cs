﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridItem : MonoBehaviour
{
    public int index;
    /// <summary>
    /// 用户数据
    /// </summary>
    public int userData;
    /// <summary>
    /// 这个会产生boxing，每帧循环慎用
    /// </summary>
    public System.Object userdataObj;
    public bool extend = false;
    public RectTransform rt;

}
