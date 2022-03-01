using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures.TransformGestures;

public class test_scaleWithSelection : MonoBehaviour
{
    public TransformGesture singlePoint;//���㴥��
    public TransformGesture doublePoint;//˫�㴥��

    public GameObject selectedObject;

    public string singlePointDeltaPosition;//��ת���λ��
    public string rotationAxis;//��ת��
    public string rotationAngle;//��ת�ĽǶ�

    void Awake()
    {
        selectedObject = new GameObject("EmptyObject");
        singlePointDeltaPosition = "��";
        rotationAxis = "��";
        rotationAngle = "��";
    }

    public void setSelectedObject(GameObject obj)
    {
        Debug.Log("ѡ����" + obj.name);
        selectedObject = obj;
    }
    private void OnEnable()
    {
        singlePoint.Transformed += singleRotate;//��singlePoint.Transformed����¼�����ʱ�������SingleRotate����
        doublePoint.Transformed += doubleScale;
    }

    private void singleRotate(object sender, System.EventArgs e)
    {
        if (selectedObject.name != "EmptyObject")
        {
            print("��ת���λ��: " + singlePoint.DeltaPosition); //��ת���λ��
            Plane plane = singlePoint.TransformPlane;
            print("��תƽ��: " + plane);
            Vector3 axis = Vector3.Cross(new Vector3(0, 0, 1), singlePoint.DeltaPosition);
            print("��ת��: " + axis);
            float distance = singlePoint.DeltaPosition.sqrMagnitude;//λ�Ƶĳ���
            print("��ת��λ�Ƶĳ���: " + distance);
            float angle = -360 * distance;
            //Quaternion rotation = Quaternion.AngleAxis(45, axis);
            //this.transform.localRotation = rotation;

            singlePointDeltaPosition = singlePoint.DeltaPosition.ToString();
            rotationAxis = axis.ToString();
            rotationAngle = angle.ToString();

            selectedObject.transform.Rotate(axis, angle);
        }
        else
        {
            Debug.Log("û�����屻ѡ��");
        }
    }

    private void doubleScale(object sender, System.EventArgs e)
    {
        if (selectedObject.name != "EmptyObject")
        {
            print("���ŵĴ�С: " + doublePoint.DeltaScale); //���ŵĴ�С
            Vector3 camaraPosition = GameObject.Find("Main Camera").transform.position;//��ǰ����ͷλ��
            float old_distance = selectedObject.transform.localPosition.z - camaraPosition.z;
            float new_distance = 1 / doublePoint.DeltaScale * old_distance;
            float new_z = new_distance + camaraPosition.z;
            if (new_z > this.transform.position.z)
            {
                new_z = this.transform.position.z;//������岻��ȥ������ĺ���
            }
            selectedObject.transform.localPosition = new Vector3(selectedObject.transform.localPosition.x, selectedObject.transform.localPosition.y, new_z);
        }
        else
        {
            Debug.Log("û�����屻ѡ��");
        }
    }
    private void OnGUI()
    {
        GUI.TextArea(new Rect(200,50,200,50),"��ת���λ��: " + singlePointDeltaPosition,400);
        GUI.TextArea(new Rect(420, 50, 200, 50), "��ת��: " + rotationAxis,400);
        GUI.TextArea(new Rect(650, 50, 200, 50), "��ת�ĽǶ�: " + rotationAngle,400);
    }
}
