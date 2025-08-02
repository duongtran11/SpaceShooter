using UnityEngine;

public class FlyPath : MonoBehaviour
{
    public Waypoint[] Waypoints;
    public Vector3 this[int index] => Waypoints[index].transform.position;
}
