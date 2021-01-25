using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputButtonClickCallBack : MonoBehaviour, IPointerClickHandler
{

    public InputEventCallback onClick = null;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (null != onClick)
            onClick(eventData);
        eventData.Use();
    }

    
     
}
