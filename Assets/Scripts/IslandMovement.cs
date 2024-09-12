using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class IslandMovement : MonoBehaviour
{
    
    public float movementSpeed = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move ();
    }

    public void Move()
    {
        transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);
    }

    public void StopMovement()
    {
        movementSpeed = 0f;
    }
}
