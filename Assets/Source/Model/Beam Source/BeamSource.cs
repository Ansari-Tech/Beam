using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamSource : MonoBehaviour
{
    //FOR TESTING
    [SerializeField]
    private bool LaserOn;
    private LineRenderer renderer;
    void Start() {
        LaserOn = true;
        renderer = GetComponent<LineRenderer>();
    }
    void FixedUpdate() {
        if (LaserOn) {
            CastRay(transform.position, transform.forward * 100);
        }
    }
    private void clearLines() {
        renderer.positionCount = 0;
    }
    private void CastRay(Vector3 origin, Vector3 destination) {
        Ray beamRay = new Ray(origin, destination);
        RaycastHit hit;

        if (Physics.Raycast(beamRay, out hit, 100)) {
            renderer.positionCount += 1;
            renderer.SetPosition(renderer.positionCount, destination);
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
