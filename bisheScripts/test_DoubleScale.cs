using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures.TransformGestures;

public class test_DoubleScale : MonoBehaviour
{
    public GameObject scaleAndRotationZoom;

    private void Awake()
    {
        scaleAndRotationZoom = GameObject.Find("ScaleAndRotationZoom");
    }
    public void scale(TransformGesture screenTransformGesture)
    {
        print("缩放的大小: " + screenTransformGesture.DeltaScale); //缩放的大小
        Vector3 camaraPosition = GameObject.Find("Main Camera").transform.position;//当前主镜头位置
        float old_distance = this.transform.localPosition.z - camaraPosition.z;
        float new_distance = 1 / screenTransformGesture.DeltaScale * old_distance;
        float new_z = new_distance + camaraPosition.z;
        if (new_z > scaleAndRotationZoom.transform.position.z)
        {
            new_z = scaleAndRotationZoom.transform.position.z;
        }
        this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y,new_z) ;
        
    }
}
