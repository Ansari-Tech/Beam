using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    private float dist;
    [SerializeField]
    private bool dragging = false;
    private Vector3 offset;
    private Transform draggedObject;
    [SerializeField]
    private float timeToRotate;

    // Update is called once per frame
    void Update()
    {
        Vector3 v3;
        Vector3 pos = Input.mousePosition;
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
        }
        if (dragging)
        {
            v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
            v3 = Camera.main.ScreenToWorldPoint(v3);
            Vector3 temp = v3 + offset;
            Vector3 final = new Vector3(temp.x, -0.62f, temp.z);
            draggedObject.position = final;
        }
    }

    public bool isDragging()
    {
        return dragging;
    }
}
