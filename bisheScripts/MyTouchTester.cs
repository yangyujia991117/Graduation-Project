using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures.TransformGestures;
using TouchScript;

public class MyTouchTester : MonoBehaviour
{
    public ScreenTransformGesture singlePoint;//单点触控
    public ScreenTransformGesture doublePoint;//双点触控

    public Vector3 SingleDeltaPosition;
    public float SingleDeltaRotation;
    public float SingleDeltaScale;
    public Vector3 DoubleDeltaPosition;
    public float DoubleDeltaRotation;
    public float DoubleDeltaScale;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        singlePoint.Transformed += SingleMove;//当singlePoint.Transformed这个事件发生时，会调用SingleMove方法
        doublePoint.Transformed += DoubleMove;//当doublePoint.Transformed这个事件发生时，会调用DoubleMove方法
        singlePoint.AddFriendlyGesture(doublePoint);

    }

    private void SingleMove(object sender,System.EventArgs e)//单点位移
    {
        //doublePoint.Transformed += SingleAndDoubleMove;
        Debug.Log("调用了单点移动方法");
        SingleDeltaPosition = singlePoint.DeltaPosition;
        SingleDeltaRotation = singlePoint.DeltaRotation;
        SingleDeltaScale = singlePoint.DeltaScale;

        Vector3 offset = Camera.main.ScreenToWorldPoint(SingleDeltaPosition);
        //Debug.Log("singlePoint.DeltaPosition:"+SingleDeltaPosition+"offset:"+offset+ "singlePoint.transform.position:" + singlePoint.transform.position);
        //this.transform.position = this.transform.position + offset;
        //this.transform.position = this.transform.position + singlePoint.DeltaPosition;
        //Debug.Log("singlePoint.DeltaPosition: "+singlePoint.DeltaPosition);//打印位移量
        //Debug.Log("singlePoint.DeltaRotation: " + singlePoint.DeltaRotation);//打印旋转量
        //Debug.Log("singlePoint.DeltaScale: " + singlePoint.DeltaScale);//打印缩放量

        //doublePoint.Transformed += SingleAndDoubleMove;
        return;
    }
    private void DoubleMove(object sender, System.EventArgs e)
    {
        Debug.Log("调用了双点旋转/缩放方法");
        DoubleDeltaPosition = doublePoint.DeltaPosition;
        DoubleDeltaRotation = doublePoint.DeltaRotation;
        DoubleDeltaScale = doublePoint.DeltaScale;
        //Debug.Log("doublePoint.DeltaScale的放大值：" + 100 * (doublePoint.DeltaScale - 1.0f));
        return;
    }
    private void SingleAndDoubleMove(object sender, System.EventArgs e)
    {
        Debug.Log("同时调用了单点移动和双点旋转/缩放方法");
        return;
    }
    private void OnGUI()
    {
        GUILayout.TextArea("singlePoint.DeltaPosition: " + SingleDeltaPosition, 200);
        GUILayout.TextArea("singlePoint.DeltaRotation: " + SingleDeltaRotation, 200);
        GUILayout.TextArea("singlePoint.DeltaScale: " + SingleDeltaScale, 200);
        GUILayout.TextArea("singlePoint.DeltaPosition: " + DoubleDeltaPosition, 200);
        GUILayout.TextArea("singlePoint.DeltaRotation: " + DoubleDeltaRotation, 200);
        GUILayout.TextArea("singlePoint.DeltaScale: " + DoubleDeltaScale, 200);
    }
}
