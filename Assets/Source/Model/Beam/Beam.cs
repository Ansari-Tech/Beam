using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    private Vector3 currOrigin, currEndPos;

    public void drawLine(Vector3 origin, Vector3 endPos) {
        LineRenderer renderer = GetComponent<LineRenderer>();
        renderer.SetPosition(0, origin);
        renderer.SetPosition(1, endPos);
        currEndPos = endPos;
        currOrigin = origin;
    }

    public Vector3 getOrigin() {
        return currOrigin;
    }
    public Vector3 getEndPos() {
        return currEndPos;
    }

}
