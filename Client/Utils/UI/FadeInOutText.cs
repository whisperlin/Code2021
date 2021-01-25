using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

 
[RequireComponent(typeof(Text))]
public class FadeInOutText : BaseMeshEffect
{


    [Label("淡入淡出比例控制",0.001f,0.3f)]
    public float fadeWidth = 0.1f;
    RectTransform t;


    [Label("滚动字幕进度", 0f, 1f)]
    public float offsetX = 0;

    [Label("文字滚动速度")]
    public float rotSpeed = 100;
    Text txt;
    protected override void Start()
    {
        txt = GetComponent<Text>();
        txt.horizontalOverflow = HorizontalWrapMode.Overflow;
    }

    public float fontLength = 1000f;
    public float ctrlWidth = 1f;
    void Update()
    {
        if(Application.isPlaying)
        {
            if (fontLength > 0)
            {
                float totalTimeLength = rotSpeed / (fontLength+ ctrlWidth);
                if (offsetX < 1f)
                {
                    offsetX += totalTimeLength * Time.deltaTime;
                    txt.SetVerticesDirty();
                }
            }
        }
        
        
    }
    public override void ModifyMesh(VertexHelper helper)
    {
        if (!IsActive())
            return;

        List<UIVertex> verts = new List<UIVertex>();
        helper.GetUIVertexStream(verts);

        Text text = GetComponent<Text>();

        TextGenerator tg = text.cachedTextGenerator;


        int count = text.text.Length;


        List<UILineInfo> lines = new List<UILineInfo>();
        tg.GetLines(lines);
        if (null == t)
            t = GetComponent<RectTransform>();
        ctrlWidth = t.rect.width;
        float w = ctrlWidth;
        
        
        w = w * 0.5f;
        float w1 = w * (1 - fadeWidth);

        
        if (lines.Count > 0)
        {
            int index = tg.characterCountVisible - 1;
            UIVertex lb = new UIVertex();
            helper.PopulateUIVertex(ref lb, index * 4+1+1);
            float beginOffset = lb.position.x ;
            fontLength = beginOffset + w;
            beginOffset = -fontLength;
            float loffsetX = offsetX * (ctrlWidth + fontLength);
            UILineInfo line = lines[0];
            for (int j = line.startCharIdx; j < tg.characterCountVisible; j++)
            {
                modifyText(helper, j, w, w1, beginOffset + loffsetX);
            }
        }
         
        
        

    }

    void modifyText(VertexHelper helper, int i ,float _max, float _min,float _offsetX)
    {
        UIVertex lb = new UIVertex();
        helper.PopulateUIVertex(ref lb, i * 4);

        UIVertex lt = new UIVertex();
        helper.PopulateUIVertex(ref lt, i * 4 + 1);

        UIVertex rt = new UIVertex();
        helper.PopulateUIVertex(ref rt, i * 4 + 2);

        UIVertex rb = new UIVertex();
        helper.PopulateUIVertex(ref rb, i * 4 + 3);

        

        var pos = lb.position;
        pos.x += _offsetX;
        lb.position = pos;


        pos = lt.position;
        pos.x += _offsetX;
        lt.position = pos;


        pos = rt.position;
        pos.x += _offsetX;
        rt.position = pos;

        pos = rb.position;
        pos.x += _offsetX;
        rb.position = pos;

        Color c0 = lb.color;
        float t = LMathf.SmoothStep(_min, _max, Mathf.Abs(lb.position.x));
        c0.a = Mathf.Lerp(c0.a, 0f, t);
        lb.color = c0;

        c0 = lt.color;
        t = LMathf.SmoothStep(_min, _max, Mathf.Abs(lt.position.x));
        c0.a = Mathf.Lerp(c0.a, 0f, t);
        lt.color = c0;


        c0 = rt.color;
        t = LMathf.SmoothStep(_min, _max, Mathf.Abs(rt.position.x));
        c0.a = Mathf.Lerp(c0.a, 0f, t);
        rt.color = c0;

        c0 = rb.color;
        t = LMathf.SmoothStep(_min, _max, Mathf.Abs(rb.position.x));
        c0.a = Mathf.Lerp(c0.a, 0f, t);
        rb.color = c0;


        //Debug.LogError((i * 4 + 3) +" " +rb.position);
        helper.SetUIVertex(lb, i * 4);
        helper.SetUIVertex(lt, i * 4 + 1);
        helper.SetUIVertex(rt, i * 4 + 2);
        helper.SetUIVertex(rb, i * 4 + 3);
    }
}
 