using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_Collision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (string.Compare(GameObject.Find("ScaleAndRotationZoom").GetComponent<test_scaleWithSelection>().selectedObject.name, collision.gameObject.name) == 0)
        {
            GameObject.Find("ScaleAndRotationZoom").SendMessage("setSelectedObject", GameObject.Find("EmptyObject"));
        }
        collision.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        collision.gameObject.SendMessage("setUnalive");
    }
}
