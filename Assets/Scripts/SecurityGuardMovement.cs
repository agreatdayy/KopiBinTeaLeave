using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityGuardMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D myRigidBody;
    void Start()
    {
        // Sets targeted rigidbody
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Sets speed of rigidbody
        myRigidBody.velocity = new Vector2(moveSpeed, 0f);
    }
    
    // Makes security guard turn around when it reaches the end of its intended area
    void OnTriggerExit2D(Collider2D other) {
        moveSpeed = -moveSpeed;
        FlipSecurityGuard();
    }

    // Flips security guard sprite, to prevent moonwalking
    void FlipSecurityGuard() {
        transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
    }
}
