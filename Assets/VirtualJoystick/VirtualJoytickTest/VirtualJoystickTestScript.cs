using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualJoystickTestScript : MonoBehaviour
{
    public VirtualJoystick virtualJoystickLeft;
    public VirtualJoystick virtualJoystickRight;

    public float movementSpeed = 5;
    public float rotateSpeed = 60;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(virtualJoystickLeft.axis.x, 0, virtualJoystickLeft.axis.y);
        transform.Translate(movement * Time.deltaTime * movementSpeed);

        transform.Rotate(transform.up * virtualJoystickRight.axis.x * Time.deltaTime * rotateSpeed);
    }
}
