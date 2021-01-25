using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

 
[ExecuteInEditMode]
public class SceneGridInformation : MonoBehaviour
{
    public int id = 0;
    public Vector2Int size;
    public Transform[] cells;
    public Transform cellsNode;
    [Range(1f, 5f)]
    public float cellWidth = 1;
    public Vector3 AxisX;
    public Vector3 AxisY;
    public void MakeCoordinateSystem()
    {
        AxisX = cells[1 + 0 * size.x].position - cells[0 + 0 * size.x].position;
        AxisY = cells[0 + 1 * size.x].position - cells[0 + 0 * size.x].position;
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


    public void Resize()
    {
        if (null != cells)
        {
            for (int i = 0; i < cells.Length; i++)
            {
                if (null != cells[i])
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
                if (null != cloneGamObject)
                {
                    GameObject s = GameObject.Instantiate(cloneGamObject);
                    s.transform.parent = p.transform;
                    s.transform.localPosition = Vector3.zero;
                }
                p.transform.forward = Vector3.forward;
                cells[i + j * size.x] = p.transform;


            }
        }
        UpdateCellPosition();
    }

    public void UpdateCellPosition()
    {
        float beginX = -cellWidth * (size.x - 1) * 0.5f;
        float beginY = -cellWidth * (size.y - 1) * 0.5f;
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                cells[i + j * size.x].localPosition = new Vector3(beginX + cellWidth * i, 0, beginY + cellWidth * j);
            }
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

        cellsNode.gameObject.SetActive(true);
         
    }
    public void HideAllChild()
    {

        cellsNode.gameObject.SetActive(false);
    }
}
