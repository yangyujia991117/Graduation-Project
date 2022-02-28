using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures.TransformGestures;

public class test_scaleWithSelection : MonoBehaviour
{
    public TransformGesture singlePoint;//单点触控
    public TransformGesture doublePoint;//双点触控

    public GameObject selectedObject;

    void Awake()
    {
        selectedObject = new GameObject("EmptyObject");
    }

    public void setSelectedObject(GameObject obj)
    {
        Debug.Log("选择了" + obj.name);
        selectedObject = obj;
    }
    private void OnEnable()
    {
        singlePoint.Transformed += singleRotate;//当singlePoint.Transformed这个事件发生时，会调用SingleRotate方法
        doublePoint.Transformed += doubleScale;
    }

    private void singleRotate(object sender, System.EventArgs e)
    {
        if (selectedObject.name != "EmptyObject")
        {
            print("旋转点的位移: " + singlePoint.DeltaPosition); //旋转点的位移
            Plane plane = singlePoint.TransformPlane;
            print("旋转平面: " + plane);
            Vector3 axis = Vector3.Cross(new Vector3(0, 0, 1), singlePoint.DeltaPosition);
            print("旋转轴: " + axis);
            float distance = singlePoint.DeltaPosition.sqrMagnitude;//位移的长度
            print("旋转点位移的长度: " + distance);
            float angle = -360 * distance;
            Quaternion rotation = Quaternion.AngleAxis(45, axis);
            //this.transform.localRotation = rotation;
            selectedObject.transform.Rotate(axis, angle);
        }
        else
        {
            Debug.Log("没有物体被选择");
        }
    }

    private void doubleScale(object sender, System.EventArgs e)
    {
        if (selectedObject.name != "EmptyObject")
        {
            print("缩放的大小: " + doublePoint.DeltaScale); //缩放的大小
            Vector3 camaraPosition = GameObject.Find("Main Camera").transform.position;//当前主镜头位置
            float old_distance = selectedObject.transform.localPosition.z - camaraPosition.z;
            float new_distance = 1 / doublePoint.DeltaScale * old_distance;
            float new_z = new_distance + camaraPosition.z;
            if (new_z > this.transform.position.z)
            {
                new_z = this.transform.position.z;//这个物体不能去到这块板的后面
            }
            selectedObject.transform.localPosition = new Vector3(selectedObject.transform.localPosition.x, selectedObject.transform.localPosition.y, new_z);
        }
        else
        {
            Debug.Log("没有物体被选择");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
