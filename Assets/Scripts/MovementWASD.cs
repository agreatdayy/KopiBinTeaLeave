using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementWASD : MonoBehaviour
{
    [SerializeField] float RunSpeed = 5f;
    [SerializeField] float JumpSpeed = 5f;

    float MovementX;
    float MovementY;

    Rigidbody2D Rb;
    BoxCollider2D myFeetCollider;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        MovementX = 0;
        MovementY = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Rb.velocity = new Vector2(MovementX * RunSpeed * Time.deltaTime, MovementY * JumpSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W) && myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground", "Interactables"))) {
            //MovementY = 1;
            Rb.velocity += new Vector2(0f, JumpSpeed);
        }

        if (Input.GetKeyDown(KeyCode.A)) {
            MovementX = -1;
        }

        if (Input.GetKeyDown(KeyCode.D)) {
            MovementX = 1;
        }

        /*
        if (Input.GetKeyUp(KeyCode.W)) {
            MovementY = 0;
        }
        */

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) {
            MovementX = 0;
        }
    }
}
