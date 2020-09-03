using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public VirtualJoystick virtualJoystick;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(virtualJoystick.axis.x, 0, virtualJoystick.axis.y);
        transform.Translate(direction * Time.deltaTime * 5);
    }
}
