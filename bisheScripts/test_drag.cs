using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_drag : MonoBehaviour
{
    public Camera mCamera;
    public float depth = 5f;
    public RaycastHit hit;
    //public GameObject bottom,left,right,back;//�ĸ��ܱ�����

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        this.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
    }
    private void OnMouseExit()
    {
        this.transform.localScale = new Vector3(1, 1, 1);
    }
    private void OnMouseDrag()
    {
        moveObject();
        //moveObject_FixedDepth();
    }
    void moveObject()//�����z������Χ����Ӱ��
    {
        Debug.Log("�϶�����");
        Ray r = mCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(r,out hit, 1000f, 1))
        {
            this.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
        }
        Debug.DrawLine(r.origin, hit.point, Color.magenta);
    }
    void moveObject_FixedDepth()//�Թ̶���zֵ�ƶ�����ʵҲ��������Ϊ��ʼzֵ����������Χ����Ӱ��
    {
        Vector3 mouseScreen = Input.mousePosition;
        mouseScreen.z = depth;
        Vector3 mouseWorld = mCamera.ScreenToWorldPoint(mouseScreen);
        this.transform.position = mouseWorld;
    }
    private void OnGUI()
    {
        GUILayout.TextArea("���λ��:" + Input.mousePosition,200);
        GUILayout.TextArea("RaycastHit:" + hit.point, 200);
        GUILayout.TextArea("mouseWorld:" + mCamera.ScreenToWorldPoint(Input.mousePosition), 200);
    }
}
