using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_ControlGravity : MonoBehaviour
{

    public void deleteGravity(GameObject obj)
    {
        Rigidbody rigidbody = obj.GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
    }

    public void addGravity(GameObject obj)
    {
        Rigidbody rigidbody = obj.GetComponent<Rigidbody>();
        rigidbody.useGravity = true;
    }
}
