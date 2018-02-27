using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamSource : MonoBehaviour
{
    private LineRenderer line;
    [SerializeField]
    private float maxDistance;
    [SerializeField]
    private int maxBounces;
    [SerializeField]
    private List<LaserHit> laserHits = new List<LaserHit>();

    public struct LaserHit
    {
        public Vector3 position, normal;
        public GameObject hitObject;
        public ISurface surface;
        public bool didBounce;
    }


    void Start()
    {
        line = GetComponent<LineRenderer>();
        maxDistance = 500;
        maxBounces = 5;
    }

    void Update()
    {
        UpdateBeam();
    }

    private void UpdateBeam()
    {
        int count = 0;
        float remainingDistance = maxDistance;
        Vector3 direction = transform.forward;
        Vector3 position = transform.position;

        laserHits.Clear();

        List<Vector3> points = new List<Vector3>();
        points.Add(position);

        while (count < maxBounces && remainingDistance > 0)
        {
            RaycastHit hit;
            if (Physics.Raycast(position, direction, out hit, remainingDistance))
            {
                position = hit.point;
                direction = Vector3.Reflect(direction, hit.normal);

                bool shouldBounce = false;

                LaserHit laserHit = new LaserHit();
                laserHit.position = position;
                laserHit.normal = direction;

                Collider collider = hit.collider;
                laserHit.hitObject = collider.gameObject;
                ISurface surface = collider.GetComponent<ISurface>();
                laserHit.surface = surface;

                if (surface != null)
                {
                    switch (surface.surfaceType)
                    {
                        case SurfaceType.Mirror:
                            shouldBounce = true;
                            break;
                        case SurfaceType.Goal:
                        hit.collider.GetComponent<BeamGoal>().GetHit();
                            break;
                    }
                    laserHit.didBounce = true;
                }
                else
                {
                    laserHit.didBounce = false;
                }
                remainingDistance -= hit.distance;
                count += 1;

                laserHits.Add(laserHit);
                points.Add(laserHit.position);
                if (!shouldBounce)
                {
                    break;
                }
            }
            else
            {
                points.Add(position + direction * remainingDistance);
                //      break;
            }
        }
        line.positionCount = points.Count;
        line.SetPositions(points.ToArray());
    }
}