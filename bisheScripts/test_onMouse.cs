using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_onMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        Debug.Log("这个物体被鼠标点了！");
    }
    private void OnMouseUp()
    {
        Debug.Log("释放点击这个物体的鼠标！");
    }
    private void OnMouseEnter()
    {
        Debug.Log("鼠标移进这个物体！");
    }
    private void OnMouseOver()
    {
        Debug.Log("鼠标放在这个物体区域里面！");
    }
    private void OnMouseExit()
    {
        Debug.Log("鼠标离开这个物体！");
    }
    private void OnMouseDrag()
    {
        Debug.Log("鼠标拖动这个物体！");
    }
}
