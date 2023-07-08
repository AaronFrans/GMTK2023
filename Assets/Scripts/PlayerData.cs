using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData instance;

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        
    }

    public bool isInteracting = false;
    
}