using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ButtonEX : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    public delegate void OnButtonEXClick(GameObject sender, int userData);
    public Image img;

    public int animDelta = 30;
    public int userData = 0;
    public OnButtonEXClick OnClick = null;


    public float min = 0.8f;
    Vector3 scale;
    Vector3 minScale;
    bool isEnable = true;
    public void Start()
    {
        scale = transform.localScale;

        RectTransform rt = GetComponent<RectTransform>();
        var _s = rt.sizeDelta;
        float _m = Mathf.Max(_s.x, _s.y);
        if (_m > 0 && _m > animDelta)
        {
            float _min = (_m - animDelta) / _m;
            min = Mathf.Max(_min, min);
        }
        minScale = scale * min;
        minScale.z = scale.z;

    }
    public bool isDown = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        isDown = true;
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        isDown = false;
    }

    private void Update()
    {

        if (isDown)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, minScale, 0.05f);
        }
        else
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, scale, 0.05f);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isEnable)
            return;
        if (null != OnClick)
            OnClick(gameObject, userData);
    }


    public void SetEnable(bool b)
    {
        if (b == isEnable)
            return;
        isEnable = b;
        if (isEnable)
        {
            GetImage().color = Color.white;
        }
        else
        {
            GetImage().color = Color.gray;
        }
    }
    public Image GetImage()
    {
        if (null == img)
            img = GetComponent<Image>();
        return img;
    }

    Text text = null;
    public Text GetText()
    {
        if (null == text)
            text = GetComponentInChildren<Text>();
        return text;
    }

    //OnButtonEXClick
}
