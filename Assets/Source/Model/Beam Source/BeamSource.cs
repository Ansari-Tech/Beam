using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamSource : MonoBehaviour
{
    private Ray beam;
    private RaycastHit hit;
    private LineRenderer visual;
    void Start() {
        visual = this.GetComponent<LineRenderer>();
    }

    void FixedUpdate() {
        Vector3 endPos = new Vector3(0, 0, 0);
        beam = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 100, Color.green, 100);
        if (Physics.Raycast(beam, out hit, 50)) {
            endPos = hit.point;
            visual.SetPosition(0, transform.position);
            visual.SetPosition(1, endPos);
        } else {
            visual.SetPosition(0, transform.position);
            visual.SetPosition(1, transform.forward * 20 + transform.position);
        }
        Debug.Log(endPos);

    }

}
