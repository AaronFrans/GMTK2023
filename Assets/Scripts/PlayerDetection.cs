using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class PlayerDetection : MonoBehaviour
{

    [SerializeField] private float detectionRadius = 5f;
    [SerializeField] private GuardMovement movement;




    private SphereCollider detection;

    private void OnDrawGizmos()
    {
        Vector2 origin = transform.position;
        DrawWireDisk(transform.position, detectionRadius, Color.yellow);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!movement)
        {
            Debug.LogError($"No movement set on the detection of {gameObject.name}");
            return;
        }

        detection = gameObject.GetComponent<SphereCollider>();

        detection.radius = detectionRadius;
        detection.isTrigger = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.tag.Equals("Player"))
            return;


        Debug.Log("Player entered");
        //check if the player is in a minigame

        //get the player component
        //var player = other.gameObject.GetComponent<PlayerComponent>();

        //check is in minigame
        // player.isinminigame


    }
    private const float GIZMO_DISK_THICKNESS = 0.01f;

    public static void DrawWireDisk(Vector3 position, float radius, Color color)
    {
        Color oldColor = Gizmos.color;
        Gizmos.color = color;
        Matrix4x4 oldMatrix = Gizmos.matrix;
        Gizmos.matrix = Matrix4x4.TRS(position, Quaternion.identity, new Vector3(1, GIZMO_DISK_THICKNESS, 1));
        Gizmos.DrawWireSphere(Vector3.zero, radius);
        Gizmos.matrix = oldMatrix;
        Gizmos.color = oldColor;
    }

    
}
