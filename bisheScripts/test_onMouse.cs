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
        Debug.Log("������屻�����ˣ�");
    }
    private void OnMouseUp()
    {
        Debug.Log("�ͷŵ������������꣡");
    }
    private void OnMouseEnter()
    {
        Debug.Log("����ƽ�������壡");
    }
    private void OnMouseOver()
    {
        Debug.Log("��������������������棡");
    }
    private void OnMouseExit()
    {
        Debug.Log("����뿪������壡");
    }
    private void OnMouseDrag()
    {
        Debug.Log("����϶�������壡");
    }
}
