using UnityEngine;
using UnityEngine.EventSystems;

public class UITip : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
 
    [Label("目标")]
    public RectTransform target;

    [Label("显示时的父节点")]
    public Transform targetParent;
    //[Label("画布")]
    private Canvas canvas;
    [Label("相机")]
    public Camera cam;
    [Label("手指旁边出现")]
    public bool modifyPosition = true;
    [Label("离手指偏移量", "modifyPosition")]
    public Vector2 offset = new Vector2(100, 0);


    Transform myParent;

    private void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        if (null == cam)
            cam = Camera.main;
        target.gameObject.SetActive(false);
    }
    
    
    //Detect current clicks on the GameObject (the one with the script attached)
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        if (null != target)
        {
            target.gameObject.SetActive(true);

            if (modifyPosition)
            {

                target.anchoredPosition3D = Input.mousePosition;
                target.anchoredPosition = target.anchoredPosition  / canvas.scaleFactor + offset* canvas.scaleFactor;
                
            }
            myParent = target.parent;
            if (null != targetParent)
            {
                target.parent = targetParent;
            }
        }
       
    }

    //Detect if clicks are no longer registering
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        if (null != target)
        {
            target.gameObject.SetActive(false);
            target.parent = myParent;
        }
    }
   
     
}
 