using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamSource : MonoBehaviour
{
    private LineRenderer line;

    void Start() {
        line = gameObject.GetComponent<LineRenderer>(); //gets our line renderer
    }
    void FixedUpdate() {
        sendRay(transform.position, transform.forward); //constantly sends out a new raycast from the starting position
    }

    private void sendRay(Vector3 origin, Vector3 direction) { //shoots out a raycast.  
        Ray beam;
        RaycastHit hit;
        Vector3 endPos = new Vector3(0, 0, 0);
        beam = new Ray(origin, direction);
        if (Physics.Raycast(beam, out hit, 50)) { //if we hit something
            endPos = hit.point;
            getRayHit(hit, beam); //decide if we hit a mirror or not.

        } else {
            // add segment to line that goes from the current origin, into the distance
        }
    }
    private void getRayHit(RaycastHit hit, Ray beam) { //checks what we hit
        switch (hit.collider.tag) {
            case "mirror":           //if we hit a mirror object
                Debug.Log("hit a mirror");
                sendRay(hit.transform.position, Vector3.Reflect(beam.direction, hit.normal)); //send a new ray reflecting off the object we hit.
                break;
        }
    }

    private void renderBeam(Vector3 origin, Vector3 endPos) {
        // keep track of how many beams we need, somehow? and adjust each segment whenever there is a change in either the origin or what it's reflecting off of.
        //I can't just render more lines, because I'll be left with a ton of garbage lines leftover.
    }

}
