using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;

public class test_Selection : MonoBehaviour
{
    public TapGesture tapGesture;

    void OnEnable()
    {
        tapGesture.Tapped += selectThisObject;
    }
    public void selectThisObject(object sender, System.EventArgs e)
    {
        if (this.GetComponent<test_ChangeColor>().alive)
        {
            GameObject.Find("ScaleAndRotationZoom").SendMessage("setSelectedObject", this.gameObject);
        }
        else
        {
            Debug.Log("这个物体已经死了");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
