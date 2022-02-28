using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures.TransformGestures;

public class test_SingleRotate : MonoBehaviour
{
    public void rotate(TransformGesture screenTransformGesture)
    {
        print("��ת���λ��: " + screenTransformGesture.DeltaPosition); //��ת���λ��
        Plane plane = screenTransformGesture.TransformPlane;
        print("��תƽ��: " + plane);
        Vector3 axis = Vector3.Cross(new Vector3(0, 0, 1), screenTransformGesture.DeltaPosition);
        print("��ת��: " + axis);
        float distance = screenTransformGesture.DeltaPosition.sqrMagnitude;//λ�Ƶĳ���
        print("��ת��λ�Ƶĳ���: " + distance);
        float angle = -360 * distance;
        Quaternion rotation = Quaternion.AngleAxis(45, axis);
        //this.transform.localRotation = rotation;
        this.transform.Rotate(axis, angle);
    }
}
