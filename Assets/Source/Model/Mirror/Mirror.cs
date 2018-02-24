using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour, ILaserSurface{
  private SurfaceType surface  = SurfaceType.Mirror;
	public SurfaceType surfaceType {
  get {
    return surface;
  }
}
}
