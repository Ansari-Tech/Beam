using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamGoal : MonoBehaviour, ISurface
{
    [SerializeField]
    private bool state;
private SurfaceType surface = SurfaceType.Goal;
public SurfaceType surfaceType {
  get {
    return surface;
  }
}

    void Start()
    {
        state = false;
    }

    public SurfaceType GetSurfaceType()
    {
        return surfaceType;
    }
    public void GetHit()
    {
        GameManager.manager.endGameState();
    }
}
