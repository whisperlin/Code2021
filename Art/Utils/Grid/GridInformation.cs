using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionData
{
    public Vector3 pos;
    public Vector3 forward;
}
[ExecuteInEditMode]
public class GridInformation : MonoBehaviour
{
    public int id = 0;
    public Vector2Int size;
    public Transform[] cells;
    public Transform cellsNode;
    [Range(1f, 5f)]
    public float cellWidth = 1;
    public Vector3 AxisX;
    public Vector3 AxisY;
    public Vector3 basePositoin;
    public void MakeCoordinateSystem()
    {
        basePositoin = cells[0].position;
        AxisX = cells[1 + 0 * size.x].position - cells[0 + 0 * size.x].position;
        AxisY = cells[0 + 1 * size.x].position - cells[0 + 0 * size.x].position;
    }
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (null == cloneGamObject && cells.Length == size.x* size.y)
        {
            for (int i = 0; i < size.x; i++)
            {
                for (int j = 0; j < size.y; j++)
                {
                    Transform t = cells[i + j * size.x];
                    if (null != t && t.gameObject.activeSelf)
                    {
                        Vector3 _size = new Vector3(cellWidth, 0.1f, cellWidth);
                        BoxCollider bc = t.GetComponent<BoxCollider>();
                        if (null == bc)
                            bc = t.gameObject.AddComponent<BoxCollider>();
                        bc.center = Vector3.zero;
                        bc.size = _size;

                        Gizmos.matrix = t.localToWorldMatrix;
                        Gizmos.color = new Color(0f,0f,1f,0.5f);
                        Gizmos.DrawCube(Vector3.zero, _size);
                   
                      
                    }
                    //if (null != cells[i + j * size.x])
                    //    cells[i + j * size.x].localPosition = new Vector3(beginX - cellWidth * i, 0, beginY - cellWidth * j);
                }
            }
        }
    }
#endif
    

    /// <summary>
    /// 这个不序列化，unity无法序列化二维以上数组
    /// </summary>

    public Transform[,] grids;
    public BoxCollider[,] colliders;
    public void InitGrid(bool horizontalInv = false, bool verticalInv = false, bool disableToNull = false, float boxColliderHeight = -1f)
    {
        grids = new Transform[size.x, size.y];
        if (boxColliderHeight > 0)
        {
            colliders = new BoxCollider[size.x, size.y];
        }
        else
        {
            colliders = null;
        }
#if !ART_PROJECT
        BoxCollider pbc;
#endif
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                var t = cells[i + j * size.x];
                if (!t.gameObject.activeSelf && disableToNull)
                {
                    t = null;
                }
                if (horizontalInv && verticalInv)
                {
                    grids[size.x - 1 - i, size.y - 1 - j] = t;
#if !ART_PROJECT
                    pbc = colliders[size.x - 1 - i, size.y - 1 - j] = Common.GetComponent<BoxCollider>(t.gameObject);
#endif
                }
                else if (horizontalInv)
                {
                    grids[size.x - 1 - i, j] = t;
#if !ART_PROJECT
                    pbc = colliders[size.x - 1 - i, j] = Common.GetComponent<BoxCollider>(t.gameObject);
#endif
                }
                else if (verticalInv)
                {
                    grids[i, size.y - 1 - j] = t;
#if !ART_PROJECT
                    pbc = colliders[i, size.y - 1 - j] = Common.GetComponent<BoxCollider>(t.gameObject);
#endif
                }
                else
                {
#if !ART_PROJECT
                    grids[i, j] = t;
                    pbc = colliders[i, j] = Common.GetComponent<BoxCollider>(t.gameObject);
#endif

                }
#if !ART_PROJECT
                pbc.size = new Vector3(cellWidth, boxColliderHeight, cellWidth);
#endif
            }
        }


    }



    public Vector3 GetPosition(Vector2 pos)
    {
        return basePositoin + AxisX * pos.x + AxisY * pos.y;
    }
    public Vector3 GetForward(Vector2 position)
    {
        int y = (int)position.y;
        if (y < size.y / 2)
        {
            return cells[0].transform.forward;
        }
        else
        {
            return -cells[0].transform.forward;
        }
    }

    public void Resize(bool notCloneChild = false)
    {
        if (null != cells)
        {
            for (int i = 0; i < cells.Length; i++)
            {
                if (null != cells[i] && null != cells[i].gameObject)
                    GameObject.DestroyImmediate(cells[i].gameObject);
            }
        }

        cells = new Transform[size.x * size.y];
        if (null == cellsNode)
        {
            cellsNode = transform.Find("cells");
            if (cellsNode == null)
            {
                GameObject cells = new GameObject("cells");
                cells.transform.parent = transform;
                cellsNode = cells.transform;
            }
        }

        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                GameObject p = new GameObject("cell_" + i + "_" + j);
                p.transform.parent = cellsNode;
#if UNITY_EDITOR
                if (null != cloneGamObject)
                {
                    if (!notCloneChild)
                    {
                        GameObject s = GameObject.Instantiate(cloneGamObject);
                        s.transform.parent = p.transform;
                        s.transform.localPosition = Vector3.zero;
                    }
                }
#endif
                if (j > size.y / 2 - 1)
                {
                    p.transform.forward = Vector3.forward;
                }
                else
                {
                    p.transform.forward = Vector3.back;
                }
                cells[i + j * size.x] = p.transform;


            }
        }
        UpdateCellPosition();
    }
    public void UpdateCellPosition()
    {
        float beginX = cellWidth * (size.x - 1) * 0.5f;
        float beginY = cellWidth * (size.y - 1) * 0.5f;
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                if (null != cells[i + j * size.x])
                    cells[i + j * size.x].localPosition = new Vector3(beginX - cellWidth * i, 0, beginY - cellWidth * j);
            }
        }
    }
#if UNITY_EDITOR
    public GameObject cloneGamObject;
    private float oldWrdth = -1;

    private void Update()
    {

        if (oldWrdth != cellWidth)
        {
            oldWrdth = cellWidth;
            UpdateCellPosition();
        }

    }
 
    public void ShowExampleType()
    {
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                var t = cells[i + j * size.x];
                for (int k = 0; k < t.childCount; k++)
                {
                    t.GetChild(k).gameObject.SetActive(
                        ((j < 3 || j >= size.y - 3) && (i != 0 && i != size.x - 1) && (j != 0 && j != size.y - 1))

                        || (i == 0 && j == 0)
                        || (i == 0 && j == size.y - 1)
                        || (i == size.x - 1 && j == 0)
                        || (i == size.x - 1 && j == size.y - 1)


                        );
                }
            }
        }
    }
#endif

    public void ShowAllChild()
    {

        //cellsNode.gameObject.SetActive(true);
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                var t = cells[i + j * size.x];
                for (int k = 0; k < t.childCount; k++)
                {
                    t.GetChild(k).gameObject.SetActive(true);
                }
            }
        }
    }
    public void HideAllChild()
    {

        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                var t = cells[i + j * size.x];
                for (int k = 0; k < t.childCount; k++)
                {
                    t.GetChild(k).gameObject.SetActive(false);
                }
            }
        }
    }

    public void RemoveAllChild()
    {
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                var t = cells[i + j * size.x];
                for (int k = t.childCount - 1; k >= 0; k--)
                {
                    GameObject.Destroy(t.GetChild(k).gameObject);
                }
            }
        }
    }

    public void SetLayer(int layer)
    {
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                var t = cells[i + j * size.x];
                t.gameObject.layer = layer;
            }
        }
    }
}
