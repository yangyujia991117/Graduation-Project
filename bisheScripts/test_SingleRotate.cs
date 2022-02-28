using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures.TransformGestures;

public class test_SingleRotate : MonoBehaviour
{
    public void rotate(TransformGesture screenTransformGesture)
    {
        print("旋转点的位移: " + screenTransformGesture.DeltaPosition); //旋转点的位移
        Plane plane = screenTransformGesture.TransformPlane;
        print("旋转平面: " + plane);
        Vector3 axis = Vector3.Cross(new Vector3(0, 0, 1), screenTransformGesture.DeltaPosition);
        print("旋转轴: " + axis);
        float distance = screenTransformGesture.DeltaPosition.sqrMagnitude;//位移的长度
        print("旋转点位移的长度: " + distance);
        float angle = -360 * distance;
        Quaternion rotation = Quaternion.AngleAxis(45, axis);
        //this.transform.localRotation = rotation;
        this.transform.Rotate(axis, angle);
    }
}
