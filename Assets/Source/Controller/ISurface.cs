using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SurfaceType
{
    Mirror,
    Goal,
    Floor,
}
public interface ISurface
{
    SurfaceType surfaceType { get; }
}
