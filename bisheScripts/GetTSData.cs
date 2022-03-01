using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures.TransformGestures;

public class GetTSData : MonoBehaviour
{
    public void GetTouchScriptDate(TransformGesture screenTransformGesture)
    {
        print("�ƶ���λ��: " + screenTransformGesture.DeltaPosition); //�ƶ���λ��
        print("��ת�ĽǶ�: " + screenTransformGesture.DeltaRotation); //��ת�ĽǶ�
        print("���ŵĴ�С: " + screenTransformGesture.DeltaScale); //���ŵĴ�С
        //this.transform.localPosition += screenTransformGesture.DeltaPosition;//ƽ��
        Vector3 camaraPosition = GameObject.Find("Main Camera").transform.position;//��ǰ����ͷλ��
        float old_distance = this.transform.localPosition.z-camaraPosition.z;
        float new_distance = 1 / screenTransformGesture.DeltaScale * old_distance;
        float new_z = new_distance + camaraPosition.z;
        float change_z = new_z - this.transform.localPosition.z;
        Vector3 change_position = screenTransformGesture.DeltaPosition + new Vector3(0f, 0f, change_z);
        this.transform.localPosition += change_position;

        //this.transform.localScale -= new Vector3(1 - screenTransformGesture.DeltaScale, 1 - screenTransformGesture.DeltaScale, 1 - screenTransformGesture.DeltaScale);
    }

}
