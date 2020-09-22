using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public RectTransform knob;
    public Vector2 axis;
    private Vector2 joystickSize;

    //--------------------------------------------------
    void Start()
    {
        joystickSize = GetComponent<RectTransform>().rect.size;
    }

    //--------------------------------------------------
    private void MoveKnob(Vector2 pos)
    {
        knob.position = pos;
        pos.x = Mathf.Clamp(knob.anchoredPosition.x, -joystickSize.x/2, joystickSize.x/2);
        pos.y = Mathf.Clamp(knob.anchoredPosition.y, -joystickSize.y/2, joystickSize.y/2);
        knob.anchoredPosition = pos;
        axis = ((knob.anchoredPosition / joystickSize) * 2);
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
        knob.anchoredPosition = Vector2.zero;
    }
}
