using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_ControlRigidbody : MonoBehaviour
{
    public void addRigidBody(GameObject obj)
    {
        obj.AddComponent<Rigidbody>();
    }

    public void deleteRigidbody(GameObject obj)
    {
        Destroy(obj.GetComponent<Rigidbody>());
    }

}
