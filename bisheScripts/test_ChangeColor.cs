using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_ChangeColor : MonoBehaviour
{
    public string activeObject;
    public bool alive;

    private void Awake()
    {
        activeObject = "emptyObject";
        alive = true;
    }

    public void setUnalive()
    {
        alive = false;
    }

    private void Update()
    {
        if (alive)
        {
            activeObject = GameObject.Find("ScaleAndRotationZoom").GetComponent<test_scaleWithSelection>().selectedObject.name;
            if (string.Compare(this.name, activeObject) == 0)//此时正在操作这个物体
            {
                this.GetComponent<MeshRenderer>().material.color = Color.blue;
            }
            else
            {
                this.GetComponent<MeshRenderer>().material.color = Color.white;
            }
        }
    }

    public void setWhite(GameObject obj)
    {
        obj.GetComponent<MeshRenderer>().material.color = Color.white;
    }
    public void setBlue(GameObject obj)
    {
        obj.GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    public void setRed(GameObject obj)
    {
        obj.GetComponent<MeshRenderer>().material.color = Color.red;
    }
}
