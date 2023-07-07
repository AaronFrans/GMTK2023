using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardMovement : MonoBehaviour
{

    public List<Transform> positions = new List<Transform>();


    // Start is called before the first frame update
    void Start()
    {
        if (positions.Count == 0)
        {
            Debug.LogError("No Positions given to gaurd: " + gameObject.name);
            return;
        }

        transform.position = positions[0].position;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
