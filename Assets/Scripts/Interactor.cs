using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    public Transform Source;
    public float InteractRange;
    public LayerMask layerMask;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Ray raycast = new(Source.position, Source.forward);
            if(Physics.Raycast(raycast, out RaycastHit hitInfo, InteractRange, layerMask))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                    interactObj.Interact();
            }
        }
    }
}
