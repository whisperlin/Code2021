using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[ExecuteInEditMode]
[RequireComponent(typeof(RectTransform))]
public class ListBar : MonoBehaviour
{

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



    List<GridItem> activeIitems = new List<GridItem>();

#if ART_PROJECT
    [System.NonSerialized]
    public bool editorItem = false;

#endif
    public List<GridItem> GetItems()
    {
        return activeIitems;
    }

    public void Resize(int count)
    {

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

        if (null != Item)
        {
#if ART_PROJECT
            if (editorItem)
            {
                Item.gameObject.SetActive(true);

                for (int i = 0; i < items.Count; i++)
                {
                    GridItem gi = items[i];
                    RectTransform t = gi.rt;
                    t.gameObject.SetActive(false);
                }
                return;
            }
#endif
            int totalCount = count;

            activeIitems.Clear();
            Item.anchorMax = Item.anchorMin = new Vector2(0f, 1f);
            Item.pivot = new Vector2(0f, 1f);

            Item.gameObject.SetActive(false);
            Vector2 delta = Item.sizeDelta + space;
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
            Vector2 curPos = beginPos;

            for (int i = 0; i < items.Count; i++)
            {
                GridItem gi = items[i];
                RectTransform t = gi.rt;
                t.anchoredPosition = curPos;
                curPos.x += delta.x;

                gi.extend = i < count;

                if (i < totalCount)
                {
                    activeIitems.Add(gi);
                }
                t.gameObject.SetActive(i < totalCount);
            }
            contain.sizeDelta = new Vector2(curPos.x, contain.sizeDelta.y);
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
