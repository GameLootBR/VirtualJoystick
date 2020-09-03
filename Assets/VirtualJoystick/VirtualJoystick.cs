using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public Transform knob;
    public Vector2 axis;

    private Vector2 joystickSize;

    //--------------------------------------------------
    void Start()
    {
        joystickSize = GetComponent<RectTransform>().rect.max;
    }

    //--------------------------------------------------
    private void MoveKnob(Vector2 pos)
    {
        knob.position = pos;
        pos.x = Mathf.Clamp(knob.localPosition.x, 0, joystickSize.x);
        pos.y = Mathf.Clamp(knob.localPosition.y, 0, joystickSize.y);
        knob.localPosition = pos;

        axis = ((knob.localPosition / joystickSize) * 2) - Vector2.one;
    }

    //--------------------------------------------------
    public void OnDrag(PointerEventData eventData)
    {
        MoveKnob(eventData.position);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        MoveKnob(eventData.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        axis = Vector2.zero;
        knob.localPosition = joystickSize/2;
    }
}
