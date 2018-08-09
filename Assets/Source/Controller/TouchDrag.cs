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
    [SerializeField]
    private float timeToRotate;
    void Update()
    {
        Vector3 v3;

        if (Input.touchCount == 0)
        {
            dragging = false;
            return;
        }
        else
        {
            Touch touch = Input.touches[0];
            Vector3 pos = touch.position;

            if (touch.phase == TouchPhase.Began)
            {
                if (Input.touchCount == 1)
                {
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(pos);
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform.gameObject.GetComponent<Draggable>() != null)
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
                }
                else
                {
                    dragging = false;
                    Debug.Log("Multi Touch Drifting");
                }
            }

            if (dragging && touch.phase == TouchPhase.Moved && Input.touchCount == 1)
            {
                v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
                v3 = Camera.main.ScreenToWorldPoint(v3);
                Vector3 temp = v3 + offset;
                Vector3 final = new Vector3(temp.x, -0.62f, temp.z);
                draggedObject.position = final;
            }

            else if (dragging && touch.phase == TouchPhase.Stationary && Input.touchCount == 1)
            {
                float time = 0.0f;
                while (time < timeToRotate)
                {
                    time += Time.deltaTime;
                    Debug.Log(time);
                }
                Debug.Log("rotate");
                time = 0.0f;
                Debug.Log("just tapped");
                dragging = false;
            }
            else if (dragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled))
            {
                dragging = false;
            }
        }
    }
    public bool isDragging()
    {
        return dragging;
    }
}