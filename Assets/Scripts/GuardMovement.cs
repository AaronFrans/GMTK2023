using System;
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
    [SerializeField] private float rotateSpeed = 30f;

    [SerializeField] private float distanceTreshold = 5f;

    public bool IsAlert { get; set; } = false;
    private bool hasSeenPlayer = false;

    private bool isInRoom = false;


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
            if (!isInRoom)
                StartCoroutine(LookInRoom());
        }
    }

    private IEnumerator LookInRoom()
    {

        Vector3 rotation = transform.rotation.eulerAngles;
        agent.speed = 0;
        agent.updateRotation = false;

        isInRoom = true;

        float rotationInc = 0;
        while (rotationInc <= 540)
        {
            rotationInc += rotateSpeed * Time.deltaTime;
            rotation.y += rotateSpeed * Time.deltaTime;


            transform.rotation = Quaternion.Euler(rotation);

            yield return null;
        }


        agent.speed = moveSpeed;
        agent.updateRotation = true;

        isInRoom = false;

        currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint);
        agent.SetDestination(currentWaypoint.position);
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
