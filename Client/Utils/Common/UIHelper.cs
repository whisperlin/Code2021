using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHelper
{

    
    public static void AddOnClick(GameObject g, InputEventCallback d)
    {
        InputCallback iecb = g.GetComponent<InputCallback>();
        if (iecb == null)
            iecb = g.AddComponent<InputCallback>();
        iecb.onClick = d;
    }

    public static void AddOnDown(GameObject g, InputEventCallback d)
    {
        InputButtonClickCallBack iecb = g.GetComponent<InputButtonClickCallBack>();
        if (iecb == null)
            iecb = g.AddComponent<InputButtonClickCallBack>();
        iecb.onClick = d;
    }

    public static void FildList(RectTransform contain, int count, RectTransform c0, RectTransform c1)
    {
        for (int i = contain.childCount, c = count + 2; i < c; i++)
        {
            RectTransform t = GameObject.Instantiate(c0.gameObject).transform as RectTransform;
            t.parent = contain;
            t.localScale = c0.localScale;
        }
        c0.SetAsLastSibling();
        c1.SetAsLastSibling();
 
        RectTransform pContain = contain.parent.parent as RectTransform;
        float containWidth = pContain.rect.width;
        float cellWidth = c0.rect.width;
        Vector2 beginPos = c0.anchoredPosition;
        Vector2 delta = new Vector2(0f, c1.anchoredPosition.y - beginPos.y);
        Vector2 curPos = beginPos;
        for (int i = 0; i < contain.childCount; i++)
        {
            RectTransform t = contain.GetChild(i) as RectTransform;

            if (i < contain.childCount - 2)
            {
                t.gameObject.name = i.ToString();
                t.anchoredPosition = curPos;
                curPos.y += delta.y;
                t.gameObject.SetActive(true);
            }
            else
            {
                t.gameObject.SetActive(false);
            }
        }
    }
    public static void FillGrid(RectTransform contain, int count, RectTransform c0, RectTransform c1, RectTransform c2)
    {
        for (int i = contain.childCount,c = count + 3; i < c; i++)
        {
            RectTransform t = GameObject.Instantiate(c0.gameObject).transform as RectTransform;
            t.parent = contain;
            t.localScale = c0.localScale;
        }
        c0.SetAsLastSibling();
        c1.SetAsLastSibling();
        c2.SetAsLastSibling();
        RectTransform pContain = contain.parent.parent as RectTransform;
        float containWidth = pContain.rect.width;
        float cellWidth = c0.rect.width;
        Vector2 beginPos = c0.anchoredPosition;
        Vector2 delta = new Vector2(c1.anchoredPosition.x - beginPos.x, c2.anchoredPosition.y - beginPos.y);
        Vector2 curPos = beginPos;
        for (int i = 0; i < contain.childCount; i++)
        {
            RectTransform t = contain.GetChild(i) as RectTransform;
            
            if (i < count)
            {
                t.gameObject.name = i.ToString();
                t.anchoredPosition = curPos;
                curPos.x += delta.x;
                if (t.offsetMax.x + cellWidth > containWidth)
                {
                    curPos.y += delta.y;
                    curPos.x = beginPos.x;
                }
                t.gameObject.SetActive(true);

            }
            else
            {
                t.gameObject.SetActive(false);
            }
        }
        contain.sizeDelta = new Vector2(contain.sizeDelta.x, Mathf.Abs(beginPos.y - curPos.y) );
    }
}
