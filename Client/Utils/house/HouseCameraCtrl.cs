using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class HouseCameraCtrl : MonoBehaviour
{
    [Label("相机")]
    public Camera cam;
    public Camera [] cameras;

    [Label("进度",0f,3f)]
    public float process = 0f;

    float lastProcess = -1f;

    public GameObject topBuilding;

    public float hideTopProcess = 2.1f;
    int index0;
    int index1;
    void UpdateCamreaPos()
    {
        index0 = (int)process ;
        if (index0 >= cameras.Length - 1)
        {
            var _cam = cameras[cameras.Length - 1];
            cam.transform.position = _cam.transform.position;
            cam.transform.transform.rotation = _cam.transform.rotation;
            cam.fieldOfView = _cam.fieldOfView;
            topBuilding.SetActive(false);
        }
        else
        {
            index1 = index0 + 1;
            float t = process % 1f;
            cam.transform.position = Vector3.Lerp(cameras[index0].transform.position, cameras[index1].transform.position, t);
            cam.transform.transform.rotation = Quaternion.Slerp(cameras[index0].transform.rotation, cameras[index1].transform.rotation, t);
            cam.fieldOfView = Mathf.Lerp(cameras[index0].fieldOfView, cameras[index1].fieldOfView, t);
            topBuilding.SetActive(process< hideTopProcess);
        }
 
        
    }
    private void Start()
    {
        cameras[0].transform.parent.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (lastProcess != process)
        {
            UpdateCamreaPos();
            lastProcess = process;
        }
    }
}
