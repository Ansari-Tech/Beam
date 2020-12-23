using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    private bool dragging = false;
    private bool rotating = false;
    private Transform draggedObject;

    void Update()
    {
        GetObjectUnderClick();
        HandleDrag();
        HandleRotate();
    }


    private void HandleRotate()
    {
        if(dragging)
        {
            if (Input.GetMouseButton(1))
            {
                rotating = true;
                draggedObject.transform.rotation = Quaternion.LookRotation(GetLocationFromMouse()[1]);
            }
            else
            {
                rotating = false;
            }
            
        }
    }


    private void HandleDrag()
    {
        if (dragging && !rotating)
        {
            draggedObject.transform.position = GetLocationFromMouse()[0];
        }
    }

    private Vector3[] GetLocationFromMouse()
    {
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;
        Vector3[] correctedMouseLocation = new Vector3[2];
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, Constants.LAYER_MASK_DRAGGABLE))
        {
            Vector3 offsetFromGround = new Vector3(0, draggedObject.transform.lossyScale.y / 2, 0);
            Vector3 offsetFromMouse = new Vector3(hit.point.x - draggedObject.transform.position.x, 0, hit.point.z - draggedObject.transform.position.z);
            correctedMouseLocation[0] = (hit.point + offsetFromGround);
            correctedMouseLocation[1] = (correctedMouseLocation[0] - draggedObject.transform.position).normalized;
        }
        return correctedMouseLocation;
    }

    private void GetObjectUnderClick()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.GetComponent<Draggable>() != null)
                {

                    switch (hit.transform.gameObject.GetComponent<Draggable>().surfaceType)
                    {
                        case SurfaceType.Mirror:
                            Debug.Log("hit mirror");
                            draggedObject = hit.transform;
                            dragging = true;
                            break;
                        default:
                            dragging = false;
                            break;
                    }
                }

            }
        }
        else
        {
            dragging = false;
        }
    }

    public bool isDragging()
    {
        return dragging;
    }
}
