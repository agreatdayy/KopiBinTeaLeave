using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementArrowKeys : MonoBehaviour
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

        if (Input.GetKeyDown(KeyCode.UpArrow) && myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground", "Interactables"))) {
            //MovementY = 1;
            Rb.velocity += new Vector2(0f, JumpSpeed);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            MovementX = -1;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            MovementX = 1;
        }

        /*
        if (Input.GetKeyUp(KeyCode.UpArrow)) {
            MovementY = 0;
        }
        */

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)) {
            MovementX = 0;
        }
    }
}
