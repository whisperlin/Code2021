using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


 
public class IMouseCallback : MonoBehaviour, IDragHandler, IPointerClickHandler , IBeginDragHandler , IEndDragHandler
{

    public InputEventCallback OnDragFun = null;
    public void OnDrag(PointerEventData eventData)
    {
        if (null != OnDragFun)
        {
            OnDragFun(eventData);
        }
    }
    public InputEventCallback onClick = null;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.dragging)
            return;
        if (null != onClick)
        {
            onClick(eventData);
        }
    }


    public InputEventCallback onBeginDrag = null;
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (null != onBeginDrag)
        {
            onBeginDrag(eventData);
        }
    }
    public InputEventCallback onEndDrag = null;
    public void OnEndDrag(PointerEventData eventData)
    {
        if (null != onEndDrag)
        {
            onEndDrag(eventData);
        }
    }
}
