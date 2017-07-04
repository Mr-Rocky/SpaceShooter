using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class SimpleTouchPad : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler {

    public float smoothing;

    private Vector2 origin;
    private Vector2 direction;
    private Vector2 smoothDirection;
    private bool touched;
    private int pointerID;

    void Awake()
    {
        direction = Vector2.zero;
        touched = false;
    }

	public void OnPointerDown(PointerEventData data)
    {
        // set our start point
        if (!touched)
        {
            origin = data.position;
            pointerID = data.pointerId;
            touched = true;
        }
    }

    public void OnDrag(PointerEventData data)
    {
        // compare the diffrence betwen our start point and current pointer pos
        if (data.pointerId == pointerID)
        {
            Vector2 currentPoisition = data.position;
            Vector2 directionRaw = currentPoisition - origin;
            direction = directionRaw.normalized;
        }
    }

    public void OnPointerUp(PointerEventData data)
    {
        // reset everything
        if (data.pointerId == pointerID)
        {
            direction = Vector2.zero;
            touched = false;
        }
    }

    public Vector2 GetDirection()
    {
        smoothDirection = Vector2.MoveTowards(smoothDirection, direction, smoothing);
        return smoothDirection;
    }
}
