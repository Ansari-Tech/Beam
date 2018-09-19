using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseCameraHandler : MonoBehaviour
{
    [SerializeField]
    private float screenEdgeOffset;
    [SerializeField]
    private float cameraSpeed;
    [SerializeField]
    private bool moving;
    void Start()
    {
        screenEdgeOffset = .05f;
        cameraSpeed = .2f;
    }
    void Update()
    {
        moveCameraPosition(checkMousePosition(), moving);
    }

    private void moveCameraPosition(Vector3 movePos, bool moving)
    {
        if (moving)
        {
            transform.Translate(checkMousePosition());
        }
    }
    private Vector3 checkMousePosition()
    {
        Vector3 mouseDirection = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        Vector3 result = new Vector3();
        if (mouseDirection.x <= 0 + screenEdgeOffset)
        {
            moving = true;
            result += new Vector3(-cameraSpeed, 0, 0);
        }
        else if (mouseDirection.x >= 1 - screenEdgeOffset)
        {
            moving = true;
            result += new Vector3(cameraSpeed, 0, 0);
        }
        else if (mouseDirection.y <= 0 + screenEdgeOffset)
        {
            moving = true;
            result += new Vector3(0, -cameraSpeed, 0);
        }
        else if (mouseDirection.y >= 1 - screenEdgeOffset)
        {
            moving = true;
            result += new Vector3(0, cameraSpeed, 0);
        }
        else
        {
            moving = false;
        }
        return result;
    }
}
