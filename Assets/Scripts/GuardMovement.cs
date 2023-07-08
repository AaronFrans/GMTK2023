using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

[RequireComponent(typeof(NavMeshAgent))]
public class GuardMovement : MonoBehaviour
{

    // Store reference to the waypoint system
    [SerializeField] private Waypoints waypoints;


    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private float distanceTreshold = 5f;

    public bool IsAlert { get; set; } = false;
    private bool hasSeenPlayer = false;


    public static Transform PlayerTransform { get; set; }


    private NavMeshAgent agent;

    private Transform currentWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        if (waypoints == null)
        {
            Debug.LogError("No Positions given to gaurd: {gameObject.name}");
            return;
        }

        currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint);

        transform.position = currentWaypoint.position;
        

        currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint);
        transform.LookAt(currentWaypoint);

        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;
        agent.SetDestination(currentWaypoint.position);
    }


    // Update is called once per frame
    void Update()
    {

        if (IsAlert && hasSeenPlayer)
        {
            GoToPlayer();
            return;

        }


        if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceTreshold)
        {
            currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint);
            transform.LookAt(currentWaypoint);
            agent.SetDestination(currentWaypoint.position);
        }
    }


    void GoToPlayer()
    {

        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
        transform.LookAt(PlayerTransform.position);

        if (Vector3.Distance(transform.position, PlayerTransform.position) < distanceTreshold)
        {
            hasSeenPlayer = false;
        }
    }
}
