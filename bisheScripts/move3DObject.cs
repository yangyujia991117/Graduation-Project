using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move3DObject : MonoBehaviour
{
    private bool isClick = false;
    private Transform curTf = null;
    private Vector3 oriMousePos;
    private Vector3 oriObjectScreenPos;

    private void Update()//�����zֵ�����ܱ�����Ӱ�죬�÷������ص����϶���ʱ������ʲ���һֱ����
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("�������������");
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
