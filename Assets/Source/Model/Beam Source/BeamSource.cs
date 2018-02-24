using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamSource : MonoBehaviour
{
    //FOR TESTING
    [SerializeField]
    private bool LaserOn;
    private LineRenderer line;
    void Start() {
        LaserOn = true;
        line = GetComponent<LineRenderer>();
    }
    void FixedUpdate() {
        if (LaserOn) {
            CastRay(transform.position, transform.forward * 100);
        }
    }
    private void clearLines() {
        line.positionCount = 0;
    }
    private void CastRay(Vector3 origin, Vector3 destination) {
        Ray beamRay = new Ray(origin, destination);
        RaycastHit hit;
        if (Physics.Raycast(beamRay, out hit, 100)) {
            line.positionCount += 1;
            line.SetPosition(line.positionCount -1, destination);
            Debug.DrawLine(origin, hit.point, Color.red);
            IdentifyCollision(hit, beamRay);
        }
    }

    private void IdentifyCollision(RaycastHit hit, Ray beamRay) {

        switch (hit.collider.tag) {
            case "mirror":
                Debug.Log("hit mirror");
                CastRay(hit.point, Vector3.Reflect(beamRay.direction, hit.normal));
                break;
            default:
                Debug.Log("hit a wall");
                clearLines();
                break;
        }
    }
}
