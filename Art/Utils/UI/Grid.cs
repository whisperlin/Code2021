using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[ExecuteInEditMode]
[RequireComponent(typeof(RectTransform))]
public class Grid : MonoBehaviour
{
    [Label("不足整行时是否不足")]
    public bool holdLine = true;
    public RectTransform Item;
    private int count = 0;
    public Vector2 space = new Vector2(5f, 5f);

    public int Count
    {
        get
        {
            return count;
        }
        set
        {
            count = value;
        }
    }
    [System.NonSerialized]
    List<GridItem> items = new List<GridItem>();
    [System.NonSerialized]
    public RectTransform oldItem = null;
    [System.NonSerialized]
    private RectTransform contain = null;

    private RectTransform scrollContain = null;

    public RectTransform sizeContain = null;
    public bool isHexagonal = false;
    List<GridItem> activeIitems = new List<GridItem>();


#if ART_PROJECT
    [System.NonSerialized]
    public bool editorItem = false;

#endif
    int forceRowCount = -1;
    public List<GridItem> GetItems()
    {
        return activeIitems;
    }
    /// <summary>
    /// 一行有多少个格子。
    /// </summary>
    /// <returns></returns>
    public int GetRowtemCount()
    {
        if (null == Item)
            return 1;
        if (null == contain)
        {
            contain = GetComponent<RectTransform>();
            scrollContain = contain.parent.GetComponent<RectTransform>();
        }

        Vector2 delta = Item.sizeDelta + space;
        var _rect = scrollContain.rect;
        Vector2 containSize = new Vector2(_rect.width, _rect.height) + space;
        int lineCount = ((int)containSize.x / (int)delta.x);
        return lineCount;
    }
    public void Resize(int count, int forceRowCount = -1)
    {
        this.forceRowCount = forceRowCount;
        if (oldItem != Item)
        {
            Clear();
        }
        if (Item == null)
            return;
        if (null == contain)
        {
            contain = GetComponent<RectTransform>();


        }
        if (contain.rect.width == 0)
        {
            scrollContain = contain.parent.parent.GetComponent<RectTransform>();
        }
        else
        {
            scrollContain = contain; ;
        }
        if (null != Item)
        {
            var _rect = scrollContain.rect;
            Vector2 containSize = new Vector2(_rect.width, _rect.height) + space;
            Vector2 delta = Item.sizeDelta + space;
            int lineCount = ((int)containSize.x / (int)delta.x);
            lineCount = Mathf.Max(1, lineCount);
            if (forceRowCount > 0)
                lineCount = forceRowCount;
            int totalCount = count;
            if (holdLine)
            {
                int n = totalCount / lineCount + (totalCount % lineCount > 0 ? 1 : 0);
                totalCount = lineCount * n;
            }
            activeIitems.Clear();
            Item.anchorMax = Item.anchorMin = new Vector2(0f, 1f);
            Item.pivot = new Vector2(0f, 1f);

            Item.gameObject.SetActive(false);
            for (int i = items.Count; i < totalCount; i++)
            {
                RectTransform rt = GameObject.Instantiate(Item.gameObject).GetComponent<RectTransform>();
#if !ART_PROJECT
                UIHelper.AddOnClick(rt.gameObject, OnItemClick);
#endif
                rt.gameObject.SetActive(true);
                rt.gameObject.hideFlags = HideFlags.DontSave;
                rt.parent = Item.parent;
                rt.transform.localScale = Vector3.one;
                GridItem gi = rt.gameObject.AddComponent<GridItem>();
                gi.rt = rt;
                gi.index = i;
                items.Add(gi);
            }
            Vector3 beginPos = Vector3.zero;
            Vector3 curPos = beginPos;
            int totalLine = 1;
            int lineIndex = 0;
            for (int i = 0; i < items.Count; i++)
            {
                GridItem gi = items[i];
                RectTransform t = gi.rt;
                t.anchoredPosition3D = curPos;
                if (isHexagonal && lineIndex % 2 == 0)
                {
                    t.anchoredPosition3D += Vector3.down * delta.y * 0.5f;
                }
                curPos.x += delta.x;
                lineIndex += 1;
                if (lineIndex >= lineCount)
                {
                    lineIndex = 0;
                    curPos.y -= delta.y;
                    curPos.x = beginPos.x;
                    totalLine++;
                }
                gi.extend = i < count;

                if (i < totalCount)
                {
                    activeIitems.Add(gi);
                }
                t.gameObject.SetActive(i < totalCount);
            }
            contain.sizeDelta = new Vector2(contain.sizeDelta.x, Mathf.Abs(delta.y) * totalLine);
        }
    }
    public delegate void ItemClickFunction(int i);
    public ItemClickFunction itemClick = null;
    private void OnItemClick(PointerEventData eventData)
    {
        var t = eventData.pointerCurrentRaycast.gameObject.transform;
        for (int i = 0; i < items.Count; i++)
        {
            GridItem gi = items[i];
            if (gi.rt == t)
            {
                if (null != itemClick)
                    itemClick(i);
                return;
            }
        }

        for (int i = 0; i < items.Count; i++)
        {
            GridItem gi = items[i];
            if (t.IsChildOf(gi.rt))
            {
                if (null != itemClick)
                    itemClick(i);
                return;
            }
        }
        //var g = eventData.pointerCurrentRaycast.gameObject.transform;


    }

    private void Clear()
    {
        for (int i = 0; i < items.Count; i++)
        {
            GameObject.DestroyImmediate(items[i].gameObject);
        }
        items.Clear();
    }


}
