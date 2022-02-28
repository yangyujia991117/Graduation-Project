using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_drag : MonoBehaviour
{
    public Camera mCamera;
    public float depth = 5f;
    public RaycastHit hit;
    //public GameObject bottom,left,right,back;//四个周边物体

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
    void moveObject()//物体的z会受周围物体影响
    {
        Debug.Log("拖动物体");
        Ray r = mCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(r,out hit, 1000f, 1))
        {
            this.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
        }
        Debug.DrawLine(r.origin, hit.point, Color.magenta);
    }
    void moveObject_FixedDepth()//以固定的z值移动（其实也可以设置为初始z值），不受周围物体影响
    {
        Vector3 mouseScreen = Input.mousePosition;
        mouseScreen.z = depth;
        Vector3 mouseWorld = mCamera.ScreenToWorldPoint(mouseScreen);
        this.transform.position = mouseWorld;
    }
    private void OnGUI()
    {
        GUILayout.TextArea("鼠标位置:" + Input.mousePosition,200);
        GUILayout.TextArea("RaycastHit:" + hit.point, 200);
        GUILayout.TextArea("mouseWorld:" + mCamera.ScreenToWorldPoint(Input.mousePosition), 200);
    }
}
