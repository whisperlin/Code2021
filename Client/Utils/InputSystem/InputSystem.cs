using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// 鼠标触摸输入统一管理
/// </summary>
public class InputSystem  
{
    public static Camera CurCamera {
        get {
            if (null == curCamera)
            {
                curCamera = Common.GetMainCamera();
            }
            return curCamera;
        }
        set {
            curCamera = value;
        }
    }
    public static void IgornNextClick()
    {
        down_pos.x += 0.001f;
        _isSigneFingleClick = false;
    }
    public static GameObject igornObject = null;
 
    static Ray ray;
    static bool isRayCreated = false;

    static Camera curCamera;

    static Vector3 cur_pos;
    static Vector3 _lastPosition;
    static Vector3 down_pos;
    /// <summary>
    /// 按着
    /// </summary>
    private static bool _isSigneFinglePress = false;

    /// <summary>
    /// 按下
    /// </summary>
    private static bool _isSigneFingleDown = false;
    /// <summary>
    /// 点击
    /// </summary>
    private static bool _isSigneFingleClick = false;

    static bool isDown = false;
    public static void OnPointerDown()
    {
        isDown = true;
    }

    public static void OnPointerUp()
    {
        
    }


    /// <summary>
    /// 
    /// </summary>
    private static bool _lastSigneFinglePress = false;


    private static bool _isMoveing = false;

     
    static int clickCounter = 0;
    public static void Clicked()
    {
        clickCounter = 1;
    }
    static int dragCounter = 0;
    public static void Dragged()
    {
        dragCounter = 1;
    }
    static int endDragCount = 0;
    static bool isEndDrag = false;
    public static bool IsEndDrag()
    {
        return isEndDrag;
    }

    public static void OnEndDrag()
    {
        endDragCount = 1;  
    }
    static int beginDragCount = 0;
    static bool isBeginDrag = false;
    public static void OnBeginDrag()
    {
        beginDragCount = 1;
    }
    public static bool IsBeginDrag()
    {
        return isBeginDrag;
    }
    /// <summary>
    /// 每帧逻辑执行之前先调用。
    /// </summary>
    public static void Reset()
    {
        _lastSigneFinglePress = _isSigneFinglePress;
         
        isRayCreated = false;

        _lastPosition = cur_pos;
        cur_pos = GetMousePosition();
        _isSigneFingleClick = clickCounter > 0;

        clickCounter = 0;
        _isMoveing = dragCounter>0;
        dragCounter = 0;
        isEndDrag = endDragCount > 0;
        endDragCount = 0;
        isBeginDrag = beginDragCount > 0;
        beginDragCount = 0;
        _isSigneFingleDown = isDown;
        isDown = false;
        if (_isSigneFingleDown)
        {
            down_pos = cur_pos;
        }
    }

    /// <summary>
    /// 点击
    /// </summary>
    /// <returns></returns>
    public static bool IsFirstFingerDown()
    {
        return _isSigneFingleDown;
         
    }

    public static bool IsFirstFingerClick()
    {
        return _isSigneFingleClick;
    }
     
    public static bool IsDragging()
    {
        return _isMoveing;
    }

    /// <summary>
    /// 获取射线
    /// </summary>
    /// <returns>射线</returns>
    public static Ray GetRay( )
    {
        if (!isRayCreated)
        {
            ray = GetRay(CurCamera);
            isRayCreated = true;
        }
            
        return ray;
    }
    /// <summary>
    /// 获取射线
    /// </summary>
    /// <param name="cam">射线</param>
    /// <returns></returns>
    public static Ray  GetRay( Camera cam)
    {
        Ray r;
        if (Application.platform == RuntimePlatform.Android ||
                        Application.platform == RuntimePlatform.IPhonePlayer)
        {
            r = cam.ScreenPointToRay(Input.GetTouch(0).position);
        }
        else
        {
            r = cam.ScreenPointToRay(Input.mousePosition);
        }
        return r;
    }

    public static Vector3 GetMousePosition()
    {
        if (Application.platform == RuntimePlatform.Android ||
                        Application.platform == RuntimePlatform.IPhonePlayer)
        {
            if (Input.touchCount > 0)
            {
                return new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 0f);
            }
            else
            {
                return Vector3.zero;
            }
            
        }
        else
        {
            return Input.mousePosition;
        }
    }
    const string windowAxis = "Mouse ScrollWheel";
    const float ANDROID_SCALE = 1f;
    const float finalAndroidScale = 0.001f;
    /// <summary>
    /// 获取跨平台缩放操作
    /// </summary>
    /// <returns>返回缩放值</returns>
    public static float ScaleDelta()
    {
        if (Application.platform == RuntimePlatform.Android ||
                        Application.platform == RuntimePlatform.IPhonePlayer)
        {
            if (Input.touchCount == 2 )
            {
                Touch t0 = Input.GetTouch(0);
                Touch t1 = Input.GetTouch(1);
 
                if (t0.phase == TouchPhase.Moved || t1.phase == TouchPhase.Moved)
                {
                    float distance = Vector2.Distance(t0.position, t1.position);
                    Vector2 p0 = t0.phase == TouchPhase.Moved ? t0.position - t0.deltaPosition : t0.position;
                    Vector2 p1 = t1.phase == TouchPhase.Moved ? t1.position - t1.deltaPosition : t1.position;
                    float distance2 = Vector2.Distance(p0, p1);
                    return finalAndroidScale * (distance - distance2);
                }
            }
            return 0f;
        }
        else
        {
            return Input.GetAxis(windowAxis);
        }

    }

    /*public static bool isFirstFingerPress()
    {
        return _isSigneFinglePress;
    }*/


    public static Vector3 MoveDelta()
    {
        if (Application.platform == RuntimePlatform.Android ||
                        Application.platform == RuntimePlatform.IPhonePlayer)
        {
            if (Input.touchCount == 1)
            {
                Touch t0 = Input.GetTouch(0);
                if (t0.phase == TouchPhase.Moved  )
                {
                    return t0.deltaPosition * ANDROID_SCALE;
                }
            }
            return Vector3.zero;
        }
        else
        {
            return   cur_pos- _lastPosition;
        }

    }

}
