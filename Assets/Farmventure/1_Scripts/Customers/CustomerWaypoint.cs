using UnityEngine;

public class CustomerWaypoint
{
    public Transform Waypoint;
    public bool IsAvailable;

    public CustomerWaypoint(Transform waypoint)
    {
        Waypoint = waypoint;
        IsAvailable = true;
    }
}
