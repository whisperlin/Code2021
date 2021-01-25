using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(RectTransform))]
public class UIFellowWorldPosition : MonoBehaviour
{
    public Transform target;  
    RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Camera cam = null;
    public Camera camUI = null;
    public void SetWorldPosiotn(Vector3 pos0)
    {
        if(null== rectTransform)
            rectTransform = GetComponent<RectTransform>();
        
        if (cam==null)
        {
            cam = Common.GetMainCamera();
        }
        if (camUI == null)
        {
            camUI = Common.GetUICamera();
        }
        Vector3 pos = cam.WorldToScreenPoint(pos0);
        Vector3 worldPos = Vector3.zero;
        UnityEngine.RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, pos, camUI, out worldPos);
        transform.position = worldPos;
    }
    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            SetWorldPosiotn(target.position);
        }
    }
}
