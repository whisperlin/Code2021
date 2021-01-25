using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public int value = 130;
    public int maxValue = 200;
    public float speed = 0.03f;
 
    int oldValue = 0;
    int oldMaxNum = 0;
 
    public Image background;
    public Image bar;
    public Image barUpper;
    public int borderSize = 2;
    public bool igornNextAnimaiton = false;
    int maxWidth;
    int maxHight;
    RectTransform root;
    RectTransform tbar0;
    RectTransform tbar1;

    public HealthBar bar2 = null;


    Vector2 baseSize0;

    

    public void SetWorldPosiotn(Vector3 pos0)
    {
        Vector3 pos = HealthbarManager.instance.cam.WorldToScreenPoint(pos0);
        Vector3 worldPos = Vector3.zero;
        UnityEngine.RectTransformUtility.ScreenPointToWorldPointInRectangle(root, pos, null, out worldPos);
        transform.position = worldPos;
    }
     

    Color IntToColor(int v)
    {
        return Color.HSVToRGB(0.1f * (v % 10), 1f-(v/10)*0.1f , 1f);
    }
    void Start()
    {
        root = background.rectTransform;

        if (null != bar)
        {
            tbar0 = bar.rectTransform;
            baseSize0 = tbar0.sizeDelta;
        }
        tbar1 = barUpper.rectTransform;
        
        //colors.Add(IntToColor(colors.Count));
    }
    int MoveTo(int src,int dest )
    {
        if (igornNextAnimaiton)
        {
            igornNextAnimaiton = false;
            return dest;
        }
        int delta = dest - src;
        int delte0 = (int)(speed*delta);
        if (Mathf.Abs(delte0) < 1)
        {
            delte0 = (int)(Mathf.Sign(delta)*1.1f);
        }
        return src+delte0;
    }
    // Update is called once per frame
    void Update()
    {
        if (value < 0)
            value = 0;
        if (oldValue != value || oldMaxNum != maxValue )
        {
            oldMaxNum = maxValue;
            oldValue = MoveTo(oldValue,value);
            int c = oldValue   ;
            float v0 = ((float)oldValue   ) / maxValue;
            float v1 = ((float)value) / maxValue;
            if(null != tbar0)
                tbar0.sizeDelta = new Vector2(baseSize0.x * v0, baseSize0.y);
            if (null != tbar1)
                tbar1.sizeDelta = new Vector2(baseSize0.x * v1, baseSize0.y);
        }
    }
}
