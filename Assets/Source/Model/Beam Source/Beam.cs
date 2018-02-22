using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : ScriptableObject
{
    [SerializeField]
    private Vector3 pos;
    [SerializeField]
    private Transform trans;


    public Vector3 getPos() {
        return pos;
    }

    public void setPos(Vector3 inPos) {
        pos = inPos;
    }
    public Transform getTransform() {
        return trans;
    }

    public void setTransform(Transform inTransform) {
        trans = inTransform;
    }

}
