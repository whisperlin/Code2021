using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LEventType
{
   Town,
    FOOD_DACROEY_UPDATA,
    /// <summary>
    /// 更新居民楼信息
    /// </summary>
    HOUSE_INFOR_UPDATE,
    /// <summary>
    /// 宠物站位列表
    /// </summary>
    FORMATION_LIST_UPDATE,
    /// <summary>
    /// 更新宠物列表.
    /// </summary>
    PET_LIST_UPDATE,
    TOWN_DATE_DIRTY,
    TOWN_DATA_DYNAMICDIRTY,
    /// <summary>
    /// 配方列表.
    /// </summary>
    FORMULA_INFO_UPDATE,
    ITEM_UPDATE,
    STREET_UPDATE,
    EXPEDITION_UPDATE,
    EXPEDITION_ITEMS_UPDATE,
    WALK_ERROR,
    CHAPTER_PET_LIST_UPDATE,
    CHAPTER_TASK_LIST_UPDATA,
    RECONNECT_CHAPTER,
    GAME_POINTER_DOWN,
    /// <summary>
    /// 重置所有角色缩放
    /// </summary>
    RESET_ALL_SCALE = 1000,
 
}
public delegate void EventFloat( float p);
public delegate void EventInt(  int p);
 
public delegate void EventNoParam() ;
public delegate void EventObject(object p);
public class LEventSystem 
{

    static Dictionary<LEventType, EventFloat> floatEvent = new Dictionary<LEventType, EventFloat>();
 
    static Dictionary<LEventType, EventInt> intEvent = new Dictionary<LEventType, EventInt>();
    static Dictionary<LEventType, EventNoParam> voidEvent = new Dictionary<LEventType, EventNoParam>();
    static Dictionary<LEventType, EventObject> objectEvent = new Dictionary<LEventType, EventObject>();


    public static void AddObjectEvent(LEventType e, EventObject fun)
    {
        EventObject ef;
        if (objectEvent.TryGetValue(e, out ef))
        {
            ef += fun;
            objectEvent[e] = ef;
        }
        else
        {
            objectEvent[e] = fun;
        }
    }

    public static void RemoveObjectEvent(LEventType e, EventObject fun)
    {
        EventObject ef;
        if (objectEvent.TryGetValue(e, out ef))
        {
            ef -= fun;
            objectEvent[e] = ef;
        }
    }
    public static void CallObjectEvent(LEventType e, object v)
    {
        EventObject ef;
        if (objectEvent.TryGetValue(e, out ef))
        {
            ef.Invoke(v);
        }
    }

    public static void AddFloatEvent(LEventType e, EventFloat fun)
    {
        EventFloat ef;
        if (floatEvent.TryGetValue(e, out ef))
        {
            ef += fun;
            floatEvent[e] = ef;
        }
        else
        {
            floatEvent[e] = fun;
        }
    }

    public static void RemoveFloatEvent(LEventType e, EventFloat fun)
    {
        EventFloat ef;
        if (floatEvent.TryGetValue(e, out ef))
        {
            ef -= fun;
            floatEvent[e] = ef;
        }
    
    }

    public static void CallFloatEvent(LEventType e, float v)
    {
        EventFloat ef;
        if (floatEvent.TryGetValue(e, out ef))
        {
            if (null != ef)
                ef(v);
        }
    }



    public static void AddIntEvent(LEventType e, EventInt fun)
    {
        EventInt ef;
        if (intEvent.TryGetValue(e, out ef))
        {
            ef += fun;
            intEvent[e] = ef;
        }
        else
        {
            intEvent[e] = fun;
        }
    }

    public static void RemoveIntEvent(LEventType e, EventInt fun)
    {
        EventInt ef;
        if (intEvent.TryGetValue(e, out ef))
        {
            ef -= fun;
            intEvent[e] = ef;
        }
      
    }

    public static void CallIntEvent(LEventType e, int v)
    {
        EventInt ef;
        if (intEvent.TryGetValue(e, out ef))
        {
            if(null != ef)
                ef(v);
        }
    }

    public static void AddEvent(LEventType e, EventNoParam fun)
    {
        EventNoParam ef;
        if (voidEvent.TryGetValue(e, out ef))
        {
            ef += fun;
            voidEvent[e] = ef;
        }
        else
        {
            voidEvent[e] = fun;
        }
    }

    public static void RemoveEvent(LEventType e, EventNoParam fun)
    {
        EventNoParam ef;
        if (voidEvent.TryGetValue(e, out ef))
        {
            ef -= fun;
            voidEvent[e] = ef;
        }
         
    }

    public static void CallEvent(LEventType e )
    {
        EventNoParam ef;
        if (voidEvent.TryGetValue(e, out ef))
        {
            try
            {
                if(null != ef)
                    ef.Invoke();
            }
            catch (System.Exception ee)
            {
                Debug.LogError(ee.ToString());
                Debug.LogError(e);
            }
            
        }
    }

 

    //voidEvent



}
