using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Draggable : MonoBehaviour, ISurface
{
    [SerializeField]
    private bool mirror, floor;
    private SurfaceType surface;

    void Awake()
    {
        if (mirror)
        {
            floor = false;
            surface = SurfaceType.Mirror;
        }
        else if (floor)
        {
            mirror = false;
            surface = SurfaceType.Floor;
        }

    }
    public SurfaceType surfaceType
    {
        get
        {
            return surface;
        }
    }

    public void rotateLeft()
    {
        gameObject.transform.Rotate(45,0,0);
    }
    public void rotateRight()
    {
        gameObject.transform.Rotate(-45,0,0);

    }
}
