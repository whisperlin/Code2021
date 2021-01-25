using System.Collections;
using System.Collections.Generic;
using UnityEngine;



using UnityEngine.EventSystems;
public delegate void InputEventCallback(PointerEventData eventData);
public class InputCallback : MonoBehaviour, IPointerClickHandler


{
    public InputEventCallback onClick=null;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (null != onClick)
            onClick(eventData);
        eventData.Use();
    }
}
 
