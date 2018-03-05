using UnityEngine;
using System.Collections;

/// <summary>
/// Handles interacting with draggable objects that contain the ISURFACE interface.
/// TODO: 
/// </summary>
public class TouchDrag : MonoBehaviour
{
    private float dist;
    private bool dragging = false;
    private Vector3 offset;
    private Transform draggedObject;

    void Update()
    {
        Vector3 v3;

        if (Input.touchCount != 1)
        {
            dragging = false;
            return;
        }

        Touch touch = Input.touches[0];
        Vector3 pos = touch.position;

        if (touch.phase == TouchPhase.Began)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(pos);
            if (Physics.Raycast(ray, out hit))
            {
                switch (hit.transform.gameObject.GetComponent<Draggable>().surfaceType)
                {
                    case SurfaceType.Mirror:
                        draggedObject = hit.transform;
                        dist = hit.transform.position.z - Camera.main.transform.position.z;
                        v3 = new Vector3(pos.x, pos.y, dist);
                        v3 = Camera.main.ScreenToWorldPoint(v3);
                        offset = draggedObject.position - v3;
                        dragging = true;
                        break;
                }
            }
        }
        if(dragging){
            //TODO: Add visual to touch dragging item.
            
        }
        if (dragging && touch.phase == TouchPhase.Moved)
        {
            v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
            v3 = Camera.main.ScreenToWorldPoint(v3);
            draggedObject.position = v3 + offset;
        }
        if (dragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled))
        {
            dragging = false;
        }
    }
}