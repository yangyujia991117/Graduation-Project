using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures.TransformGestures;

public class GetTSData : MonoBehaviour
{
    public void GetTouchScriptDate(TransformGesture screenTransformGesture)
    {
        print("移动的位置: " + screenTransformGesture.DeltaPosition); //移动的位置
        print("旋转的角度: " + screenTransformGesture.DeltaRotation); //旋转的角度
        print("缩放的大小: " + screenTransformGesture.DeltaScale); //缩放的大小
        //this.transform.localPosition += screenTransformGesture.DeltaPosition;//平移
        Vector3 camaraPosition = GameObject.Find("Main Camera").transform.position;//当前主镜头位置
        float old_distance = this.transform.localPosition.z-camaraPosition.z;
        float new_distance = 1 / screenTransformGesture.DeltaScale * old_distance;
        float new_z = new_distance + camaraPosition.z;
        float change_z = new_z - this.transform.localPosition.z;
        Vector3 change_position = screenTransformGesture.DeltaPosition + new Vector3(0f, 0f, change_z);
        this.transform.localPosition += change_position;

        //this.transform.localScale -= new Vector3(1 - screenTransformGesture.DeltaScale, 1 - screenTransformGesture.DeltaScale, 1 - screenTransformGesture.DeltaScale);
    }

}
