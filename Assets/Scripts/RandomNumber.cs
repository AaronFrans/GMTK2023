using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNumber : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        
        Debug.Log(Random.RandomRange(0, 100));
    }

}
