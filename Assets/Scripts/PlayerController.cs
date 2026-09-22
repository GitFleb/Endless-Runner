using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;


public class PlayerController : MonoBehaviour
{

    Rigidbody2D playerObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerObject = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float movementValueX = Input.GetAxis("Horizontal"); 

        playerObject.linearVelocity = new Vector2(movementValueX, playerObject.linearVelocity.y);

    }
}
