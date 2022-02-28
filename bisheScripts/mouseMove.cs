using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseMove : MonoBehaviour
{
    //��꾭��ʱ�ı�������ɫ
    private Color mouseOverColor = Color.blue;//��������Ϊ��ɫ
    private Color originalColor;//�����������洢������ɫ

    void Start()
    {
        originalColor = this.GetComponent<Renderer>().material.color;//��ʼʱ�õ�������ɫ
    }

    void OnMouseEnter()
    {
        this.GetComponent<Renderer>().material.color = mouseOverColor;//����껬��ʱ�ı�������ɫΪ��ɫ
    }

    void OnMouseExit()
    {
        this.GetComponent<Renderer>().material.color = originalColor;//����껬��ʱ�ָ����屾����ɫ
    }

    IEnumerator OnMouseDown()//zֵ�̶�Ϊ����ԭ����zֵ���������ܱ������Ӱ�죩
    {
        Vector3 screenSpace = Camera.main.WorldToScreenPoint(transform.position);//��ά��������ת��Ļ����
        //�������Ļ����תΪ��ά���꣬�ټ�������λ�������֮��ľ���
        var offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
        print("down");
        while (Input.GetMouseButton(0))
        {
            Vector3 curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
            var curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
            transform.position = curPosition;
            yield return new WaitForFixedUpdate();
        }
    }

}
