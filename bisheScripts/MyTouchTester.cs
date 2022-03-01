using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures.TransformGestures;
using TouchScript;

public class MyTouchTester : MonoBehaviour
{
    public ScreenTransformGesture singlePoint;//���㴥��
    public ScreenTransformGesture doublePoint;//˫�㴥��

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
        singlePoint.Transformed += SingleMove;//��singlePoint.Transformed����¼�����ʱ�������SingleMove����
        doublePoint.Transformed += DoubleMove;//��doublePoint.Transformed����¼�����ʱ�������DoubleMove����
        singlePoint.AddFriendlyGesture(doublePoint);

    }

    private void SingleMove(object sender,System.EventArgs e)//����λ��
    {
        //doublePoint.Transformed += SingleAndDoubleMove;
        Debug.Log("�����˵����ƶ�����");
        SingleDeltaPosition = singlePoint.DeltaPosition;
        SingleDeltaRotation = singlePoint.DeltaRotation;
        SingleDeltaScale = singlePoint.DeltaScale;

        Vector3 offset = Camera.main.ScreenToWorldPoint(SingleDeltaPosition);
        //Debug.Log("singlePoint.DeltaPosition:"+SingleDeltaPosition+"offset:"+offset+ "singlePoint.transform.position:" + singlePoint.transform.position);
        //this.transform.position = this.transform.position + offset;
        //this.transform.position = this.transform.position + singlePoint.DeltaPosition;
        //Debug.Log("singlePoint.DeltaPosition: "+singlePoint.DeltaPosition);//��ӡλ����
        //Debug.Log("singlePoint.DeltaRotation: " + singlePoint.DeltaRotation);//��ӡ��ת��
        //Debug.Log("singlePoint.DeltaScale: " + singlePoint.DeltaScale);//��ӡ������

        //doublePoint.Transformed += SingleAndDoubleMove;
        return;
    }
    private void DoubleMove(object sender, System.EventArgs e)
    {
        Debug.Log("������˫����ת/���ŷ���");
        DoubleDeltaPosition = doublePoint.DeltaPosition;
        DoubleDeltaRotation = doublePoint.DeltaRotation;
        DoubleDeltaScale = doublePoint.DeltaScale;
        //Debug.Log("doublePoint.DeltaScale�ķŴ�ֵ��" + 100 * (doublePoint.DeltaScale - 1.0f));
        return;
    }
    private void SingleAndDoubleMove(object sender, System.EventArgs e)
    {
        Debug.Log("ͬʱ�����˵����ƶ���˫����ת/���ŷ���");
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
