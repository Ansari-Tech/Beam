using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamSource : MonoBehaviour
{
    private LineRenderer visual;
    void Start() {
        visual = this.GetComponent<LineRenderer>();
    }

    void FixedUpdate() {
        sendRay(transform.position, transform.forward);
    }

    private void getRayHit(RaycastHit hit, Ray beam) {
        switch (hit.collider.tag) {

            case "mirror":
                Debug.Log("hit a mirror");
                sendRay(hit.transform.position, Vector3.Reflect(beam.direction, hit.normal));
                break;

        }
    }

    private void sendRay(Vector3 origin, Vector3 direction) {
        Ray beam;
        RaycastHit hit;
        Vector3 endPos = new Vector3(0, 0, 0);
        beam = new Ray(origin, direction);
        // Debug.DrawRay(origin, direction * 100, Color.green, 100);
        if (Physics.Raycast(beam, out hit, 50)) {
            endPos = hit.point;
            visual.SetPosition(0, origin);
            visual.SetPosition(1, endPos);
        } else {
            visual.SetPosition(0, origin);
            visual.SetPosition(1, direction * 20 + origin);
        }
        getRayHit(hit, beam);
    }

}
