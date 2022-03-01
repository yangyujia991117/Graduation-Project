using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures.TransformGestures;

public class test_SingleDrag : MonoBehaviour
{
    public string activeObject;

    private void Awake()
    {
        activeObject = "emptyObject";
    }
    public void drag(TransformGesture screenTransformGesture)
    {
        activeObject = GameObject.Find("ScaleAndRotationZoom").GetComponent<test_scaleWithSelection>().selectedObject.name;
        
        if (string.Compare(this.name, activeObject) == 0)//这个物体之前必须要被选中才能够进行拖拽
        {       this.transform.localPosition += screenTransformGesture.DeltaPosition;
        }
        
    }
}
