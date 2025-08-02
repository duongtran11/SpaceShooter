using UnityEngine;

public class FlyPath : MonoBehaviour
{
    public Waypoint[] Waypoints;
    public Vector3 this[int index] => Waypoints[index].transform.position;
    void Update()
    {
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        for (int i = 0; i < Waypoints.Length - 1; i++)
        {
            Gizmos.DrawLine(Waypoints[i].transform.position, Waypoints[i + 1].transform.position);
        }
    }
}
