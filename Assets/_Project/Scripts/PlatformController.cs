using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour, IActivateable
{
	// Inspector Fields
	[Header("Platform Settings")]
	[SerializeField] private float moveSpeed;
    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private Transform waypointContainer;

	// Private Variables
	private bool activated = false;
    private int waypointIndex = 0;
	private Rigidbody2D rBody;
    private Transform target;

	private void Awake()
	{
		rBody = GetComponent<Rigidbody2D>();
        GetWaypoints();
        target = waypoints[0];
	}

	private void FixedUpdate()
	{
        if(activated)
        {
            Vector2 dir = target.position - transform.position;
            rBody.velocity = dir.normalized * moveSpeed;

            if(Vector2.Distance(transform.position, target.position) <= 0.02f)
            {
                GetNextWayPoint();
                Debug.Log(Vector2.Distance(transform.position, target.position));
            }
        }
	}

	public void Activate()
	{
		activated = true;
	}

    private void GetWaypoints()
    {
        waypoints = new List<Transform>();

        foreach(Transform waypoint in waypointContainer)
        {
            waypoints.Add(waypoint);
        }
    }

    private void GetNextWayPoint()
    {
        if(waypointIndex >= waypoints.Count - 1)
        {
            waypointIndex = 0;
            target = waypoints[0];
            return;
        }

        waypointIndex++;
        target = waypoints[waypointIndex];
    }
}
