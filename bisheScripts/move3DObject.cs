using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move3DObject : MonoBehaviour
{
    private bool isClick = false;
    private Transform curTf = null;
    private Vector3 oriMousePos;
    private Vector3 oriObjectScreenPos;

    private void Update()//物体的z值会受周边物体影响，该方法的特点是拖动的时候鼠标或笔不用一直点着
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("点击了鼠标左键！");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                curTf = hit.transform;
                oriObjectScreenPos = Camera.main.WorldToScreenPoint(curTf.position);
                oriMousePos = Input.mousePosition;
            }
            isClick = !isClick;
        }
        if (isClick)
        {
            if (curTf != null)
            {
                Vector3 curMousePos = Input.mousePosition;
                Vector3 mouseOffset = curMousePos - oriMousePos;
                Vector3 curObjectScreenPos = oriObjectScreenPos + mouseOffset;
                Vector3 curObjectWorldPos = Camera.main.ScreenToWorldPoint(curObjectScreenPos);
                curTf.position = curObjectWorldPos;
            }
        }
    }

}
