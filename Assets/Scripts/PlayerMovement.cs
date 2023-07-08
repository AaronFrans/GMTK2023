using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 0.001f;
    [SerializeField] Transform playerCamera = null;
    [SerializeField] Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovements();
    }

    private void PlayerMovements()
    {
        //Input
        var forward = Input.GetAxisRaw("Forward");
        var sideways = Input.GetAxisRaw("Sideways");

        //Camera
        Vector3 cameraForw = playerCamera.forward;
        Vector3 cameraRight = playerCamera.right;

        cameraForw.y = 0;   
        cameraRight.y = 0;

        
        //Movement
        Vector3 forwardRelative = forward * cameraForw;
        Vector3 rightRelative = sideways * cameraRight;

        Vector3 moveDir = forwardRelative + rightRelative;

        Vector3 movement = new Vector3(moveDir.x, 0, moveDir.z ) * Time.fixedDeltaTime * movementSpeed;
        rb.MovePosition(rb.position + movement);
    }
}
