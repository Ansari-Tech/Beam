using System.Collections;
using System.Collections.Generic;
using UnityEngine;



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
        else if(floor)
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
}
