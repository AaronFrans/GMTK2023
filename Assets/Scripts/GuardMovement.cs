using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GuardMovement : MonoBehaviour
{

    // Store reference to the waypoint system
    [SerializeField] private Waypoints waypoints;


    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private float distanceTreshold = 5f;


    private Transform currentWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        if (waypoints == null)
        {
            Debug.LogError("No Positions given to gaurd: " + gameObject.name);
            return;
        }

        currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint);

        transform.position = currentWaypoint.position;

        currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint);
        transform.LookAt(currentWaypoint);

    }


    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceTreshold)
        {
            currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint);
            transform.LookAt(currentWaypoint);
        }
    }
}
